using RMC.Core.Interfaces;
using RMC.Core.Extensions;
using RMC.Core.UI.UnityUI.VisualTransitions;
using UnityEngine;

namespace RMC.Core.UI.UnityUI.DialogSystem
{
	/// <summary>
	/// Powerful wrapper recommended for all uses of "Loading" messaging.
	/// </summary>
	public class ScreenMessageUI : MonoBehaviour, 
		IIsVisible, IIsInteractable, IAlpha,
		IVisualTransitionTarget
	{
		// Properties -------------------------------------
		public bool IsVisible
		{
			get
			{
				return Mathf.Approximately(_canvasGroup.alpha, 1);
			}
			set
			{
				if (value)
				{
					_canvasGroup.alpha = 1;
				}
				else
				{
					_canvasGroup.alpha = 0;
				}
			}
		}
	
		public bool IsInteractable
		{
			get
			{
				return _canvasGroup.GetIsInteractable();
			}
			set
			{
				if (_canvasGroup != null)
				{
					_canvasGroup.SetIsInteractable(value);
				}
			}
	}
		
		public float Alpha
		{
			get
			{
				return _canvasGroup.alpha;
			}
			set
			{
				_canvasGroup.alpha = value;
			}
		}
		
		public bool IsBlocksRaycasts
		{
			get
			{
				return _canvasGroup.blocksRaycasts;
			}
			set
			{
				_canvasGroup.blocksRaycasts = value;
			}
		}
		
		public TextFieldUI TextFieldUI { get { return _textFieldUI;}}

		public GameObject Panel { get { return _panel; }}

		// Fields -----------------------------------------
		[SerializeField]
		private TextFieldUI _textFieldUI = null;
		
		[SerializeField]
		private CanvasGroup _canvasGroup = null;
		
		[SerializeField] 
		private GameObject _panel = null;

		
		// Unity Methods ----------------------------------
		
		
		// General Methods --------------------------------
		
		
		// Event Handlers ---------------------------------
		
	}
}
