using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RMC.Core.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class TupleConverter
	{
		//  Events ----------------------------------------

		//  Properties ------------------------------------

		//  Fields ----------------------------------------

		//  Methods ---------------------------------------
		public static bool IsTupleString(string sourceString)
		{
			//format
			if (!sourceString.StartsWith("{\"0\"", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			
			//format
			if (!sourceString.Contains(":", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}

			//structure
			int colonCount = sourceString.Count((ch => ch == ':'));
			int commaCount = sourceString.Count((ch => ch == ','));
			if (commaCount != colonCount - 1)
			{
				return false;
			}
			
			//format: keys must be convertible to INTS and MUST be in ascending order
			KeyValuePair<string, string>[] keyValuePairs = ConvertTupleStringToStringValues(sourceString);
			int lastKey = 0;
			int nextKey = 0;
			for (int i = 0; i < keyValuePairs.Length; i++)
			{
				try
				{
					nextKey = Int32.Parse(keyValuePairs[i].Key);
					if (i > 0 && nextKey <= lastKey)
					{
						return false;
					}
					lastKey = nextKey;
				}
				catch
				{
					return false;
				}
			}
			return true;
		}

		public static KeyValuePair<string, string>[] ConvertTupleStringToStringValues(string sourceString)
		{
			string resultStringValues = sourceString;
			resultStringValues = resultStringValues.Replace("{", "");
			resultStringValues = resultStringValues.Replace("}", "");
			string[] kvp = resultStringValues.Split(",");
			KeyValuePair<string, string>[] values = new KeyValuePair<string, string>[kvp.Length];
			for (int i = 0; i < kvp.Length; i++)
			{
				//Change "\"0\":\"100\"" to "0","100"
				values[i] = new KeyValuePair<string,string>(
					kvp[i].Split(":")[0].Replace("\"",""),
					kvp[i].Split(":")[1].Replace("\"",""));
			}

			return values;
		}
		
		
		/// <summary>
		/// Proceed from TOP to BOTTOM in the tuple declaration and c# declaration
		///
		/// and braid the values from the tuple into the C# object. Return C# object
		/// </summary>
		public static T ConvertTupleStringToObject<T>(string resultString)
		{
			if (!IsTupleString(resultString))
			{
				throw new SerializationException("ResultString must be IsTupleResult()==true");
			}
			
			T result = default(T);

			KeyValuePair<string, string>[] keyValuePairs = ConvertTupleStringToStringValues(resultString);
			// T must have constructor with ZERO parameters
			ConstructorInfo zeroParameterConstuctorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
			if (zeroParameterConstuctorInfo == null)
			{
				throw new SerializationException("this instance must have a parameterless constructor");
			}
			else
			{
				try
				{
					result = (T)Activator.CreateInstance(typeof(T));
					FieldInfo[] fieldInfos = result.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
					//Debug.Log("fieldInfos: " + fieldInfos.Length);
					for (int i = 0; i < fieldInfos.Length; i++)
					{
						FieldInfo fieldInfo = fieldInfos[i];
						var newValue = JsonConvert.DeserializeObject(keyValuePairs[i].Value, fieldInfo.FieldType);
						fieldInfo.SetValue(result, newValue);
						//Debug.Log(fieldInfo.Name + " with " + fieldInfo.FieldType.Name + " = " + fieldInfo.GetValue(result));
					}
				}
				catch (Exception e)
				{
					throw new SerializationException(e.Message);
				}
			}
			return result;
		}
		
		//  Event Handlers --------------------------------
	}
}