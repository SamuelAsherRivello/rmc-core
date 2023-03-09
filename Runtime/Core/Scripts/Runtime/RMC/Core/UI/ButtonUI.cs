using RMC.Core.Extensions;
using RMC.Core.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Core.UI
{
    /// <summary>
    /// Use this or subclass for EVERY UI.Button use case
    /// </summary>
    public class ButtonUI : MonoBehaviour, 
        IIsVisible, IIsInteractable
    {
      
        //  Properties  ---------------------------------------
        public TMP_Text Text { get { return _text;}}
        public Button Button { get { return _button;}}

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
        private Button _button = null;
      
        [SerializeField] 
        private CanvasGroup _canvasGroup = null;
      
        [SerializeField] 
        private TMP_Text _text = null;
      
        
        //  Unity Methods  --------------------------------
    }
}