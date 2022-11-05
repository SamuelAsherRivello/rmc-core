﻿using DG.Tweening;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using RMC.Core.Interfaces;

namespace RMC.Core.Helpers
{
   /// <summary>
   /// Store commonly reused functionality 
   /// for programmatic animation (tweening)
   /// </summary>
   public static class TweenHelper
   {
        //  Other Methods --------------------------------

        /// <summary>
        /// Fades opacity of a 3D Renderer via <see cref="Renderer"/> 
        /// </summary>
        public static void RenderersDoFade(List<Renderer> renderers, float fromAlpha, float toAlpha, 
         float duration, float delayStart)
      {
         foreach (Renderer r in renderers)
         {
            foreach (Material m in r.materials)
            {
               m.DOFade(fromAlpha, 0);
               m.DOFade(toAlpha, duration)
                  .SetDelay(delayStart);
            }
         }
      }

      /// <summary>
      /// Changes color of a 3D object temporarily via <see cref="Renderer"/> 
      /// (E.g. Flicker red to indicate taking damage)
      /// </summary>
      public static void RenderersDoColorFlicker(List<Renderer> renderers, Color color, 
         float duration, float delayStart)
      {
         foreach (Renderer r in renderers)
         {
            foreach (Material m in r.materials)
            {
               Color oldColor = m.color;
               m.DOColor(color, duration)
                  .SetDelay(delayStart)
                  .OnComplete(() =>
               {
                  m.color = oldColor;
               });
            }
         }
      }

            
      /// <summary>
      /// Moves a <see cref="GameObject"/>
      /// </summary>
      public static void TransformMoveTo(GameObject gameObject, Vector3 position)
      {
         gameObject.transform.position = position;
      }
      
      /// <summary>
      /// Moves a <see cref="GameObject"/>
      /// </summary>
      public static  TweenerCore<Vector3, Vector3, VectorOptions> TransformDOBlendableMoveBy(GameObject targetGo, Vector3 fromPosition, Vector3 toPosition, 
         float duration, float delayStart)
      {
         targetGo.transform.position = fromPosition;
         
         return targetGo.transform.DOMove(toPosition, duration)
            .SetDelay(delayStart);
      }
      
      /// <summary>
      /// Scales a <see cref="GameObject"/>
      /// </summary>
      public static TweenerCore<Vector3, Vector3, VectorOptions> TransformDoScale(GameObject targetGo, 
          Vector3 fromScale, Vector3 toScale,  float duration, float delayStart)
      {
         if (targetGo == null)
         {
            return null;
         }
         targetGo.transform.localScale = fromScale;

         return targetGo.transform.DOScale(toScale, duration)
            .SetDelay(delayStart);
      }

        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> TransformDORotate(GameObject targetGo, 
            Vector3 fromRotation, Vector3 toRotation, float duration, float delayStart)
        {
           if (targetGo == null)
           {
              return null;
           }
            targetGo.transform.rotation = Quaternion.Euler(fromRotation);

            return targetGo.transform.DORotate(toRotation, duration)
               .SetDelay(delayStart);
        }

        public static TweenerCore<Vector3, Vector3, VectorOptions> GameObjectFallsIntoPosition(GameObject go, Vector3 initialPositionOffset, float duration)
      {
         Vector3 fromPosition = go.transform.position + initialPositionOffset;
         
         return TransformDOBlendableMoveBy(go, fromPosition, go.transform.position, duration, 0)
            .SetEase(Ease.InSine);
      }
      
      public static TweenerCore<Vector3, Vector3, VectorOptions> GameObjectSpawns(GameObject go, float duration)
      {
         Vector3 toScale = go.transform.lossyScale;
         
         return TransformDoScale(go, new Vector3(0,0,0), toScale, duration, 0)
            .SetEase(Ease.OutBounce);
      }
      
      public static TweenerCore<Vector3, Vector3, VectorOptions> GameObjectDespawns(GameObject go, float duration)
      {
         Vector3 fromScale = go.transform.lossyScale;
         
         return TransformDoScale(go, fromScale,new Vector3(0,0,0), duration, 0)
            .SetEase(Ease.OutBounce);
      }


      public static async UniTask AlphaDoFade(
         IAlpha iAlpha, float fromAlpha, float toAlpha, float duration, float delay = 0, Ease ease = Ease.Linear)
      {
         await UniTask.SwitchToMainThread();
         
         bool isComplete = false;
         iAlpha.Alpha = fromAlpha;
         DOTween.To(() => iAlpha.Alpha, x => iAlpha.Alpha = x, toAlpha, duration).SetDelay(delay).SetEase(ease).onComplete = () =>
         {
            isComplete = true;
         };
         
         await UniTask.WaitWhile(() => !isComplete);
      }
   }
}
