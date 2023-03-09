using System.Collections.Generic;
using System.Linq;
using RMC.Core.Components;
using RMC.Core.Interfaces;
using RMC.Core.UI.DialogSystem;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;

#pragma warning disable CS1998
namespace RMC.Core.Scaffold.View
{
    /// <summary>
    /// UI parent
    /// </summary>
    public class Scene_BaseView : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public DialogSystem DialogSystem { get { return _dialogSystem;} }
        public IVisualTransitionTarget SceneVisualTransitionTargetPrefab { get { return _sceneVisualTransitionTargetPrefab;} }
        public VisualTransition SceneVisualTransition { get { return _sceneVisualTransition;} }
        public SceneController SceneController { get { return _sceneController;} }
        
        //  Fields ----------------------------------------
        [Header("Base")]
        [SerializeField]
        private DialogSystem _dialogSystem;

        [SerializeReference]
        private VisualTransitionTarget _sceneVisualTransitionTargetPrefab;

        [SerializeField]
        private VisualTransition _sceneVisualTransition;
        private SceneController _sceneController = new SceneController();
        
        //  Unity Methods  --------------------------------
        protected virtual async void Awake()
        {
            // Turn UI elements invisible so we have less boilerplate.
            // Each scene must set visible as needed
            List<IIsVisible> components = gameObject.GetComponentsInChildren<Component>(true)
                .OfType<IIsVisible>().ToList();
            
            foreach (IIsVisible iIsVisible in components)
            {
                iIsVisible.IsVisible = false;  
            }
        }

        
        protected virtual async void Start()
        {
            _sceneController.Initialize(_sceneVisualTransition, _sceneVisualTransitionTargetPrefab);
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}