using System;
using UnityEngine.Events;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    [Serializable]
    public class PublicEvent
    {
        [SerializeField] public UnityEvent Raised;
        public void RemoveAllListeners() => Raised.RemoveAllListeners();
        public void RemoveListener(UnityAction action) => Raised.RemoveListener(action);
        public void AddListener(UnityAction action) => Raised.AddListener(action);
        public void Invoke() => Raised.Invoke();
    }

    [Serializable]
    public class PublicEvent<T>
    {
        [SerializeField] public UnityEvent<T> Raised;
        public void RemoveAllListeners() => Raised.RemoveAllListeners();
        public void RemoveListener(UnityAction<T> action) => Raised.RemoveListener(action);
        public void AddListener(UnityAction<T> action) => Raised.AddListener(action);
        public void Invoke(T args) => Raised.Invoke(args);
    }
}
