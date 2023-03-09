using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.UI.Samples.View;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.UI.Samples.Scenes
{
    /// <summary>
    /// Controller for <see cref="Scene01_UIView"/>
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
            _view.TextPanelUI.HeaderTextFieldUI.Text.text = "Header TextFieldUI!";
            _view.TextPanelUI.BodyTextAreaUI.Text.text = "Body TextAreaUI!";
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

