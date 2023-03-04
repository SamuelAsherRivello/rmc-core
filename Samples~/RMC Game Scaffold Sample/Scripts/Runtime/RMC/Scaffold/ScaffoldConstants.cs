
using RMC.Core.UI.DialogSystem;

namespace RMC.Core.Scaffold
{
    /// <summary>
    /// Constant values
    /// </summary>
    public static class ScaffoldConstants
    {
        public const string PathMenuItemAssetsCompanyProject = "Assets/" + CompanyName + "/" + ProjectName;
        public const string PathMenuItemWindowCompanyProject = "Window/" + CompanyName + "/" + ProjectName;
        public const string CompanyName = "RMC";
        public const string ProjectName = "Scaffold";
        public const int PriorityMenuItem_Examples = 1;
        
        public static readonly DialogMessageData ReadWriteDialogMessageData = new DialogMessageData(
            "~ <b>{0}</b> ~\n Sending Transaction\n\nCheck your wallet",
            "~ <b>{0}</b> ~\n Sent Transaction\n\nPaste TransactionHash from clipboard to continue",
            "~ <b>{0}</b> ~\n Awaiting Transaction"
        );

        public static readonly DialogMessageData ReadDialogMessageData = new DialogMessageData(
            "~ <b>{0}</b> ~\n Sending Transaction",
            "~ <b>{0}</b> ~\n Sent Transaction",
            "~ <b>{0}</b> ~\n Awaiting Transaction"
        );

        public static readonly DialogMessageData AuthenticationMessageData = new DialogMessageData(
            "~ <b>Authenticating</b> ~\n Sending Transaction",
            "~ <b>Authenticating</b> ~\n Sent Transaction\n\nPaste SignatureHash from clipboard to continue",
            "~ <b>Authenticating</b> ~\n Awaiting Transaction"
        );
        
        public static readonly DialogMessageData DeauthenticationMessageData = new DialogMessageData(
            "~ <b>Deauthenticating</b> ~\n Sending Transaction",
            "~ <b>Deauthenticating</b> ~\n Sent Transaction",
            "~ <b>Deauthenticating</b> ~\n Awaiting Transaction"
        );
    }
}