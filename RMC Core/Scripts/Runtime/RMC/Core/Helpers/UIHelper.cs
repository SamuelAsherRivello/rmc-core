using RMC.Core.UI.UnityUI;
using TMPro;
using UnityEngine.UI;

namespace RMC.Core.Helpers
{
    /// <summary>
    /// Helper Methods
    /// </summary>
    public static class UIHelper
    {

        // Fields -----------------------------------------


        // General Methods --------------------------------
        
        public static void SetButtonText(Button button, bool isActive, string activeText, string notActiveText)
        {
            if (isActive)
            {
                SetButtonText(button, activeText);
            }
            else
            {
                SetButtonText(button, notActiveText);
            }
        }

        public static void SetButtonText(Button button, string text)
        {
            TMP_Text tmp_Text = button.GetComponentInChildren<TMP_Text>();
            tmp_Text.text = text;
        }
        
        public static void SetTextAreaUIText(TextAreaUI textAreaUI, bool isActive, string activeText, string inactiveText)
        {
            TMP_Text tmp_Text = textAreaUI.GetComponentInChildren<TMP_Text>();

            if (isActive)
            {
                tmp_Text.text = activeText;
            }
            else
            {
                tmp_Text.text = inactiveText;
            }
        }
    }
}