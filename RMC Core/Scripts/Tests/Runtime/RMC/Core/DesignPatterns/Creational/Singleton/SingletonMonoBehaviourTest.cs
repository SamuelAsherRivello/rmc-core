using NUnit.Framework;

namespace RMC.Core.DesignPatterns.Creational.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    [Category("RMC.Core.DesignPatterns")]
    public class SingletonMonoBehaviourTest
    {
        //  Classes ----------------------------------------
        private class SampleSingletonMonoBehaviour : SingletonMonoBehaviour<SampleSingletonMonoBehaviour>
        {
            //  Properties ------------------------------------
            public int Value { get; set; } = 0;

        }


        //  Initialization --------------------------------
        [SetUp]
        public void Setup()
        {
            if (SampleSingletonMonoBehaviour.IsInstantiated)
            {
                SampleSingletonMonoBehaviour.Dispose();
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (SampleSingletonMonoBehaviour.IsInstantiated)
            {
                SampleSingletonMonoBehaviour.Dispose();
            }
        }


        //  Methods ---------------------------------------
        
        /// <summary>
        /// Test the value
        /// </summary>
        [Test]
        public void Value_ResultIsZero_WhenDefault_01()
        {
            // Arrange
            SampleSingletonMonoBehaviour singletonInstance = SampleSingletonMonoBehaviour.Instance;

            // Act
            int result = singletonInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
            
            // Make stale
            singletonInstance.Value = 1;
        }
        
        /// <summary>
        /// Test the value again to be sure it's not stale from previous test
        /// </summary>
        [Test]
        public void Value_ResultIsZero_WhenDefault_02()
        {
            // Arrange
            SampleSingletonMonoBehaviour singletonInstance = SampleSingletonMonoBehaviour.Instance;

            // Act
            int result = singletonInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
        }
        
        
        /// <summary>
        /// Ensures that the Singleton is instantiated only once
        /// </summary>
        [Test]
        public void Instance_IsSame_WhenAccessedMultipleTimes()
        {
            // Act
            SampleSingletonMonoBehaviour firstInstance = SampleSingletonMonoBehaviour.Instance;
            SampleSingletonMonoBehaviour secondInstance = SampleSingletonMonoBehaviour.Instance;

            // Assert
            Assert.AreSame(firstInstance, secondInstance, "Singleton instance is the same across multiple accesses");
        }

        /// <summary>
        /// Ensures that Dispose method clears the singleton instance
        /// </summary>
        [Test]
        public void IsInstantiated_IsFalse_AfterDispose()
        {
            // Arrange
            SampleSingletonMonoBehaviour singletonInstance = SampleSingletonMonoBehaviour.Instance;

            // Act
            SampleSingletonMonoBehaviour.Dispose();
            bool isInstantiatedAfterDispose = SampleSingletonMonoBehaviour.IsInstantiated;

            // Assert
            Assert.IsFalse(isInstantiatedAfterDispose, "Singleton IsInstantiated is false after Dispose is called");
        }
        
        /// <summary>
        /// Ensures that modifying the singleton property reflects across accesses
        /// </summary>
        [Test]
        public void Value_IsRetained_WhenModified()
        {
            // Arrange
            SampleSingletonMonoBehaviour singletonInstance = SampleSingletonMonoBehaviour.Instance;
            singletonInstance.Value = 42;

            // Act
            int result = SampleSingletonMonoBehaviour.Instance.Value;

            // Assert
            Assert.AreEqual(42, result, "Modified value is retained across accesses");
        }
        
        //  Event Handlers --------------------------------
            
    }
}