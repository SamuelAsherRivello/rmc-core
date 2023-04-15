using RMC.Core.Extensions;
using RMC.Core.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Core.UI
{
    /// <summary>
    /// Powerful wrapper recommended for all uses of <see cref="TMP_Text"/>
    /// when a Header and Body are needed.
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

        public ScrollRect ScrollRect
        {
            get
            {
                return _scrollRect;
            }
        }

        
        //  Fields  ---------------------------------------
        [SerializeField] 
        private CanvasGroup _canvasGroup = null;
      
        [SerializeField] 
        private TextFieldUI _headerTextFieldUI = null;
      
        [SerializeField] 
        private TextAreaUI _bodyTextAreaUI = null;

        [SerializeField] 
        private ScrollRect _scrollRect = null;

        
        //  Unity Methods  --------------------------------
    }
}