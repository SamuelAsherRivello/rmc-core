#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace RMC.Core.Components
{
    //TODO: Reename class to include ... selection
    
    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class SetAsActiveGameObjectComponent : MonoBehaviour
    {
        //  Properties ------------------------------------

        
        //  Fields ----------------------------------------
        [SerializeField]
        private bool _isSelectionActiveGameObject = true;

        
        //  Unity Methods----------------------------------
        protected void Awake()
        {
            
            
#if UNITY_EDITOR
            if (_isSelectionActiveGameObject)
            {
                Selection.activeGameObject = gameObject;
            }
#endif
      
            
        }


        //  General Methods -------------------------------

		
        //  Event Handlers --------------------------------
    }
}