using Cysharp.Threading.Tasks;
using RMC.Core.Scaffold.View;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Scaffold.Scenes
{
    /// <summary>
    /// Controller for <see cref="Scene03_GameView"/>
    /// </summary>
    public class Scene03_Game : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private Scene03_GameView _view;
        private bool _isAuthenticated;
        

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Populate UI
            _view.HeaderTextFieldUI.Text.text = "Game";
            _view.BackButtonUI.Text.text = "Back";
            _view.Invisible01ButtonUI.IsVisible = false;
            _view.Invisible02ButtonUI.IsVisible = false;
            
            // Observe UI
            _view.BackButtonUI.Button.onClick.AddListener(() => BackButtonUI_OnClicked());

            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
      
        }
                
        //  Event Handlers --------------------------------
        
        private async UniTask BackButtonUI_OnClicked()
        {
            ScaffoldHelper.PlayAudioClipClick02();

            _view.SceneController.LoadScene("Scene01_Intro");
        }
    }
}

