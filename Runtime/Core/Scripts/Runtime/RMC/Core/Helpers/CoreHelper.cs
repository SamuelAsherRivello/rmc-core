using TMPro;
using UnityEngine.UI;

namespace RMC.Core.Helpers
{
    /// <summary>
    /// Helper Methods
    /// </summary>
    public static class CoreHelper
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
    }
}