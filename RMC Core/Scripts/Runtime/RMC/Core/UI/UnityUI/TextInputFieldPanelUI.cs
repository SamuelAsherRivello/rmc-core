using RMC.Core.Extensions;
using RMC.Core.Interfaces;
using UnityEngine;

namespace RMC.Core.UI.UnityUI
{
    /// <summary>
    /// Powerful wrapper recommended for all uses of <see cref="TMP_InputField"/>
    /// </summary>
    public class TextInputFieldPanelUI : MonoBehaviour, 
        IIsVisible, IIsInteractable
    {
      
        //  Properties  ---------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;}}
        public TextInputFieldUI BodyTextInputFieldUI { get { return _bodyTextInputFieldUI;}}

        public bool IsVisible
        {
            get
            {
                // Cascade
                return _canvasGroup.GetIsVisible() && 
                       HeaderTextFieldUI.IsVisible &&
                       BodyTextInputFieldUI.IsVisible;
            }
            set
            {
                // Cascade
                _canvasGroup.SetIsVisible(value);
                HeaderTextFieldUI.IsVisible = value;
                BodyTextInputFieldUI.IsVisible = value;
            }
        }
      
        public bool IsInteractable
        {
            get
            {
                return _canvasGroup.GetIsInteractable();
            }
            set
            {
                if (_canvasGroup != null)
                {
                    _canvasGroup.SetIsInteractable(value);
                }
            }
        }

      
        //  Fields  ---------------------------------------
        [SerializeField] 
        private CanvasGroup _canvasGroup = null;
      
        [SerializeField] 
        private TextFieldUI _headerTextFieldUI = null;
      
        [SerializeField] 
        private TextInputFieldUI _bodyTextInputFieldUI = null;

        //  Unity Methods  --------------------------------
    }
}