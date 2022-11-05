using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using RMC.Core.Data.Types;
using UnityEngine;
using RMC.Core.Helpers;
using RMC.Core.Interfaces;

#pragma warning disable CS0618
namespace RMC.Core.UI.VisualTransitions
{
    [CreateAssetMenu( menuName = CoreConstants.PathCoreCreateAssetMenu + Title, 
        fileName = Title, order = CoreConstants.PriorityTools_Primary)]
    public class VisualTransition: ScriptableObject
    {
        //  Properties ------------------------------------
    
        //  Fields ----------------------------------------
        private const string Title = "VisualTransition";

        [Header("Before")]
        [SerializeField]
        private float _delayBeforeSeconds = 0;

        [Header("During")]
        [SerializeField]
        private float _durationSeconds = 0.5f;

        [SerializeField] 
        private Ease _easeIn = Ease.Linear;

        [SerializeField]
        private float _delayMidpointSeconds = 0;

        [SerializeField] 
        private Ease _easeOut = Ease.Linear;
   
        [Header("After")]
        [SerializeField]
        private float _delayAfterSeconds = 0;

       
        
        //  Methods ---------------------------------------
        public async UniTask ApplyVisualTransition(IVisualTransitionTarget visualTransitionTarget, Func<UniTask> action)
        {
            //Half in / half out
            float halfDuration = _durationSeconds / 2;
            
            // BEFORE
            visualTransitionTarget.IsBlocksRaycasts = true;
            await TweenHelper.AlphaDoFade(visualTransitionTarget, 0, 1, 
                halfDuration,
                _delayBeforeSeconds,
                _easeIn);
            await UniTask.WaitForEndOfFrame(); 

            // DURING
            await action();
            
            // AFTER
            await TweenHelper.AlphaDoFade(visualTransitionTarget, 1, 0, 
                halfDuration,
                _delayMidpointSeconds,
                _easeOut);
            await UniTask.WaitForEndOfFrame();
            await UniTask.Delay((int)(_delayAfterSeconds*1000));
            visualTransitionTarget.IsBlocksRaycasts = false;
        }
    }

}