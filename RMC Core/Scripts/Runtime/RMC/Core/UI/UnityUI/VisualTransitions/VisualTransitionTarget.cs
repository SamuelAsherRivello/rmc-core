using UnityEngine;

namespace RMC.Core.UI.UnityUI.VisualTransitions
{
    /// <summary>
    /// Stores the target of the <see cref="VisualTransition"/>
    /// </summary>
    public class VisualTransitionTarget: MonoBehaviour, IVisualTransitionTarget
    {
        //  Properties ------------------------------------
        
        public float Alpha
        {
            get
            {
                if (!_canvasGroup)
                {
                    return 0;
                }
                return  _canvasGroup.alpha;
            }
            set
            {
                if (!_canvasGroup)
                {
                    return;
                }
                _canvasGroup.alpha = value;
            }
        }
        
        public bool IsBlocksRaycasts
        {
            get
            {
                return _canvasGroup != null && _canvasGroup.blocksRaycasts;
            }
            set
            {
                if (!_canvasGroup)
                {
                    return;
                }
                _canvasGroup.blocksRaycasts = value;
            }
        }
    
        //  Fields ----------------------------------------
        [SerializeField]
        private CanvasGroup _canvasGroup = null;

        //  Methods ---------------------------------------
    }
}