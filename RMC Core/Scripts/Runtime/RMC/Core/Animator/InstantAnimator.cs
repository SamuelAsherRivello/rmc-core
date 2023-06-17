using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InstAnime;

namespace RMC.Core.Animator
{
    /// <summary>
    /// RMC Wrapper for 3rd party tooling
    /// </summary>
    public class InstantAnimator
    {
        /// <summary>
        /// Animate any value programmatically
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="setter"></param>
        /// <param name="ct"></param>
        /// <param name="updateMode"></param>
        /// <param name="animator"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static UniTask AnimateAsync<TValue>(TValue from, TValue to, float duration,
            Action<TValue> setter, CancellationToken ct, UpdateMode updateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> animator = null)
        {
            return InstAnime.InstantAnimator.AnimateAsync<TValue>(from, to, duration, setter, ct, updateMode, animator);
        }
    }

}