using RMC.Core.Extensions;
using RMC.Core.Interfaces;
using TMPro;
using UnityEngine;

namespace RMC.Core.UI
{
    /// <summary>
    /// Use this or subclass for EVERY UI.InputField use case
    /// </summary>
    public class TextInputFieldUI : MonoBehaviour, 
        IIsVisible, IIsInteractable
    {
      
        //  Properties  ---------------------------------------
        public TMP_InputField InputField { get { return _inputField;}}

        public bool IsVisible
        {
            get
            {
                return _canvasGroup.GetIsVisible();
            }
            set
            {
                _canvasGroup.SetIsVisible(value);
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
        private TMP_InputField _inputField = null;
      
        
        //  Unity Methods  --------------------------------
    }
}