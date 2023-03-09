
using System;
using Cysharp.Threading.Tasks;
using RMC.Core.Audio;
using RMC.Core.UI.DialogSystem;

namespace RMC.Core.Scaffold
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class ScaffoldHelper
    {
        public static string FormatWithCapitalStarting(string message)
        {
            return message[0].ToString().ToUpperInvariant() + message.Substring(1);
        }
        
         
        /// <summary>
        /// Show "Loading..." And Send Transaction
        /// </summary>
        public static async UniTask ShowDialogAsync(
            DialogSystem dialogSystem, 
            string dialogTitle,
            DialogData dialogData, 
            Func<UniTask> transactionCall,
            Func<UniTask> refreshCall)
        {
            
            // Decorate text
            string functionName = ScaffoldHelper.FormatWithCapitalStarting(dialogTitle);
            dialogData.SendingMessage = string.Format(dialogData.SendingMessage, functionName);
            dialogData.SentMessage = string.Format(dialogData.SentMessage, functionName);
            dialogData.AwaitingMessage = string.Format(dialogData.AwaitingMessage, functionName);
            
            await ShowDialogAsync(
                dialogSystem, 
                dialogData,
                transactionCall,
                refreshCall);
        }
        
        /// <summary>
        /// Show "Loading..." And Send Transaction
        /// </summary>
        public static async UniTask ShowDialogAsync(
            DialogSystem dialogSystem, 
            DialogData dialogData,
            Func<UniTask> transactionCall, 
            Func<UniTask> refreshingCall)
        {
            await dialogSystem.ShowDialogAsync(
                 dialogData,
                transactionCall,
                refreshingCall);
        }

        public static void PlayAudioClipClick01()
        {
            AudioManager.Instance.PlayAudioClip("Click01");
        }
        
        public static void PlayAudioClipClick02()
        {
            AudioManager.Instance.PlayAudioClip("Click02");
        }
    }
}