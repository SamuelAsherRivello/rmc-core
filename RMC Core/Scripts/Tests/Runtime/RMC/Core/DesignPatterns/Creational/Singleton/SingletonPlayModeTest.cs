using NUnit.Framework;

namespace RMC.Core.DesignPatterns.Creational.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    [Category("RMC.Core.DesignPatterns")]
    public class SingletonPlayModeTest
    {
        //  Classes ----------------------------------------
        private class SampleSingletonPlayMode : SingletonPlayMode<SampleSingletonPlayMode>, ISingletonParent
        {
            //  Properties ------------------------------------
            public int Value { get; set; } = 0;
            public bool OnInstantiatedChildWasCalled = false;


            //  Initialization Methods-------------------------

            void ISingletonParent.OnInstantiatedChild()
            {
                // Use this for initialization
                OnInstantiatedChildWasCalled = true;
            }


            //  General Methods -------------------------------

        }


        //  Initialization --------------------------------
        [SetUp]
        public void Setup()
        {
           
        }

        [TearDown]
        public void TearDown()
        {
            if (SampleSingletonPlayMode.IsInstantiated)
            {
                SampleSingletonPlayMode.Dispose();
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
            SampleSingletonPlayMode singletonPlayModeInstance = SampleSingletonPlayMode.Instance;

            // Act
            int result = singletonPlayModeInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
            
            // Make stale
            singletonPlayModeInstance.Value = 1;
        }
        
        /// <summary>
        /// Test the value again to be sure it's not stale from previous test
        /// </summary>
        [Test]
        public void Value_ResultIsZero_WhenDefault_02()
        {
            // Arrange
            SampleSingletonPlayMode singletonPlayModeInstance = SampleSingletonPlayMode.Instance;

            // Act
            int result = singletonPlayModeInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
        }
        
        
        [Test]
        public void OnInstantiatedChildWasCalled_IsTrue_WhenDefault()
        {
            // Arrange
            SampleSingletonPlayMode singletonPlayModeInstance = SampleSingletonPlayMode.Instance;

            // Act
            bool result = singletonPlayModeInstance.OnInstantiatedChildWasCalled;

            // Assert
            Assert.IsTrue(result, "Result is true");
        }
        
        
        /// <summary>
        /// Ensures that the Singleton is instantiated only once
        /// </summary>
        [Test]
        public void Instance_IsSame_WhenAccessedMultipleTimes()
        {
            // Act
            SampleSingletonPlayMode firstInstance = SampleSingletonPlayMode.Instance;
            SampleSingletonPlayMode secondInstance = SampleSingletonPlayMode.Instance;

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
            SampleSingletonPlayMode singletonPlayModeInstance = SampleSingletonPlayMode.Instance;

            // Act
            SampleSingletonPlayMode.Dispose();
            bool isInstantiatedAfterDispose = SampleSingletonPlayMode.IsInstantiated;

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
            SampleSingletonPlayMode singletonPlayModeInstance = SampleSingletonPlayMode.Instance;
            singletonPlayModeInstance.Value = 42;

            // Act
            int result = SampleSingletonPlayMode.Instance.Value;

            // Assert
            Assert.AreEqual(42, result, "Modified value is retained across accesses");
        }
        
        //  Event Handlers --------------------------------
            
    }
}