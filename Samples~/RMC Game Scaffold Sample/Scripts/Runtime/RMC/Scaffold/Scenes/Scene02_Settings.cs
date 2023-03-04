using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.Scaffold.View;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Scaffold.Scenes
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

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Populate UI
            _view.HeaderTextFieldUI.Text.text = "Settings";
            _view.BackButtonUI.Text.text = "Back";
            
            // Observe UI
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
            
            CoreHelper.SetButtonText(
                _view.ToggleSetting01ButtonUI.Button, 
                ScaffoldSingleton.Instance.IsSetting01Enabled,
                $"Setting 01 = True",
                $"Setting 01 = False"
                );
            
            CoreHelper.SetButtonText(
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

            ScaffoldSingleton.Instance.IsSetting01Enabled = !ScaffoldSingleton.Instance.IsSetting01Enabled;
            
            await RefreshUIAsync();
        }
        
        private async UniTask ToggleSetting02ButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();

            ScaffoldSingleton.Instance.IsSetting02Enabled = !ScaffoldSingleton.Instance.IsSetting02Enabled;
           
            await RefreshUIAsync();
        }
        
        private async UniTask BackButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick02();

            _view.SceneController.LoadScene("Scene01_Intro");
        }
    }
}

