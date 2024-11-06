using NUnit.Framework;
using UnityEngine;

namespace RMC.Core.Components.Attributes
{
    public interface IStorageSample
    {
        int Value { get; set; }
    }

    [CustomFilePath("SampleClass", CustomFilePathLocation.PersistentDataPath)]
    public class SampleClass
    {
        [SerializeField]
        public int Value { get; set; }
    }

    [CustomFilePath("SampleClassWithInterface", CustomFilePathLocation.PersistentDataPath)]
    public class SampleClassWithInterface : IStorageSample
    {
        [SerializeField]
        public int Value { get; set; }
    }

    [Category("RMC.Core.Attributes")]
    public class CustomFilePathAttributeTest
    {
        [Test]
        public void GetCustomFilePathAttribute_ReturnsAttribute_WhenClassHasAttribute()
        {
            // Arrange
            var type = typeof(SampleClass);

            // Act
            var attribute = CustomFilePathAttribute.GetCustomFilePathAttribute(type);

            // Assert
            Assert.IsNotNull(attribute, "CustomFilePathAttribute should be found on SampleClass.");
            StringAssert.Contains("SampleClass", attribute.Filepath, "Filepath should include the relative path 'SampleClass'.");
            StringAssert.EndsWith("SampleClass", attribute.Filepath, "Filepath should end with 'SampleClass' for relative path match.");
            Assert.AreEqual(CustomFilePathLocation.PersistentDataPath, attribute.Location, "Location should match the attribute definition.");
        }

        [Test]
        public void GetCustomFilePathAttribute_ReturnsAttribute_WhenClassWithInterfaceHasAttribute()
        {
            // Arrange
            var type = typeof(SampleClassWithInterface);

            // Act
            var attribute = CustomFilePathAttribute.GetCustomFilePathAttribute(type);

            // Assert
            Assert.IsNotNull(attribute, "CustomFilePathAttribute should be found on SampleClassWithInterface.");
            StringAssert.Contains("SampleClassWithInterface", attribute.Filepath, "Filepath should include the relative path 'SampleClassWithInterface'.");
            StringAssert.EndsWith("SampleClassWithInterface", attribute.Filepath, "Filepath should end with 'SampleClassWithInterface' for relative path match.");
            Assert.AreEqual(CustomFilePathLocation.PersistentDataPath, attribute.Location, "Location should match the attribute definition.");
        }
    }
}
