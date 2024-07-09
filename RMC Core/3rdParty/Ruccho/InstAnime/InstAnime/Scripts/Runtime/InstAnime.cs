using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace InstAnime
{
    public abstract class InstantAnimator : IDisposable
    {
        #region Static Members

        static InstantAnimator()
        {
            RegisterDefaultAnimator(new FloatValueAnimator());
            RegisterDefaultAnimator(new DoubleValueAnimator());
            RegisterDefaultAnimator(new ColorValueAnimator());
            RegisterDefaultAnimator(new Vector2ValueAnimator());
            RegisterDefaultAnimator(new Vector3ValueAnimator());
            RegisterDefaultAnimator(new QuaternionValueAnimator());
        }

        /// <summary>
        /// InstantAnimatorが使用するデフォルトのIValueAnimatorを設定する。
        /// この設定はグローバルに共有される。
        /// </summary>
        /// <param name="animator"></param>
        /// <typeparam name="TValue"></typeparam>
        public static void RegisterDefaultAnimator<TValue>(IValueAnimator<TValue> animator)
        {
            AnimatorCache<TValue>.Instance = animator;
        }

        public static bool IsAnimatableByDefault<TValue>() => AnimatorCache<TValue>.Instance != null;

        public static UniTask AnimateAsync<TValue>(TValue from, TValue to, float duration,
            Action<TValue> setter, CancellationToken ct, UpdateMode updateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> animator = null)
        {
            return AnimateAsync<TValue, EaseLinear>(from, to, duration, setter, ct, updateMode, animator);
        }

        public static UniTask AnimateAsync<TValue, TEaser>(TValue from, TValue to, float duration,
            Action<TValue> setter, CancellationToken ct, UpdateMode updateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> animator = null) where TEaser : struct, IEaser
        {
            var easer = new TEaser();
            return AnimateAsync(from, to, duration, setter, easer, ct, updateMode, animator);
        }

        public static async UniTask AnimateAsync<TValue, TEaser>(TValue from, TValue to, float duration,
            Action<TValue> setter, TEaser easer, CancellationToken ct, UpdateMode updateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> animator = null) where TEaser : IEaser
        {
            animator ??= AnimatorCache<TValue>.Instance;
            if (animator == null) throw new InvalidOperationException();

            float time = 0f;
            while (time < duration)
            {
                float t = time / duration;
                float tEase = easer.Ease(t);
                setter(animator.Lerp(from, to, tEase));

                await UniTask.Yield(PlayerLoopTiming.Update, ct);

                time += UpdateModeUtility.GetDeltaTime(updateMode);
            }

            setter(to);
        }

        #endregion

        #region Value Animators

        static class AnimatorCache<TValue>
        {
            public static IValueAnimator<TValue> Instance { get; set; }
        }

        class FloatValueAnimator : IValueAnimator<float>
        {
            public float Lerp(float @from, float to, float t)
            {
                return Mathf.Lerp(from, to, t);
            }
        }

        class DoubleValueAnimator : IValueAnimator<double>
        {
            public double Lerp(double @from, double to, float t)
            {
                return (to - from) * t + from;
            }
        }

        class ColorValueAnimator : IValueAnimator<Color>
        {
            public Color Lerp(Color @from, Color to, float t)
            {
                return Color.Lerp(from, to, t);
            }
        }

        class Vector2ValueAnimator : IValueAnimator<Vector2>
        {
            public Vector2 Lerp(Vector2 @from, Vector2 to, float t)
            {
                return Vector2.Lerp(from, to, t);
            }
        }

        class Vector3ValueAnimator : IValueAnimator<Vector3>
        {
            public Vector3 Lerp(Vector3 @from, Vector3 to, float t)
            {
                return Vector3.Lerp(from, to, t);
            }
        }

        class QuaternionValueAnimator : IValueAnimator<Quaternion>
        {
            public Quaternion Lerp(Quaternion @from, Quaternion to, float t)
            {
                return Quaternion.Slerp(from, to, t);
            }
        }

        #endregion

        public abstract void Dispose();
    }

    /// <summary>
    /// セッターのみを使用するInstantAnimatorの実装。
    /// </summary>
    /// <typeparam name="TValue">アニメーションさせる値の型</typeparam>
    public abstract class InstantAnimatorBase<TValue> : InstantAnimator
    {
        private CancellationTokenSource cancel = default;
        private UpdateMode DefaultUpdateMode { get; }
        private IValueAnimator<TValue> OverridingAnimator { get; }
        public bool IsDisposed { get; private set; } = false;

        public InstantAnimatorBase(UpdateMode defaultUpdateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> overrideAnimator = default)
        {
            DefaultUpdateMode = defaultUpdateMode;
            OverridingAnimator = overrideAnimator;
        }

        private CancellationToken TakeCancellation()
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(InstantAnimator<TValue>));

            cancel?.Cancel();
            cancel = new CancellationTokenSource();

            return cancel.Token;
        }

        public UniTask AnimateAsync(TValue from, TValue to, float duration,
            UpdateMode? updateMode = null)
        {
            var ct = TakeCancellation();
            var um = updateMode ?? DefaultUpdateMode;
            return InstantAnimator.AnimateAsync<TValue>(from, to, duration, SetValue, ct, um, OverridingAnimator);
        }

        public UniTask AnimateAsync<TEaser>(TValue from, TValue to, float duration,
            UpdateMode? updateMode = null) where TEaser : struct, IEaser
        {
            var ct = TakeCancellation();
            var um = updateMode ?? DefaultUpdateMode;
            return InstantAnimator.AnimateAsync<TValue, TEaser>(from, to, duration, SetValue, ct, um,
                OverridingAnimator);
        }

        public UniTask AnimateAsync<TEaser>(TValue from, TValue to, float duration, TEaser easer,
            UpdateMode? updateMode = null) where TEaser : IEaser
        {
            var ct = TakeCancellation();
            var um = updateMode ?? DefaultUpdateMode;
            return InstantAnimator.AnimateAsync(from, to, duration, SetValue, easer, ct, um, OverridingAnimator);
        }

        public abstract void SetValue(TValue value);

        public void CancelCurrentAnimation()
        {
            cancel?.Cancel();
        }

        public sealed override void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            cancel?.Cancel();
        }
    }

    /// <summary>
    /// セッターとゲッターを使用するInstantAnimatorの実装。
    /// アニメーション開始値の指定を省略できる。
    /// </summary>
    /// <typeparam name="TValue">アニメーションさせる値の型</typeparam>
    public abstract class LinkedInstantAnimatorBase<TValue> : InstantAnimatorBase<TValue>
    {
        protected LinkedInstantAnimatorBase(UpdateMode defaultUpdateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> overrideAnimator = default) : base(defaultUpdateMode, overrideAnimator)
        {
        }

        public UniTask AnimateAsync(TValue to, float duration,
            UpdateMode? updateMode = null) => AnimateAsync(GetValue(), to, duration, updateMode);

        public UniTask AnimateAsync<TEaser>(TValue to, float duration,
            UpdateMode? updateMode = null) where TEaser : struct, IEaser =>
            AnimateAsync<TEaser>(GetValue(), to, duration, updateMode);

        public UniTask AnimateAsync<TEaser>(TValue to, float duration, TEaser easer,
            UpdateMode? updateMode = null) where TEaser : IEaser =>
            AnimateAsync<TEaser>(GetValue(), to, duration, easer, updateMode);

        public abstract TValue GetValue();
    }

    /// <summary>
    /// セッターのみを使用するInstantAnimatorの実装。
    /// </summary>
    /// <typeparam name="TValue">アニメーションさせる値の型</typeparam>
    public class InstantAnimator<TValue> : InstantAnimatorBase<TValue>
    {
        protected Action<TValue> Setter { get; }

        public InstantAnimator(Action<TValue> setter, UpdateMode defaultUpdateMode = UpdateMode.Scaled,
            IValueAnimator<TValue> overrideAnimator = default) : base(defaultUpdateMode, overrideAnimator)
        {
            Setter = setter;
        }

        public override void SetValue(TValue value)
        {
            Setter(value);
        }
    }

    /// <summary>
    /// セッターとゲッターを使用するInstantAnimatorの実装。
    /// アニメーション開始値の指定を省略できる。
    /// </summary>
    /// <typeparam name="TValue">アニメーションさせる値の型</typeparam>
    public class LinkedInstantAnimator<TValue> : LinkedInstantAnimatorBase<TValue>
    {
        protected Func<TValue> Getter { get; }
        protected Action<TValue> Setter { get; }

        public LinkedInstantAnimator(Func<TValue> getter, Action<TValue> setter,
            UpdateMode defaultUpdateMode = UpdateMode.Scaled, IValueAnimator<TValue> overrideAnimator = default) : base(
            defaultUpdateMode, overrideAnimator)
        {
            Getter = getter;
            Setter = setter;
        }

        public override void SetValue(TValue value)
        {
            Setter(value);
        }

        public override TValue GetValue()
        {
            return Getter();
        }
    }

    /// <summary>
    /// セッター・ゲッターの第一引数に任意のオブジェクトを渡せるInstantAnimator。
    /// デリゲートに対する変数キャプチャを避けた使い方が可能
    /// </summary>
    /// <typeparam name="TBind"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BindingInstantAnimator<TBind, TValue> : LinkedInstantAnimatorBase<TValue>
    {
        private TBind Binding { get; }

        private Action<TBind, TValue> BindedSetter { get; }
        private Func<TBind, TValue> BindedGetter { get; }

        public BindingInstantAnimator(TBind binding, Func<TBind, TValue> getter, Action<TBind, TValue> setter,
            UpdateMode defaultUpdateMode = UpdateMode.Scaled, IValueAnimator<TValue> overrideAnimator = default) : base(
            defaultUpdateMode, overrideAnimator)
        {
            Binding = binding;
            BindedGetter = getter;
            BindedSetter = setter;
        }

        public override void SetValue(TValue value)
        {
            BindedSetter(Binding, value);
        }

        public override TValue GetValue()
        {
            return BindedGetter(Binding);
        }
    }

    /// <summary>
    /// 指定した型の値をアニメーションさせるための方法を表現する。
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IValueAnimator<TValue>
    {
        TValue Lerp(TValue from, TValue to, float t);
    }

    #region UpdateMode Utilities

    public enum UpdateMode
    {
        Scaled,
        Unscaled
    }

    public static class UpdateModeUtility
    {
        public static float GetDeltaTime(UpdateMode updateMode)
        {
            switch (updateMode)
            {
                case UpdateMode.Scaled:
                    return Time.deltaTime;

                case UpdateMode.Unscaled:
                    return Time.unscaledDeltaTime;

                default:
                    throw new ArgumentOutOfRangeException(nameof(updateMode), updateMode, null);
            }
        }

        public static float GetTime(UpdateMode updateMode)
        {
            switch (updateMode)
            {
                case UpdateMode.Scaled:
                    return Time.time;

                case UpdateMode.Unscaled:
                    return Time.unscaledTime;

                default:
                    throw new ArgumentOutOfRangeException(nameof(updateMode), updateMode, null);
            }
        }
    }

    #endregion

    #region Easing Functions

    /// <summary>
    /// イージング関数を表現する。
    /// </summary>
    public interface IEaser
    {
        float Ease(float t);
    }

    public struct EaseLinear : IEaser
    {
        public float Ease(float t) => t;
    }

    public readonly struct EaseCustomCurve : IEaser
    {
        private AnimationCurve Curve { get; }

        public EaseCustomCurve(AnimationCurve curve)
        {
            Curve = curve;
        }

        public float Ease(float t) => Curve.Evaluate(t);
    }

    public struct EaseSineIn : IEaser
    {
        public float Ease(float t) => 1 - Mathf.Cos((t * Mathf.PI) / 2);
    }

    public struct EaseSineOut : IEaser
    {
        public float Ease(float t) => Mathf.Sin((t * Mathf.PI) / 2);
    }

    public struct EaseSineInOut : IEaser
    {
        public float Ease(float t) => -(Mathf.Cos(Mathf.PI * t) - 1) / 2f;
    }

    public struct EasePow2In : IEaser
    {
        public float Ease(float t) => t * t;
    }

    public struct EasePow2Out : IEaser
    {
        public float Ease(float t) => 1f - (1f - t) * (1f - t);
    }

    public struct EasePow2InOut : IEaser
    {
        public float Ease(float t) => t < 0.5f ? 2f * t * t : 1f - Mathf.Pow(-2f * t + 2f, 2f) * 0.5f;
    }

    public struct EasePow3In : IEaser
    {
        public float Ease(float t) => t * t * t;
    }

    public struct EasePow3Out : IEaser
    {
        public float Ease(float t) => 1 - Mathf.Pow(1 - t, 3f);
    }

    public struct EasePow3InOut : IEaser
    {
        public float Ease(float t) => t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f) * 0.5f;
    }

    public struct EasePow4In : IEaser
    {
        public float Ease(float t) => t * t * t * t;
    }

    public struct EasePow4Out : IEaser
    {
        public float Ease(float t) => 1 - Mathf.Pow(1 - t, 4f);
    }

    public struct EasePow4InOut : IEaser
    {
        public float Ease(float t) => t < 0.5f ? 8f * t * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 4f) * 0.5f;
    }

    public struct EasePow5In : IEaser
    {
        public float Ease(float t) => t * t * t * t * t;
    }

    public struct EasePow5Out : IEaser
    {
        public float Ease(float t) => 1 - Mathf.Pow(1 - t, 5f);
    }

    public struct EasePow5InOut : IEaser
    {
        public float Ease(float t) => t < 0.5f ? 16f * t * t * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 5f) * 0.5f;
    }

    public struct EaseExpoIn : IEaser
    {
        public float Ease(float t) => t == 0f ? 0f : Mathf.Pow(2f, 10f * t - 10f);
    }

    public struct EaseExpoOut : IEaser
    {
        public float Ease(float t) => t >= 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
    }

    public struct EaseExpoInOut : IEaser
    {
        public float Ease(float t) =>
            t == 0
                ? 0f
                : (t >= 1f
                    ? 1f
                    : (t < 0.5f
                        ? Mathf.Pow(2f, 20f * t - 10f) / 2f
                        : (2f - Mathf.Pow(2f, -20f * t + 10f)) / 2f));
    }

    public struct EaseCircIn : IEaser
    {
        public float Ease(float t) => 1f - Mathf.Sqrt(1f - t * t);
    }

    public struct EaseCircOut : IEaser
    {
        public float Ease(float t) => Mathf.Sqrt(1 - (t - 1) * (t - 1));
    }

    public struct EaseCircInOut : IEaser
    {
        public float Ease(float t) =>
            t < 0.5f
                ? (1 - Mathf.Sqrt(1f - 4f * t * t)) * 0.5f
                : (Mathf.Sqrt(1f - 4f * (t * t - 2f * t + 1f)) + 1f) * 0.5f;
    }

    public struct EaseBackIn : IEaser
    {
        public float Ease(float t)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1f;
            return c3 * t * t * t - c1 * t * t;
        }
    }

    public struct EaseBackOut : IEaser
    {
        public float Ease(float t)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1f;
            return 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
        }
    }

    public struct EaseBackInOut : IEaser
    {
        public float Ease(float t)
        {
            const float c1 = 1.70158f;
            const float c2 = c1 * 1.525f;

            return t < 0.5f
                ? (Mathf.Pow(2f * t, 2f) * ((c2 + 1f) * 2f * t - c2)) / 2f
                : (Mathf.Pow(2f * t - 2f, 2f) * ((c2 + 1f) * (t * 2f - 2f) + c2) + 2f) / 2f;
        }
    }

    public struct EaseElasIn : IEaser
    {
        public float Ease(float t)
        {
            const float c4 = (2f * Mathf.PI) / 3f;

            return t == 0f
                ? 0f
                : t >= 1f
                    ? 1
                    : -Mathf.Pow(2f, 10f * t - 10f) * Mathf.Sin((t * 10f - 10.75f) * c4);
        }
    }

    public struct EaseElasOut : IEaser
    {
        public float Ease(float t)
        {
            const float c4 = (2f * Mathf.PI) / 3f;

            return t == 0f
                ? 0f
                : t >= 1f
                    ? 1f
                    : Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * 10f - 0.75f) * c4) + 1f;
        }
    }

    public struct EaseElasInOut : IEaser
    {
        public float Ease(float t)
        {
            const float c5 = (2f * Mathf.PI) / 4.5f;

            return t == 0f
                ? 0f
                : t >= 1f
                    ? 1f
                    : t < 0.5f
                        ? -(Mathf.Pow(2f, 20f * t - 10f) * Mathf.Sin((20f * t - 11.125f) * c5)) / 2f
                        : (Mathf.Pow(2f, -20f * t + 10f) * Mathf.Sin((20f * t - 11.125f) * c5)) / 2f + 1;
        }
    }

    #endregion

    #region Utilities

    /// <summary>
    /// 度数法による2つの角度間のアニメーションにおいて、移動量が少なくなるように補完するIValueAnimatorの実装。
    /// </summary>
    public class DegreeValueAnimator : IValueAnimator<float>
    {
        public float Lerp(float from, float to, float t)
        {
            //normalize
            from = from >= 0 ? from % 360 : 360 - (Mathf.Abs(from) % 360);
            to = to >= 0 ? to % 360 : 360 - (Mathf.Abs(to) % 360);

            float d = to - from;
            bool crossing = Mathf.Abs(d) > 180;
            bool positive = d > 0;
            if (crossing) positive = !positive;

            if (crossing)
            {
                if (positive)
                {
                    to += 360;
                }
                else
                {
                    to -= 360;
                }
            }

            float v = Mathf.Lerp(from, to, t);
            return v >= 0 ? v % 360 : 360 - (Mathf.Abs(v) % 360);
        }
    }

    #endregion

    #region Extensions

    public static class InstAnimeExtensions
    {
        /// <summary>
        /// 指定したGameObjectがDestroyされるタイミングで、InstantAnimatorを自動的にDisposeする。
        /// </summary>
        /// <param name="instantAnimator"></param>
        /// <param name="target"></param>
        /// <typeparam name="TAnimator"></typeparam>
        /// <returns></returns>
        public static TAnimator DisposeOnDestroy<TAnimator>(this TAnimator instantAnimator, GameObject target)
            where TAnimator : InstantAnimator
        {
            InternalDisposeOnDestroy(instantAnimator, target).Forget();
            return instantAnimator;
        }

        private static async UniTaskVoid InternalDisposeOnDestroy(IDisposable animator, GameObject target)
        {
            if (!target)
            {
                animator.Dispose();
                return;
            }

            await target.OnDestroyAsync();
            animator.Dispose();
        }

        public static BindingInstantAnimator<Graphic, float> InstAnimeFade(this Graphic target,
            UpdateMode defaultUpdateMode = UpdateMode.Scaled)
        {
            return new BindingInstantAnimator<Graphic, float>(target, g => g.color.a, (g, v) =>
            {
                var c = g.color;
                c.a = v;
                g.color = c;
            }, defaultUpdateMode);
        }

        public static BindingInstantAnimator<CanvasGroup, float> InstAnimeFade(this CanvasGroup target,
            UpdateMode defaultUpdateMode = UpdateMode.Scaled)
        {
            return new BindingInstantAnimator<CanvasGroup, float>(target, g => g.alpha, (g, v) => g.alpha = v,
                defaultUpdateMode);
        }
    }

    #endregion
}