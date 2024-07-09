
using System.Reflection;
using NUnit.Framework;
using RMC.Core.UI.UnityUI;
using RMC.Core.Utilities;
using TMPro;
using UnityEngine;

namespace RMC.Core.Samples.UI.UnityUI
{
    public class TextFieldUITest
    {
        [Test]
        public void Text_ValueIsMessage_WhenSetToMessage()
        {
            // Arrange
            string message = "hello world!";
            GameObject go = new GameObject();
            
            // Hack - Reconstruct with code, since we choose not to test the Prefab version
            TextFieldUI textFieldUI = go.AddComponent<TextFieldUI>();
            TMP_Text tmp_Text = textFieldUI.gameObject.AddComponent<TextMeshProUGUI>();
            ReflectionUtility.SetFieldValue<TextFieldUI>(textFieldUI, "_text", tmp_Text,
                BindingFlags.Instance | BindingFlags.NonPublic);
            
            // Act
            textFieldUI.Text.text = message;

            // Assert
            Assert.That(textFieldUI.Text.text, Is.EqualTo(message));
        }

    }
}
