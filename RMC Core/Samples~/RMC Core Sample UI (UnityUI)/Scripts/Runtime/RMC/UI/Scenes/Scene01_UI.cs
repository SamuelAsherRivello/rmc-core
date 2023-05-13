using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.Samples.UI.View;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.UI.Scenes
{
    /// <summary>
    /// Demo of various UI
    /// </summary>
    public class Scene01_UI : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private Scene01_UIView _view;

        private bool _isSampleSettingEnabled = true;

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Populate UI
            _view.TextAreaPanelUI.HeaderTextFieldUI.Text.text = "Header TextFieldUI!";

            string s = "";
            for (int i = 0; i < 30; i++)
            {
                s += $"Here is {i} more \n";
            }
            _view.TextAreaPanelUI.BodyTextAreaUI.Text.text = $"Body TextAreaUI!{s}";
            _view.TextAreaPanelUI.ScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
            
            _view.TextInputFieldUI.InputField.text = "TextInputFieldUI!";
            _view.TextFieldUI.Text.text = "TextFieldUI!";
            _view.TextAreaUI.Text.text = "TextAreaUI!";
            _view.ButtonUI.Text.text = "ButtonUI!";
  
            
            // Observe UI
            _view.ButtonUI.Button.onClick.AddListener(() => ButtonUI_OnClicked());

            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
            _view.ButtonUI.IsInteractable = true;
            
            UIHelper.SetButtonText(
                _view.ButtonUI.Button, 
                _isSampleSettingEnabled,
                $"Deauthenticate",
                $"Authenticate"
                );
        }
                
        //  Event Handlers --------------------------------
        private async UniTask ButtonUI_OnClicked()
        {
            _isSampleSettingEnabled = !_isSampleSettingEnabled;
            
            await RefreshUIAsync();
        }
    }
}

