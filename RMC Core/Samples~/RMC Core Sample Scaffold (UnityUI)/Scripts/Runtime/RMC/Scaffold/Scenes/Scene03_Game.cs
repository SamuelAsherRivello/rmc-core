using Cysharp.Threading.Tasks;
using RMC.Core.Samples.Scaffold.View;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.Scaffold.Scenes
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

        [SerializeField] 
        private Player _player;
        
        private bool _isAuthenticated;
        

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Header
            _view.HeaderTextFieldUI.IsVisible = true;
            _view.HeaderTextFieldUI.Text.text = "Game";
            
            // Body
            
            // Footer
            _view.BackButtonUI.IsVisible = true;
            _view.BackButtonUI.Text.text = "Back";
            
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

