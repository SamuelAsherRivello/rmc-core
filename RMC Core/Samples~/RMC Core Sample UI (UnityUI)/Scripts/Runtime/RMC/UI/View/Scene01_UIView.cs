using RMC.Core.Samples.UI.Scenes;
using RMC.Core.UI.UnityUI;
using UnityEngine;

#pragma warning disable CS1998
namespace RMC.Core.Samples.UI.View
{
    /// <summary>
    /// UI for <see cref="Scene01_UI"/>
    /// </summary>
    public class Scene01_UIView : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        
        public TextAreaPanelUI TextAreaPanelUI { get { return _textAreaPanelUI;} }
        public TextFieldUI TextFieldUI { get { return _textFieldUI;} }
        public TextAreaUI TextAreaUI { get { return _textAreaUI;} }
        
        public TextInputFieldUI TextInputFieldUI { get { return _textInputFieldUI;} }
        public ButtonUI ButtonUI { get { return _buttonUI;} }

        //  Fields ----------------------------------------
        
        [SerializeField]
        private TextAreaPanelUI _textAreaPanelUI;

        [SerializeField]
        private TextFieldUI _textFieldUI;

        [SerializeField]
        private TextAreaUI _textAreaUI;
        
        [SerializeField]
        private TextInputFieldUI _textInputFieldUI;

        [SerializeField]
        private ButtonUI _buttonUI;



        //  Unity Methods  --------------------------------
        protected async void Start()
        {
        }

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}