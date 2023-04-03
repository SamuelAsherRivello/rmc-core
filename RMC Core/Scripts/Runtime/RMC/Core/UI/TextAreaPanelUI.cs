using RMC.Core.Extensions;
using RMC.Core.Interfaces;
using UnityEngine;

namespace RMC.Core.UI
{
    /// <summary>
    /// Use this or subclass for EVERY use case where you want
    /// a header text above body text.
    /// </summary>
    public class TextAreaPanelUI : MonoBehaviour, 
        IIsVisible, IIsInteractable
    {
      
        //  Properties  ---------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;}}
        public TextAreaUI BodyTextAreaUI { get { return _bodyTextAreaUI;}}

        public bool IsVisible
        {
            get
            {
                // Cascade
                return _canvasGroup.GetIsVisible() && 
                       HeaderTextFieldUI.IsVisible &&
                       BodyTextAreaUI.IsVisible;
            }
            set
            {
                // Cascade
                _canvasGroup.SetIsVisible(value);
                HeaderTextFieldUI.IsVisible = value;
                BodyTextAreaUI.IsVisible = value;
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
        private TextAreaUI _bodyTextAreaUI = null;

        //  Unity Methods  --------------------------------
    }
}