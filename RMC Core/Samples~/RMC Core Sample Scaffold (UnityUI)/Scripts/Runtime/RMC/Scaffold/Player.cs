
using UnityEngine;

namespace RMC.Core.Samples.Scaffold
{
    /// <summary>
    /// Example of a player in-game
    /// </summary>
    public class Player : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------

        //  Fields ----------------------------------------

        //  Unity Methods ---------------------------------
        protected void Update()
        {
            transform.Rotate(new Vector3(0.1f, 0.1f, 0.1f));
        }
        
        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}