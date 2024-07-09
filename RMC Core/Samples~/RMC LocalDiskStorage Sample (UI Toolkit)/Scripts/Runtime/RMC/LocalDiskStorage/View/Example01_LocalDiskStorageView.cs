using UnityEngine;
using UnityEngine.UIElements;

#pragma warning disable CS1998
namespace RMC.Core.Samples.LocalDiskStorageView
{
    /// <summary>
    /// UI for <see cref="Example01_LocalDiskStorage"/>
    /// </summary>
    public class Example01_LocalDiskStorageView : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public Label HeaderTitleLabel { get { return _uiDocument.rootVisualElement.Q<Label>("HeaderTitleLabel");} }
        public TextField DetailsTextField { get { return _uiDocument.rootVisualElement.Q<TextField>("DetailsTextField");} }
        public TextField OutputTextField { get { return _uiDocument.rootVisualElement.Q<TextField>("OutputTextField");} }
        public Button Button01 { get { return _uiDocument.rootVisualElement.Q<Button>("Button01");} }
        public Button Button02 { get { return _uiDocument.rootVisualElement.Q<Button>("Button02");} }
        public Button Button03 { get { return _uiDocument.rootVisualElement.Q<Button>("Button03");} }

        //  Fields ----------------------------------------
        [SerializeField]
        private UIDocument _uiDocument;

        
        //  Unity Methods  --------------------------------
        protected async void Awake()
        {
        }
        
        
        protected async void Start()
        {
            
        }

        
        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}