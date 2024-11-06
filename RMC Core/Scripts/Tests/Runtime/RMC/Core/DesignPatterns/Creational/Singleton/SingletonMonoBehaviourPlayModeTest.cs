using NUnit.Framework;

namespace RMC.Core.DesignPatterns.Creational.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    [Category("RMC.Core.DesignPatterns")]
    public class SingletonMonoBehaviourPlayModeTest
    {
        //  Classes ----------------------------------------
        private class SampleSingletonMonoBehaviourPlayMode : SingletonMonoBehaviourPlayMode<SampleSingletonMonoBehaviourPlayMode>
        {
            //  Properties ------------------------------------
            public int Value { get; set; } = 0;
            
            public override void OnInitialized()
            {
            }

        }


        //  Initialization --------------------------------
        [SetUp]
        public void Setup()
        {
            //Ensure clean state between tests
            SampleSingletonMonoBehaviourPlayMode.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            //Ensure clean state between tests
            SampleSingletonMonoBehaviourPlayMode.Dispose();
        }


        //  Methods ---------------------------------------
        
        /// <summary>
        /// Test the value
        /// </summary>
        [Test]
        public void Value_ResultIsZero_WhenDefault_01()
        {
            // Arrange
            SampleSingletonMonoBehaviourPlayMode singletonInstance = SampleSingletonMonoBehaviourPlayMode.Instance;

            // Act
            int result = singletonInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
            
            // Make stale (For future test)
            singletonInstance.Value = 123;
        }
        
        /// <summary>
        /// Test the value again to be sure it's not stale from previous test
        /// </summary>
        [Test]
        public void Value_ResultIsZero_WhenDefault_02()
        {
            // Arrange
            SampleSingletonMonoBehaviourPlayMode singletonInstance = SampleSingletonMonoBehaviourPlayMode.Instance;

            // Act
            int result = singletonInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
            
            // Make stale (For future test)
            singletonInstance.Value = 456;
        }
        
        
        /// <summary>
        /// Ensures that the Singleton is instantiated only once
        /// </summary>
        [Test]
        public void Instance_IsSame_WhenAccessedMultipleTimes()
        {
            // Act
            SampleSingletonMonoBehaviourPlayMode firstInstance = SampleSingletonMonoBehaviourPlayMode.Instance;
            SampleSingletonMonoBehaviourPlayMode secondInstance = SampleSingletonMonoBehaviourPlayMode.Instance;

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
            SampleSingletonMonoBehaviourPlayMode singletonInstance = SampleSingletonMonoBehaviourPlayMode.Instance;

            // Act
            SampleSingletonMonoBehaviourPlayMode.Dispose();
            bool isInstantiatedAfterDispose = SampleSingletonMonoBehaviourPlayMode.IsInstantiated;

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
            SampleSingletonMonoBehaviourPlayMode singletonInstance = SampleSingletonMonoBehaviourPlayMode.Instance;
            singletonInstance.Value = 42;

            // Act
            int result = SampleSingletonMonoBehaviourPlayMode.Instance.Value;

            // Assert
            Assert.AreEqual(42, result, "Modified value is retained across accesses");
        }
        
        //  Event Handlers --------------------------------
            
    }
}