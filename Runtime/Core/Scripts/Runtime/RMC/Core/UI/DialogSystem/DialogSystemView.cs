using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;

#pragma warning disable CS4014, CS0618
namespace RMC.Core.UI.DialogSystem
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// View for <see cref="DialogUI"/>
    /// </summary>
    public class DialogSystemView : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public DialogUI DialogUI { get {  return _dialogUI;} }

        public bool IsVisibleDialog
        {
            get
            {
                return _dialogUI.ScreenMessageUI.IsVisible;
            }
            set
            {
                _dialogUI.ScreenMessageUI.IsVisible = value;
            }
        }

        //  Fields ----------------------------------------
        [SerializeField] 
        private DialogUI _dialogUI;

        [SerializeField] 
        private VisualTransition _visualTransition;
        private async UniTask WaitTransactionUniTaskDelay() { await UniTask.Delay(1000, DelayType.DeltaTime, PlayerLoopTiming.LastUpdate);}
        
        //  Unity Methods  --------------------------------
        protected void Start()
        {
            _dialogUI.ScreenMessageUI.IsVisible = false;
        }

        //  Methods ---------------------------------------

        
        //  Event Handlers --------------------------------
        public async UniTask ShowDialog(
            DialogMessageData dialogMessageData,
            Func<UniTask> transactionCall, 
            Func<UniTask> refreshingCall)
        {
            
            // Phase 1
            // Show Text Immediately
            DialogUI.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.Sending;
            await UniTask.WaitForEndOfFrame();
           
            await _visualTransition.ApplyVisualTransition(DialogUI.ScreenMessageUI, async () =>
            {
                //(Do not await)
                Task.Run(async () =>
                {
                    // Phase 2
                    // Show Text After Delay 
                    await WaitTransactionUniTaskDelay();
                    DialogUI.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.Sent;
                    await UniTask.WaitForEndOfFrame();
                });
                
                await UniTask.WaitForEndOfFrame();
                
                await transactionCall();
                
                // Phase 3
                // Show Text After Delay
                await WaitTransactionUniTaskDelay();
                DialogUI.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.Awaiting;
                await refreshingCall();
            });
            
        }
    }
}