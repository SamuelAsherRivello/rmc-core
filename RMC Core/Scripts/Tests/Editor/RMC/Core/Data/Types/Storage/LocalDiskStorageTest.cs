using System;
using NUnit.Framework;
using RMC.Core.Components.Attributes;
using UnityEngine;

namespace RMC.Core.Data.Types.Storage
{
    [CustomFilePath("LocalDiskStorageTestSample1", CustomFilePathLocation.StreamingAssetsPath)]
    public class LocalDiskStorageTestSample1
    {
        [SerializeField] 
        public int Value = 0;
    }
    
    [CustomFilePath("LocalDiskStorageTestSample2", CustomFilePathLocation.StreamingAssetsPath)]
    public class LocalDiskStorageTestSample2
    {
        [SerializeField] 
        public int Value = 0;
    }
    
    /// <summary>
    /// Replace with comments...
    /// </summary>
    [Category("RMC.Core.Data")]
    public class LocalDiskStorageTest
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------


        //  Initialization --------------------------------
        [SetUp]
        public void Setup()
        {
            //Ensure deleted before testing
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample1>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample1>();
            }
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample2>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample2>();
            }
        }

        [TearDown]
        public void TearDown()
        {
            //Ensure deleted after testing (to remove console error)
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample1>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample1>();
            }
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample2>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample2>();
            }
        }


        //  Methods ---------------------------------------
        [Test]
        public void Has_ResultIsFalse_WhenNotSaved()
        {
            // Arrange
       
            // Act
            bool hasData = LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample1>();

            // Assert
            Assert.That(hasData, Is.False);
            
        }
        
        [Test]
        public void Has_ResultIsTrue_WhenSaved()
        {
            // Arrange
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample1> (
                new LocalDiskStorageTestSample1());
            
            // Act
            bool hasData = LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample1>();

            // Assert
            Assert.That(hasData, Is.True);
            
        }
        
        [Test]
        public void Load_ThrowsException_WhenNotSaved()
        {
            // Arrange
       
            // Act

            // Assert
            Assert.Throws<Exception>(() =>
            {
                var data = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample1>();
            });

        }
        
        [Test]
        public void Load_ResultIsNotNull_WhenSaved()
        {
            // Arrange
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample1> (
                new LocalDiskStorageTestSample1());

            // Act
            var data = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample1>();

            // Assert
            Assert.That(data, Is.Not.Null);
            
        }
        
        [Test]
        public void Load_ResultIs10_WhenSavedIs10()
        {
            // Arrange
            int expectedValue = 10;
            var inputData = new LocalDiskStorageTestSample1();
            inputData.Value = expectedValue;
            
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample1> (
                inputData);

            // Act
            var outputData = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample1>();

            // Assert
            Assert.That(outputData.Value, Is.EqualTo(expectedValue));
            
        }
        
        [Test]
        public void Load_ResultIs10_WhenSavedIs10_B()
        {
            // Arrange
            int expectedValue = 10;
            var inputData = new LocalDiskStorageTestSample1();
            inputData.Value = expectedValue;
            
            // Test that an unrelated second object doesn't mess with result
            var inputData2 = new LocalDiskStorageTestSample2();
            inputData2.Value = 20;
            
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample1> (
                inputData);

            // Act
            var outputData = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample1>();

            // Assert
            Assert.That(outputData.Value, Is.EqualTo(expectedValue));
            
        }


        //  Event Handlers --------------------------------
            
    }
}