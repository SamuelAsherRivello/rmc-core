using RMC.Core.Scaffold.Scenes;
using RMC.Core.UI;
using UnityEngine;

#pragma warning disable CS1998
namespace RMC.Core.Scaffold.View
{
    /// <summary>
    /// UI for <see cref="Scene01_Intro"/>
    /// </summary>
    public class Scene01_IntroView : Scene_BaseView
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;} }
        public ButtonUI AuthenticateButtonUI { get { return _authenticateButtonUI;} }
        public ButtonUI PlayGameButtonUI { get { return _playGameButtonUI;} }
        public ButtonUI SettingsButtonUI { get { return _settingsButtonUI;} }

        //  Fields ----------------------------------------
        [Header("Child")]
        [SerializeField]
        private TextFieldUI _headerTextFieldUI;

        [SerializeField]
        private ButtonUI _authenticateButtonUI;

        [SerializeField]
        private ButtonUI _playGameButtonUI;

        [SerializeField]
        private ButtonUI _settingsButtonUI;

        
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