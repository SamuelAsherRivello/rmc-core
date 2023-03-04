
using RMC.Core.Components.Attributes;
using RMC.Core.Data.Types.Storage;
using RMC.Core.DesignPatterns.Creational.Singleton.CustomSingleton;
using UnityEngine;

namespace RMC.Core.Scaffold
{
    /// <summary>
    /// Demo of storage that persists across scenes and across game sessions.
    /// It is written to disc
    /// </summary>
    [CustomFilePath("ScaffoldLocalDiskStorage", CustomFilePathLocation.StreamingAssetsPath)]
    public class ScaffoldLocalDiskStorage
    {
        public bool IsAuthenticated = false;
    }

    /// <summary>
    /// Demo of functionality that persists across scenes
    /// </summary>
    public class ScaffoldSingleton : Singleton<ScaffoldSingleton>, ISingletonParent
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------

        /// <summary>
        /// Value stored on DISK
        /// </summary>
        public bool IsAuthenticated
        {
            
            get
            {
                // Create?
                if (!LocalDiskStorage.Instance.Has<ScaffoldLocalDiskStorage>())
                {
                    LocalDiskStorage.Instance.Save(new ScaffoldLocalDiskStorage(), true);
                  
                }
                
                // Load
                ScaffoldLocalDiskStorage scaffoldLocalDiskStorage =
                    LocalDiskStorage.Instance.Load<ScaffoldLocalDiskStorage>();
                
                // Return
                return scaffoldLocalDiskStorage.IsAuthenticated; 
            }
            set
            {
                // Load
                ScaffoldLocalDiskStorage scaffoldLocalDiskStorage =
                    LocalDiskStorage.Instance.Load<ScaffoldLocalDiskStorage>();

                // Update
                scaffoldLocalDiskStorage.IsAuthenticated = value;

                // Return
                LocalDiskStorage.Instance.Save(scaffoldLocalDiskStorage);
            }
        }
        
        
        /// <summary>
        /// Value stored in RAM only
        /// </summary>
        public bool IsSetting01Enabled { get { return _isSetting01Enabled; } set { _isSetting01Enabled = value; } }
        
        
        /// <summary>
        /// Value stored in RAM only
        /// </summary>
        public bool IsSetting02Enabled { get { return _isSetting02Enabled; } set { _isSetting02Enabled = value; } }

        //  Fields ----------------------------------------
        private bool _isSetting01Enabled = false;
        private bool _isSetting02Enabled = false;
        
        //  Initialization --------------------------------
        void ISingletonParent.OnInstantiatedChild()
        {
            // If needed...
            Debug.Log("ScaffoldSingleton.OnInstantiatedChild()");
        }


        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
}