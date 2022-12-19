using System;
using System.Collections.Generic;
using System.Linq;

namespace RMC.Core.Architectures.MiniMvcs
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class Locator<T>
	{
		//  Events ----------------------------------------

		//  Properties ------------------------------------
        
		//  Fields ----------------------------------------
		private List<T> _items = new List<T>();
        
		//  Initialization  -------------------------------
		
		//  Methods ---------------------------------------
		public void AddItem (T item)
		{
			if (HasItem<T>())
			{
				// Allow MAX 0 or 1 instance of T
				throw new Exception("AddItem() failed. Must call HasItem<T>() first.");
			}
			_items.Add(item);
		}
		
		public bool HasItem<SubType>() where SubType :T 
		{
			return GetItem<SubType>() != null;
		}
		
		public SubType GetItem<SubType>() where SubType :T 
		{
			return _items.OfType<SubType>().ToList().FirstOrDefault<SubType>();
		}
		
		public T GetItem(Type type)
		{
			return _items.FirstOrDefault(item => item.GetType() == type);
		}

		public void RemoveItem(T item)
		{
			if (!HasItem<T>())
			{
				throw new Exception("RemoveItem() failed. Must call HasItem<T>() first.");
			}
			_items.Remove(item);
		}
		
		//  Event Handlers --------------------------------
	}
}