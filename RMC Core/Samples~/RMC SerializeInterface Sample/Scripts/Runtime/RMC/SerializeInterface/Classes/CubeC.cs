using UnityEngine;

namespace RMC.Core.Samples.SerializeInterface
{
    /// <summary>
    /// Demo of SerializeInterface
    /// </summary>
    [CreateAssetMenu(
        fileName = "CubeWithInterfaceScriptableObject", 
        menuName = "RMC/SerializeInterface/CubeWithInterfaceScriptableObject", 
        order = -1000)]
    public class CubeC : ScriptableObject, ICube
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        
        
        //  Fields ----------------------------------------

        
        //  Unity Methods  --------------------------------
        protected void Start()
        {
        }

        
        //  Methods ---------------------------------------
        public void HelloWorld()
        {
            Debug.Log($"Hello World from {this}");
        }   
        
        //  Event Handlers --------------------------------

    }
}

