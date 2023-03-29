using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using RMC.Core.Helpers;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif //UNITY_EDITOR

#pragma warning disable CS4014, CS0618
namespace RMC.Core.UI.DialogSystem
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// View for <see cref="DialogUIPrefab"/>
    /// </summary>
    public class DialogSystem : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public DialogUI DialogUIPrefab { get {  return _dialogUIPrefab;} }

        public bool IsVisibleDialog
        {
            get
            {
                return _dialogUIPrefab.ScreenMessageUI.IsVisible;
            }
            set
            {
                _dialogUIPrefab.ScreenMessageUI.IsVisible = value;
            }
        }

        //  Fields ----------------------------------------
        [SerializeField] 
        private DialogUI _dialogUIPrefab;

        [SerializeField] 
        private VisualTransition _visualTransition;
        private async UniTask WaitTransactionUniTaskDelay() { await UniTask.Delay(1000, DelayType.DeltaTime, PlayerLoopTiming.LastUpdate);}

        private DialogUI _dialogUIInstance;
        
        //  Unity Methods  --------------------------------
        protected void Start()
        {
            
#if UNITY_EDITOR
            Assert.IsTrue(PrefabUtility.IsPartOfAnyPrefab(_dialogUIPrefab), "Must be Prefab.");
#endif //UNITY_EDITOR
            
            _dialogUIPrefab.ScreenMessageUI.IsVisible = false;
            
       }

        //  Methods ---------------------------------------
        
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="dialogData"></param>
        /// <param name="transactionCall"></param>
        /// <param name="refreshingCall"></param>
        public async UniTask ShowDialogAsync(
            DialogData dialogData,
            Func<UniTask> transactionCall, 
            Func<UniTask> refreshingCall)
        {
            
            // Phase 1
            // Show Text Immediately
            if (_dialogUIInstance != null)
            {
                GameObject.Destroy(_dialogUIInstance.gameObject);
                _dialogUIInstance = null;
            }
            
            _dialogUIInstance = GameObject.Instantiate(DialogUIPrefab, gameObject.transform);
            _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogData.SendingMessage;
            
           
            //Animate
            await _visualTransition.ApplyVisualTransition(_dialogUIInstance.ScreenMessageUI, async () =>
            {
                //(Do not await)
                Task.Run(async () =>
                {
                    
                    // Phase 2
                    // Show Text After Delay 
                    _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogData.SentMessage;
                    
                    //Render
                    await UniTask.NextFrame();
                
                    //Wait
                    await UniTask.Delay((int)dialogData.DelaySecondsSent * 5000);
                    
                    //Destroy
                    GameObject.Destroy(_dialogUIInstance.gameObject);
                    _dialogUIInstance = null;

                });
                
                //Render
                await UniTask.NextFrame();
                
                //Wait
                await UniTask.Delay((int)dialogData.DelaySecondsSending * 1000);
                
                await transactionCall();
                
                
                // Phase 3
                // Show Text After Delay
                _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogData.AwaitingMessage;
                
                //Render
                await UniTask.NextFrame();
                
                //Wait
                await UniTask.Delay((int)dialogData.DelaySecondsAwaiting * 1000);
                
                await refreshingCall();
         
            });
            
        }

        

        
        //  Event Handlers --------------------------------
        
        
        
    }
}