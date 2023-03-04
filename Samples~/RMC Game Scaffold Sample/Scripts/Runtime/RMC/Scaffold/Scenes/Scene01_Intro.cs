using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.Scaffold.View;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Scaffold.Scenes
{
    /// <summary>
    /// Controller for <see cref="Scene01_IntroView"/>
    /// </summary>
    public class Scene01_Intro : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private Scene01_IntroView _view;
        

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Populate UI
            _view.HeaderTextFieldUI.Text.text = "Intro";
            _view.AuthenticateButtonUI.Text.text = "Authenticate";
            _view.PlayGameButtonUI.Text.text = "Play Game";
            _view.SettingsButtonUI.Text.text = "Settings";
            
            // Observe UI
            _view.AuthenticateButtonUI.Button.onClick.AddListener(() => AuthenticateButtonUI_OnClicked());
            _view.PlayGameButtonUI.Button.onClick.AddListener(() => PlayGameButtonUI_OnClicked());
            _view.SettingsButtonUI.Button.onClick.AddListener( () => SettingsButtonUI_OnClicked());
            

            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
            _view.AuthenticateButtonUI.IsInteractable = true;
            _view.PlayGameButtonUI.IsInteractable = ScaffoldSingleton.Instance.IsAuthenticated;
            _view.SettingsButtonUI.IsInteractable = ScaffoldSingleton.Instance.IsAuthenticated;
            
            CoreHelper.SetButtonText(
                _view.AuthenticateButtonUI.Button, 
                ScaffoldSingleton.Instance.IsAuthenticated,
                $"Deauthenticate",
                $"Authenticate"
                );
        }
                
        //  Event Handlers --------------------------------
        private async UniTask AuthenticateButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();
            
            ScaffoldSingleton.Instance.IsAuthenticated = !ScaffoldSingleton.Instance.IsAuthenticated;
            
            await RefreshUIAsync();
        }
        
        
        private async UniTask SettingsButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();
            
            _view.SceneController.LoadScene("Scene02_Settings");
        }
        
        
        private async UniTask PlayGameButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick01();
            
            _view.SceneController.LoadScene("Scene03_Game");
        }
    }
}

