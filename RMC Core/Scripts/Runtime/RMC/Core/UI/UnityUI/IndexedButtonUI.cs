using System;
using System.Collections.Generic;
using RMC.Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Core.UI.UnityUI
{
    /// <summary>
    /// Powerful wrapper recommended for all uses of <see cref="Button"/>
    /// when multiple values are required.
    /// </summary>
    public class IndexedButtonUI : MonoBehaviour, 
        IIsVisible, IIsInteractable
    {
      
        //  Properties  ---------------------------------------
        public ButtonUI ButtonUI { get { return _buttonUI;}}
        public TextAreaUI TextAreaUI { get { return _textAreaUI;}}

        public List<Dropdown.OptionData> options
        {
            get { return _optionsDataList.options; }
            set { _optionsDataList.options = value; RefreshUI(); }
        }
        
        
        //Wrap
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if (value >= 0 && value < _optionsDataList.options.Count)
                {
                    _index = value;
                    RefreshUI();
                }
            }
        }
        
        public bool IsVisible
        {
            get
            {
                return _buttonUI.IsVisible;
            }
            set
            {
                if (_buttonUI != null)
                {
                    _buttonUI.IsVisible = value;
                }
                if (_textAreaUI != null)
                {
                    _textAreaUI.IsVisible = value;
                }
            }
        }
      
        public bool IsInteractable
        {
            get
            {
                return _buttonUI.IsInteractable;
            }
            set
            {
                if (_buttonUI != null)
                {
                    _buttonUI.IsInteractable = value;
                }
                if (_textAreaUI != null)
                {
                    _textAreaUI.IsInteractable = value;
                }
            }
        }
      
        //  Fields  ---------------------------------------
        [SerializeField] 
        private ButtonUI _buttonUI = null;
      
        [SerializeField] 
        private TextAreaUI _textAreaUI = null;

        [SerializeField]
        private Dropdown.OptionDataList _optionsDataList = new Dropdown.OptionDataList();

        private int _index = 0;
        
        //  Methods  --------------------------------------
        protected void Start()
        {
            Index = 0;
        }
        
        //  Methods  --------------------------------------
        public void NextIndex()
        {
            int nextIndex = _index + 1;

            if (nextIndex > _optionsDataList.options.Count -1)
            {
                nextIndex = 0;
            }

            Index = nextIndex;
        }
        
        private void RefreshUI()
        {
            try
            {
                _textAreaUI.Text.text = _optionsDataList.options[_index].text;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
        }
    }
}