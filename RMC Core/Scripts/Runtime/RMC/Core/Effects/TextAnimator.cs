using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using RMC.Core.Exceptions;
using RMC.Core.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.Effects
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------
    public class TextAnimatorUnityEvent : UnityEvent<TextAnimator> {}

    public enum DurationMode
    {
        Null,
        
        //Duration value applies to the complete message
        //Good for consistent timing regardless of message length
        DurationMessage,
        
        //Duration value applies to each word
        DurationWord,
        
        //Duration value applies to each character
        DurationCharacter
    }

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class TextAnimator
    {
        //  Events ----------------------------------------
        public TextAnimatorUnityEvent OnPlayStarted = new TextAnimatorUnityEvent();
        public TextAnimatorUnityEvent OnPlayCompleted = new TextAnimatorUnityEvent();
        public TextAnimatorUnityEvent OnStopped = new TextAnimatorUnityEvent();
    
        
        //  Properties ------------------------------------
        public DurationMode DurationMode { get; private set; }
        public bool IsInitialized { get; private set; }
        public bool IsPlaying { get; private set; }
        private System.Func<string, bool, bool> _currentUpdateFunction;

        //  Fields ----------------------------------------


        //  Initialization --------------------------------


        //  Methods ---------------------------------------
        public void Stop()
        {
            if (IsPlaying)
            {
                _currentUpdateFunction = null;
                IsPlaying = false;
                OnStopped.Invoke(this);
            }
        }
        
        public async void Play(
            string message,
            float durationMS, 
            DurationMode durationMode, 
            System.Func<string, bool, bool> updateFunction)
        {
            
            // Store as instance variables
            _currentUpdateFunction = updateFunction;
            DurationMode = durationMode;
            
            //
            string currentMessage = "";
            bool isCurrentUpdateFunctionCompleted = false;
            int tokenIndex = 0;
            char charBetweenTokens = ' ';
            float durationPerTickMS = 0;
            List<string> tokens = new List<string>();
            
            //
            if (IsPlaying)
            {
                Stop();
            }

            IsPlaying = true;
            OnPlayStarted.Invoke(this);

            //
            //Split target text into tokens
            switch (DurationMode)
            {
                case DurationMode.DurationMessage:
                case DurationMode.DurationWord:
                    //Chop it by word
                    tokens = message.Split(charBetweenTokens).ToList();
                    break;
                case DurationMode.DurationCharacter:
                    //Chop it by letter
                    tokens.AddRange(message.Select(c => c.ToString()));
                    break;
                default:
                    SwitchDefaultException.Throw(DurationMode);
                    break;
            }

            // Set duration 
            switch (DurationMode)
            {
                case DurationMode.DurationMessage:
                    durationPerTickMS = durationMS / tokens.Count;
                    break;
                case DurationMode.DurationWord:
                case DurationMode.DurationCharacter:
                    durationPerTickMS = durationMS;
                    break;
                default:
                    SwitchDefaultException.Throw(DurationMode);
                    break;
            }
            do
            {
                //System decides complete
                isCurrentUpdateFunctionCompleted = 
                    currentMessage.Length >= message.Length;
                
                //Optional: User decides complete
                if (_currentUpdateFunction == null || !IsPlaying)
                {
                    Stop();
                    return;
                }
                isCurrentUpdateFunctionCompleted = _currentUpdateFunction.Invoke(currentMessage, isCurrentUpdateFunctionCompleted);

                if (!isCurrentUpdateFunctionCompleted)
                {
                    switch (DurationMode)
                    {
                        case DurationMode.DurationMessage:
                        case DurationMode.DurationWord:
                            currentMessage += tokens[tokenIndex] + charBetweenTokens;
                            break;
                        case DurationMode.DurationCharacter:
                            currentMessage += tokens[tokenIndex];
                            break;
                        default:
                            SwitchDefaultException.Throw(DurationMode);
                            break;
                    }
                    
                
                    tokenIndex += 1;

                    await UniTask.Delay((int)durationPerTickMS);
                }
            } while (!isCurrentUpdateFunctionCompleted);

            OnPlayCompleted.Invoke(this);
        }

        //  Event Handlers --------------------------------
    }
}