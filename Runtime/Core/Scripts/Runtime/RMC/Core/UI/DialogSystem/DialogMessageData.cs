namespace RMC.Core.UI.DialogSystem
{
    /// <summary>
    /// Stores prompt display text
    /// </summary>
    public class DialogMessageData
    {
        public string SendingMessage;
        public string SentMessage;
        public string AwaitingMessage;

        public DialogMessageData(
            string sendingMessage, 
            string sentMessage, 
            string awaitingMessage)
        {
            SendingMessage = sendingMessage;
            SentMessage = sentMessage;
            AwaitingMessage = awaitingMessage;
        }
    }
}