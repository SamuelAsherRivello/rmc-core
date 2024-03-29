using UnityEngine;

namespace RMC.Core.UI.UnityUI.DialogSystem
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// UI for <see cref="DialogSystem"/>
    /// </summary>
    public class DialogUI: MonoBehaviour 
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public ScreenMessageUI ScreenMessageUI { get {  return _screenMessageUI;} }

        //  Fields ----------------------------------------

        [SerializeField] 
        private ScreenMessageUI _screenMessageUI;
        
        //  Unity Methods  --------------------------------

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}