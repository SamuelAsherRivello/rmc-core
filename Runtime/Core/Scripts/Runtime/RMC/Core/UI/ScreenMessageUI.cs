using RMC.Core.Interfaces;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;

namespace RMC.Core.UI
{
	/// <summary>
	/// UI element for a "Loading..." type message
	/// </summary>
	public class ScreenMessageUI : MonoBehaviour, IVisualTransitionTarget
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
