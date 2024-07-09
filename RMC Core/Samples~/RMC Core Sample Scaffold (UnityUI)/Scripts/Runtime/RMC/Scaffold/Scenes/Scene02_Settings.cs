using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.Samples.Scaffold.View;
using RMC.Core.UI.UnityUI.DialogSystem;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.Scaffold.Scenes
{
    /// <summary>
    /// Controller for <see cref="Scene02_SettingsView"/>
    /// </summary>
    public class Scene02_Settings : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private Scene02_SettingsView _view;
        
        private static readonly DialogData ToggleSettingDialogMessageData = new DialogData(
            "~ <b>{0}</b> ~\n Pending...",
            "~ <b>{0}</b> ~\n Complete.",
            "~ <b>{0}</b> ~\n Refreshing..."
        );

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Header
            _view.HeaderTextFieldUI.IsVisible = true;
            _view.HeaderTextFieldUI.Text.text = "Settings";
            
            // Body
            
            
            // Footer
            _view.BackButtonUI.IsVisible = true;
            _view.ToggleSetting01ButtonUI.IsVisible = true;
            _view.ToggleSetting02ButtonUI.IsVisible = true;
            
            _view.BackButtonUI.Text.text = "Back";
            
            _view.ToggleSetting01ButtonUI.Button.onClick.AddListener(() => ToggleSetting01ButtonUI_OnClicked());
            _view.ToggleSetting02ButtonUI.Button.onClick.AddListener(() => ToggleSetting02ButtonUI_OnClicked());
            _view.BackButtonUI.Button.onClick.AddListener( () => BackButtonUI_OnClicked());

            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
            _view.ToggleSetting01ButtonUI.IsInteractable = true;
            _view.ToggleSetting02ButtonUI.IsInteractable = true;
            _view.BackButtonUI.IsInteractable = true;
            
            UIHelper.SetButtonText(
                _view.ToggleSetting01ButtonUI.Button, 
                ScaffoldSingleton.Instance.IsSetting01Enabled,
                $"Setting 01 = True",
                $"Setting 01 = False"
                );
            
            UIHelper.SetButtonText(
                _view.ToggleSetting02ButtonUI.Button, 
                ScaffoldSingleton.Instance.IsSetting02Enabled,
                $"Setting 02 = True",
                $"Setting 02 = False"
            );
        }
                
        //  Event Handlers --------------------------------
        private async UniTask ToggleSetting01ButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();

            // Demo - Change setting instantly
            ScaffoldSingleton.Instance.IsSetting01Enabled = !ScaffoldSingleton.Instance.IsSetting01Enabled;
            
            await RefreshUIAsync();
        }
        
        private async UniTask ToggleSetting02ButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();

            ScaffoldHelper.ShowDialogAsync(
                _view.DialogSystem,
                "Toggle Settings 02",
                ToggleSettingDialogMessageData,
                async () =>
                {
                    // Demo - Change setting with a user-facing dialog to provide nice feedback of process
                    ScaffoldSingleton.Instance.IsSetting02Enabled = !ScaffoldSingleton.Instance.IsSetting02Enabled;
                },
                async () =>
                {
                    await RefreshUIAsync();
                });
           
        }
        
        private async UniTask BackButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick02();

            _view.SceneController.LoadScene("Scene01_Intro");
        }
    }
}

