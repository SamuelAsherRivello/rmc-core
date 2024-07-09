using Cysharp.Threading.Tasks;
using RMC.Core.UI.UnityUI;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.UI.Scenes
{
    /// <summary>
    /// Demo of <see cref="IndexedButtonUI"/>
    /// </summary>
    public class Scene03_IndexedButtonUI : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private IndexedButtonUI _view;

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Populate UI
            _view.ButtonUI.Text.text = "My Setting";
            
            // Observe UI
            _view.ButtonUI.Button.onClick.AddListener(() => ButtonUI_OnClicked());

            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {

        }
                
        //  Event Handlers --------------------------------
        private async UniTask ButtonUI_OnClicked()
        {
            _view.NextIndex();
        }
    }
}

