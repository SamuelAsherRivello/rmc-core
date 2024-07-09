using RMC.Core.Samples.Scaffold.Scenes;
using RMC.Core.UI.UnityUI;
using UnityEngine;

#pragma warning disable CS1998
namespace RMC.Core.Samples.Scaffold.View
{
    /// <summary>
    /// UI for <see cref="Scene02_Settings"/>
    /// </summary>
    public class Scene02_SettingsView : Scene_BaseView
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;} }
        public ButtonUI ToggleSetting01ButtonUI { get { return _toggleSetting01ButtonUI;} }
        public ButtonUI ToggleSetting02ButtonUI { get { return _toggleSetting02ButtonUI;} }
        public ButtonUI BackButtonUI { get { return _backButtonUI;} }

        //  Fields ----------------------------------------
        [Header("Child")]
        [SerializeField]
        private TextFieldUI _headerTextFieldUI;

        [SerializeField]
        private ButtonUI _toggleSetting01ButtonUI;

        [SerializeField]
        private ButtonUI _toggleSetting02ButtonUI;

        [SerializeField]
        private ButtonUI _backButtonUI;

        
        //  Unity Methods  --------------------------------
        protected override async void Awake()
        {
            base.Awake();
        }
        
        
        protected override async void Start()
        {
            base.Start();
        }
        
        
        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}