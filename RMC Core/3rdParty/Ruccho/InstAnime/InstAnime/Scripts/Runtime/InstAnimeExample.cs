using System.Threading;
using UnityEngine;

namespace InstAnime
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------

    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class InstAnimeExample : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------

        //  Fields ----------------------------------------


        //  Unity Methods  --------------------------------
        protected async void Start()
        {
            float fromValue = 1;
            float toValue = 10;
            float duration = 2;
            CancellationToken cancellationToken = new CancellationToken();

            await InstantAnimator.AnimateAsync<float>(
                fromValue, 
                toValue, 
                duration, 
                (nextValue) =>
                {
                    Debug.Log(nextValue);
                }, 
                cancellationToken, 
                UpdateMode.Unscaled,
                new DegreeValueAnimator());
        }

        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
    }
}