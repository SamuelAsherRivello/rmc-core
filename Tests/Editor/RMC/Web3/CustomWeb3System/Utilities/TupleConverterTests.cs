using System.Collections.Generic;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace RMC.Core.Utilities
{
    public class TupleConverterTests
    {
        static string[] ValidTupleStrings = new string[]
        {
            "{\"0\":\"50\"}",
            "{\"0\":\"50\",\"1\":\"100\"}",
            "{\"0\":\"50\",\"1\":\"100\",\"2\":\"149\",\"3\":\"277\"}"
        };
        
        static string[] InvalidTupleStrings = new string[]
        {
            "{\"1\":\"50\"}", //wrong startswith
            "{\"0\"}", //no first value
            "{\"0\":\"50\"\"1\":\"100\"}", //missing ,
            "{\"0\":\"50\",\"1\":\"100\",\"3\":\"149\",\"3\":\"277\"}" //non sequential keys ,
        };
        
        [Test]
        public void IsTupleString_IsTrue_WhenValidString([ValueSource("ValidTupleStrings")] string sourceString)
        {
            // Arrange
            
            // Act
            bool result = TupleConverter.IsTupleString(sourceString);

            // Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void IsTupleString_IsFalse_WhenNotValidString([ValueSource("InvalidTupleStrings")] string sourceString)
        {
            // Arrange

            // Act
            bool result = TupleConverter.IsTupleString(sourceString);

            // Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void ConvertTupleStringToStringValues_IsLength2_WhenValidStringFor2()
        {
            // Arrange
            string tupleString = "{\"0\":\"50\",\"1\":\"100\"}";

            // Act
            KeyValuePair<string, string>[] result = TupleConverter.ConvertTupleStringToStringValues(tupleString);

            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Value, "50");
            Assert.AreEqual(result[1].Value, "100");
        }

    }
}
