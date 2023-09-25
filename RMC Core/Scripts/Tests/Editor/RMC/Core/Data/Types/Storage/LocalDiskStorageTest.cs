using System;
using NUnit.Framework;
using RMC.Core.Components.Attributes;
using UnityEngine;

namespace RMC.Core.Data.Types.Storage
{
    [CustomFilePath("LocalDiskStorageTestSample", CustomFilePathLocation.StreamingAssetsPath)]
    public class LocalDiskStorageTestSample
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
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample>();
            }
        }

        [TearDown]
        public void TearDown()
        {
            //Ensure deleted after testing (to remove console error)
            if (LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample>())
            {
                LocalDiskStorage.Instance.Delete<LocalDiskStorageTestSample>();
            }
        }


        //  Methods ---------------------------------------
        [Test]
        public void Has_ResultIsFalse_WhenNotSaved()
        {
            // Arrange
       
            // Act
            bool hasData = LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample>();

            // Assert
            Assert.That(hasData, Is.False);
            
        }
        
        [Test]
        public void Has_ResultIsTrue_WhenSaved()
        {
            // Arrange
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample> (
                new LocalDiskStorageTestSample());
            
            // Act
            bool hasData = LocalDiskStorage.Instance.Has<LocalDiskStorageTestSample>();

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
                var data = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample>();
            });

        }
        
        [Test]
        public void Load_ResultIsNotNull_WhenSaved()
        {
            // Arrange
            LocalDiskStorage.Instance.Save<LocalDiskStorageTestSample> (
                new LocalDiskStorageTestSample());

            // Act
            var data = LocalDiskStorage.Instance.Load<LocalDiskStorageTestSample>();

            // Assert
            Assert.That(data, Is.Not.Null);
            
        }
        
        //  Event Handlers --------------------------------
    }
}