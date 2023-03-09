using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
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
    public class DialogSystemView : MonoBehaviour
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
            _dialogUIPrefab.ScreenMessageUI.IsVisible = false;
            
#if UNITY_EDITOR
            Assert.IsTrue(PrefabUtility.IsPartOfAnyPrefab(DialogUIPrefab), "Must be Prefab.");
#endif //UNITY_EDITOR
            
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
            if (_dialogUIInstance != null)
            {
                GameObject.Destroy(_dialogUIInstance);
            }
            _dialogUIInstance = GameObject.Instantiate(DialogUIPrefab, gameObject.transform);
            
            _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.SendingMessage;
            await UniTask.WaitForEndOfFrame();
           
            await _visualTransition.ApplyVisualTransition(_dialogUIInstance.ScreenMessageUI, async () =>
            {
                //(Do not await)
                Task.Run(async () =>
                {
                    // Phase 2
                    // Show Text After Delay 
                    await WaitTransactionUniTaskDelay();
                    _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.SentMessage;
                    await UniTask.WaitForEndOfFrame();
                });
                
                await UniTask.WaitForEndOfFrame();
                
                await transactionCall();
                
                // Phase 3
                // Show Text After Delay
                await WaitTransactionUniTaskDelay();
                _dialogUIInstance.ScreenMessageUI.TextFieldUI.Text.text = dialogMessageData.AwaitingMessage;
                await refreshingCall();
                
                GameObject.Destroy(_dialogUIInstance);
            });
            
        }
    }
}