using RMC.Core.UI.UnityUI;
using UnityEngine;

#pragma warning disable CS1998
namespace RMC.Core.Samples.Scaffold.View
{
    /// <summary>
    /// UI for <see cref="Scene03_Game"/>
    /// </summary>
    public class Scene03_GameView : Scene_BaseView
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;} }
        public ButtonUI BackButtonUI { get { return _backButtonUI;} }
        public ButtonUI Invisible01ButtonUI { get { return _invisible01ButtonUI;} }
        public ButtonUI Invisible02ButtonUI { get { return _invisible02ButtonUI;} }

        //  Fields ----------------------------------------
        [Header("Child")]
        [SerializeField]
        private TextFieldUI _headerTextFieldUI;

        [SerializeField]
        private ButtonUI _backButtonUI;

        [SerializeField]
        private ButtonUI _invisible01ButtonUI;

        [SerializeField]
        private ButtonUI _invisible02ButtonUI;

        
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