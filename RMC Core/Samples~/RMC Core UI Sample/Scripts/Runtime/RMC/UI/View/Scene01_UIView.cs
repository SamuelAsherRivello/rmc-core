using UnityEngine;
using UnityEngine.Serialization;

#pragma warning disable CS1998
namespace RMC.Core.UI.Samples.View
{
    /// <summary>
    /// UI for <see cref="Scene01_UI"/>
    /// </summary>
    public class Scene01_UIView : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        
        public TextPanelUI TextPanelUI { get { return _textPanelUI;} }
        public TextFieldUI TextFieldUI { get { return _textFieldUI;} }
        public TextAreaUI TextAreaUI { get { return _textAreaUI;} }
        
        public TextInputFieldUI TextInputFieldUI { get { return _textInputFieldUI;} }
        public ButtonUI ButtonUI { get { return _buttonUI;} }

        //  Fields ----------------------------------------
        
        [SerializeField]
        private TextPanelUI _textPanelUI;

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