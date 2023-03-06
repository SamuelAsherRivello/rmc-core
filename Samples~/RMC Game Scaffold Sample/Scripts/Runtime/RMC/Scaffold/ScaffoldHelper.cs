
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
        public static async UniTask ShowDialog(
            DialogSystemView dialogSystemView, 
            string dialogTitle,
            DialogMessageData dialogMessageData, 
            Func<UniTask> transactionCall,
            Func<UniTask> refreshCall)
        {
            
            // Decorate text
            string functionName = ScaffoldHelper.FormatWithCapitalStarting(dialogTitle);
            dialogMessageData.SendingMessage = string.Format(dialogMessageData.SendingMessage, functionName);
            dialogMessageData.SentMessage = string.Format(dialogMessageData.SentMessage, functionName);
            dialogMessageData.AwaitingMessage = string.Format(dialogMessageData.AwaitingMessage, functionName);
            
            await ShowDialog(
                dialogSystemView, 
                dialogMessageData,
                transactionCall,
                refreshCall);
        }
        
        /// <summary>
        /// Show "Loading..." And Send Transaction
        /// </summary>
        public static async UniTask ShowDialog(
            DialogSystemView dialogSystemView, 
            DialogMessageData dialogMessageData,
            Func<UniTask> transactionCall, 
            Func<UniTask> refreshingCall)
        {
            await dialogSystemView.ShowDialog(
                 dialogMessageData,
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