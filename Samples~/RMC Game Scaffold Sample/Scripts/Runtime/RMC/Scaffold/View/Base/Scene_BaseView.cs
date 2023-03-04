using RMC.Core.Components;
using RMC.Core.UI.DialogSystem;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;
using UnityEngine.Serialization;

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
        public DialogSystemView DialogSystemView { get { return _dialogSystemView;} }
        public IVisualTransitionTarget SceneVisualTransitionTargetPrefab { get { return _sceneVisualTransitionTargetPrefab;} }
        public VisualTransition SceneVisualTransition { get { return _sceneVisualTransition;} }
        public SceneController SceneController { get { return _sceneController;} }
        
        //  Fields ----------------------------------------
        [Header("Base")]
        [SerializeField]
        private DialogSystemView _dialogSystemView;

        [SerializeReference]
        private VisualTransitionTarget _sceneVisualTransitionTargetPrefab;

        [SerializeField]
        private VisualTransition _sceneVisualTransition;
        private SceneController _sceneController = new SceneController();
        
        //  Unity Methods  --------------------------------
        protected virtual async void Start()
        {
            _sceneController.Initialize(_sceneVisualTransition, _sceneVisualTransitionTargetPrefab);
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}