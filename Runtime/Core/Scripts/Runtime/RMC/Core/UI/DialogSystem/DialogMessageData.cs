namespace RMC.Core.UI.DialogSystem
{
    public class DialogMessageData
    {
        public string Sending;
        public string Sent;
        public string Awaiting;

        public DialogMessageData(string sending, string sent, string awaiting)
        {
            Sending = sending;
            Sent = sent;
            Awaiting = awaiting;
        }
    }
}