using System;
using Cysharp.Threading.Tasks;
using RMC.Core.Exceptions;
using RMC.Core.Interfaces;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RMC.Core.Components
{
	/// <summary>
	/// Event for <see cref="SceneController"/>
	/// </summary>
	public class SceneControllerUnityEvent : UnityEvent<SceneController, string, string> {}
	
	/// <summary>
	/// Determines "was the active scene loaded directly?
	/// * (true) Loaded directly
	/// * (false) Loaded indirectly at runtime
	/// </summary>
	public class SceneController 
	{
		// Events -----------------------------------------
		public readonly SceneControllerUnityEvent OnSceneLoadingEvent = new SceneControllerUnityEvent();
		public readonly SceneControllerUnityEvent OnSceneLoadedEvent = new SceneControllerUnityEvent();
		
		public bool IsInitialized { get; private set; }
		
		// Properties -------------------------------------

		// Fields -----------------------------------------
		private static string _sceneNameLoadedDirectly = "";
		private static string _sceneNamePrevious = "";
		private VisualTransition _visualTransition;
		private IVisualTransitionTarget _visualTransitionTargetPrefab;
		private IVisualTransitionTarget _visualTransitionTargetInstance;

		// Unity Methods ----------------------------------
		protected void Awake ()
		{
			_sceneNameLoadedDirectly = SceneManager.GetActiveScene().name;
		}
		
		protected void Start ()
		{
			SceneManager.sceneLoaded -= SceneManager_OnSceneLoaded;
			SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
		}

		public void Initialize(VisualTransition visualTransition, IVisualTransitionTarget visualTransitionTargetPrefab)
		{
			if (IsInitialized) return;
			IsInitialized = true;
			_visualTransition = visualTransition;
			_visualTransitionTargetPrefab = visualTransitionTargetPrefab;
		}
		
		public void Initialize()
		{
			//Must call the other Initialize();
		}

		public void RequireIsInitialized()
		{
			if (!IsInitialized)
			{
				throw new NotInitializedException(this);
			}
		}

		// General Methods --------------------------------
		public bool WasActiveSceneLoadedDirectly()
		{
			return _sceneNameLoadedDirectly == SceneManager.GetActiveScene().name;
		}
		
		public void LoadScenePrevious()
		{
			RequireIsInitialized();
			LoadScene(_sceneNamePrevious);
		}
		
		public async void LoadScene(string sceneName)
		{
			RequireIsInitialized();
			if (string.IsNullOrEmpty(sceneName))
			{
				Debug.LogWarning($"Cannot LoadScene() when sceneName={sceneName}");
				return;
			}

			// BEFORE
			var visualTransitionTargetObject = GameObject.Instantiate(_visualTransitionTargetPrefab as UnityEngine.Object);
			_visualTransitionTargetInstance = visualTransitionTargetObject as IVisualTransitionTarget;
			
			//
			MonoBehaviour visualTransitionTargetMonoBehaviour = visualTransitionTargetObject as MonoBehaviour;
			GameObject visualTransitionTargetGameObject = visualTransitionTargetMonoBehaviour.gameObject;
			GameObject.DontDestroyOnLoad(visualTransitionTargetGameObject);
			
			
			
			// DURING
			await ApplyTransition(_visualTransitionTargetInstance, async () =>
				{
					await UniTask.WaitForEndOfFrame((MonoBehaviour)_visualTransitionTargetInstance);
					_sceneNamePrevious = SceneManager.GetActiveScene().name;
					OnSceneLoadingEvent.Invoke(this, _sceneNamePrevious, sceneName);
					SceneManager.LoadScene(sceneName);
				});
			
			// AFTER
			GameObject.Destroy(visualTransitionTargetGameObject);
		}
		
		public async UniTask ApplyTransition(IVisualTransitionTarget visualTransitionTarget, Func<UniTask> action)
		{
			await _visualTransition.ApplyVisualTransition(visualTransitionTarget, action);
		}
		
		// Event Handlers ---------------------------------
		private void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			OnSceneLoadedEvent.Invoke(this, _sceneNamePrevious, scene.name);
		}
	}
}
