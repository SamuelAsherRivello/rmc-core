
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
            bool isReadWrite, 
            Func<UniTask> transactionCall,
            Func<UniTask> refreshCall)
        {
            
            // Choose text
            DialogMessageData dialogMessageData;
            if (isReadWrite)
            {
                dialogMessageData = ScaffoldConstants.ReadWriteDialogMessageData;
            }
            else
            {
                dialogMessageData = ScaffoldConstants.ReadDialogMessageData;
            }
            
            // Decorate text
            string functionName = ScaffoldHelper.FormatWithCapitalStarting(dialogTitle);
            dialogMessageData.Sending = string.Format(dialogMessageData.Sending, functionName);
            dialogMessageData.Sent = string.Format(dialogMessageData.Sent, functionName);
            dialogMessageData.Awaiting = string.Format(dialogMessageData.Awaiting, functionName);
            
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
            SoundManager.Instance.PlayAudioClip("Click01");
        }
        
        public static void PlayAudioClipClick02()
        {
            SoundManager.Instance.PlayAudioClip("Click02");
        }
    }
}