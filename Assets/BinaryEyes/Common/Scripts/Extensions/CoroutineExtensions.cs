using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class CoroutineExtensions
    {
        public static LTDescr CancelTween(this MonoBehaviour behaviour, LTDescr tween)
        {
            if (tween != null)
                LeanTween.cancel(tween.uniqueId);

            return null;
        }

        public static Coroutine CancelCoroutine(this MonoBehaviour behaviour, Coroutine coroutine)
        {
            if (coroutine != null)
                behaviour.StopCoroutine(coroutine);

            return null;
        }
    }
}
