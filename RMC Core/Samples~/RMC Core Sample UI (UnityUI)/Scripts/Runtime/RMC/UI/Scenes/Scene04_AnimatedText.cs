using Cysharp.Threading.Tasks;
using DG.Tweening;
using RMC.Core.Effects;
using TMPro;
using UnityEngine;

#pragma warning disable CS4014, CS1998
namespace RMC.Core.Samples.UI.Scenes
{
    /// <summary>
    /// Demo of Animated Text
    /// </summary>
    public class Scene04_AnimatedText : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField] 
        private TMP_Text _text;

        [SerializeField] 
        private string _message = "Hello World!";

        private bool _isAnimatedText = false;
        private int _animatedDurationMS = 1000;
        private DurationMode _animatedDurationMode = DurationMode.Null;
        private TextAnimator _textAnimator;
        
        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            _textAnimator = new TextAnimator();
            _textAnimator.OnPlayStarted.AddListener(TextAnimator_OnPlayed);
            _textAnimator.OnPlayCompleted.AddListener(TextAnimator_OnPlayCompleted);
            _textAnimator.OnStopped.AddListener(TextAnimator_OnStopped);

            await RefreshUIAsync();
        }



        protected async void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                _isAnimatedText = false;
                await RefreshUIAsync();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _isAnimatedText = true;
                _animatedDurationMS = 3000;
                _animatedDurationMode = DurationMode.DurationMessage;
                await RefreshUIAsync();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _isAnimatedText = true;
                _animatedDurationMS = 200;
                _animatedDurationMode = DurationMode.DurationWord;
                await RefreshUIAsync();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _isAnimatedText = true;
                _animatedDurationMS = 10;
                _animatedDurationMode = DurationMode.DurationCharacter;
                await RefreshUIAsync();
            }
        }

        //  Methods ---------------------------------------
        private async UniTask RefreshUIAsync()
        {
            // Show nothing, briefly, to visualize the 'refresh'
            _text.text = "";
            await UniTask.Delay(250);
            
            if (_textAnimator.IsPlaying)
            {
                //Optional: Call Stop() to stop it
                _textAnimator.Stop();
            }
            
            // Show something
            if (!_isAnimatedText)
            {
                //Not Animated
                _text.text = _message;
            }
            else
            {
                //Animated
                _textAnimator.Play(
                    _message, 
                    _animatedDurationMS,
                    _animatedDurationMode,
                    (string message, bool isComplete) =>
                    {
                        _text.text = message;
                        
                        //Optional: Return false to stop it
                        return isComplete;
                    });
            }
        }
                
        //  Event Handlers --------------------------------
        private void TextAnimator_OnPlayed(TextAnimator textAnimator)
        {
            Debug.Log($"TextAnimator_OnPlayed() {textAnimator.DurationMode.ToString()}.");
        }
        
        private void TextAnimator_OnPlayCompleted(TextAnimator textAnimator)
        {
            Debug.Log($"TextAnimator_OnPlayCompleted()");
        }
        
        private void TextAnimator_OnStopped(TextAnimator textAnimator)
        {
            Debug.Log($"TextAnimator_OnStopped()");
        }
    }
}

