using Cysharp.Threading.Tasks;
using RMC.Core.Components.Attributes;
using RMC.Core.Data.Types.Storage;
using UnityEngine;
using UnityEngine.UIElements;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.LocalDiskStorageView
{
    [CustomFilePath("LocalDiskStorageDataSample", CustomFilePathLocation.PersistentDataPath)]
    public class LocalDiskStorageDataSample
    {
        [SerializeField] 
        public int Value = 0;
    }
    
    /// <summary>
    /// Controller for <see cref="Example01_LocalDiskStorageView"/>
    /// </summary>
    public class Example01_LocalDiskStorage : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public Button LoadButton { get { return _view.Button01;} }
        public Button SaveButton { get { return _view.Button02;} }
        public Button IncrementButton { get { return _view.Button03;} }

        //  Fields ----------------------------------------
        [SerializeField] 
        private Example01_LocalDiskStorageView _view;

        private LocalDiskStorageDataSample _localDiskStorageDataSample;

        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            // Header
            _view.HeaderTitleLabel.text = "Local Disk Storage Sample";
            
            // Body
            _view.DetailsTextField.label = "Details";

            if (LocalDiskStoragePlayMode.Instance.IsSupportedOnCurrentPlatform())
            {
                _view.DetailsTextField.value = "* Load data from disk.\n* Save data to disk.\n* Increment data.\n";
            }
            else
            {
                _view.DetailsTextField.value = LocalDiskStoragePlayMode.NotSupportedWarning;
            }
          
            //
            _view.OutputTextField.label = "Output";
            _view.OutputTextField.value = "";
            
            // Footer
            LoadButton.text = "Load Data";
            SaveButton.text = "Save Data";
            IncrementButton.text = "Update Data";
            //
            LoadButton.clicked += LoadButton_OnClicked;
            SaveButton.clicked += SaveButton_OnClicked;
            IncrementButton.clicked += IncrementButton_OnClicked;

            await RefreshUIAsync();
            LoadButton_OnClicked();
        }



        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
            bool hasData = LocalDiskStoragePlayMode.Instance.Has<LocalDiskStorageDataSample>();
            
            if (hasData && _localDiskStorageDataSample != null)
            {
                _view.OutputTextField.value = _localDiskStorageDataSample.Value.ToString();
            }
            else
            {
                _view.OutputTextField.value = "No data found.";
            }
            
            LoadButton.SetEnabled(hasData);
            SaveButton.SetEnabled(true);
            IncrementButton.SetEnabled(hasData);
        }
                
        //  Event Handlers --------------------------------
        private async void LoadButton_OnClicked()
        {
            bool hasData = LocalDiskStoragePlayMode.Instance.Has<LocalDiskStorageDataSample>();

            if (hasData)
            {
                _localDiskStorageDataSample = 
                    LocalDiskStoragePlayMode.Instance.Load<LocalDiskStorageDataSample>();
            }
            
            
            await RefreshUIAsync();
        }
        
        private async void SaveButton_OnClicked()
        {
            if (_localDiskStorageDataSample == null)
            {
                _localDiskStorageDataSample = new LocalDiskStorageDataSample();
            }
            
            LocalDiskStoragePlayMode.Instance.Save<LocalDiskStorageDataSample>(_localDiskStorageDataSample);
            
            await RefreshUIAsync();
        }
        
        private async void IncrementButton_OnClicked()
        {
            if (_localDiskStorageDataSample != null)
            {
                _localDiskStorageDataSample.Value++;
            }
            
            await RefreshUIAsync();
        }
    }
}

