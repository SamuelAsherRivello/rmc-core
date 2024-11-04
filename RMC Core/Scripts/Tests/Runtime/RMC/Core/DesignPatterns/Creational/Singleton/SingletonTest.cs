using NUnit.Framework;

namespace RMC.Core.DesignPatterns.Creational.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    [Category("RMC.Core.DesignPatterns")]
    public class SingletonTest
    {
        //  Classes ----------------------------------------
        private class SampleSingleton : Singleton<SampleSingleton>, ISingletonParent
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
            if (SampleSingleton.IsInstantiated)
            {
                SampleSingleton.Dispose();
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
            SampleSingleton singletonInstance = SampleSingleton.Instance;

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
            SampleSingleton singletonInstance = SampleSingleton.Instance;

            // Act
            int result = singletonInstance.Value;

            // Assert
            Assert.AreEqual(0, result, "Result is 0");
        }
        
        
        [Test]
        public void OnInstantiatedChildWasCalled_IsTrue_WhenDefault()
        {
            // Arrange
            SampleSingleton singletonInstance = SampleSingleton.Instance;

            // Act
            bool result = singletonInstance.OnInstantiatedChildWasCalled;

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
            SampleSingleton firstInstance = SampleSingleton.Instance;
            SampleSingleton secondInstance = SampleSingleton.Instance;

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
            SampleSingleton singletonInstance = SampleSingleton.Instance;

            // Act
            SampleSingleton.Dispose();
            bool isInstantiatedAfterDispose = SampleSingleton.IsInstantiated;

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
            SampleSingleton singletonInstance = SampleSingleton.Instance;
            singletonInstance.Value = 42;

            // Act
            int result = SampleSingleton.Instance.Value;

            // Assert
            Assert.AreEqual(42, result, "Modified value is retained across accesses");
        }
        
        //  Event Handlers --------------------------------
            
    }
}