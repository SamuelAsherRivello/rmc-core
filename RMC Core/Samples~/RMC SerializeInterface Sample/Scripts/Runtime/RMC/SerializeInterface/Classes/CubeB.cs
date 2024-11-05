using UnityEngine;

namespace RMC.Core.Samples.SerializeInterface
{
    /// <summary>
    /// Demo of SerializeInterface
    /// </summary>
    public class CubeB : MonoBehaviour, ICube
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

