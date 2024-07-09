namespace RMC.Core.UI.UnityUI.DialogSystem
{
    /// <summary>
    /// Stores prompt display text
    /// </summary>
    public class DialogData
    {
        public string SendingMessage;
        public string SentMessage;
        public string AwaitingMessage;
        
        public float DelaySecondsSending = 1;
        public float DelaySecondsSent = 1;
        public float DelaySecondsAwaiting = 1;
        

        public DialogData(
            string sendingMessage, 
            string sentMessage, 
            string awaitingMessage)
        {
            SendingMessage = sendingMessage;
            SentMessage = sentMessage;
            AwaitingMessage = awaitingMessage;
        }

        public DialogData(
            string sendingMessage, 
            string sentMessage, 
            string awaitingMessage,
            float delaySecondsSending, 
            float delaySecondsSent, 
            float delaySecondsAwaiting)
        {
            SendingMessage = sendingMessage;
            SentMessage = sentMessage;
            AwaitingMessage = awaitingMessage;
            DelaySecondsSending = delaySecondsSending;
            DelaySecondsSent = delaySecondsSent;
            DelaySecondsAwaiting = delaySecondsAwaiting;
        }
    }
}