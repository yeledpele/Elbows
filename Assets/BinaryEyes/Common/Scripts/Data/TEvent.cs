using System;
using UnityEngine.Events;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The IEvent(T) interface provides the front-facing API for interacting
    /// with a template event wrapper.
    /// </summary>
    public interface IEvent<T>
    {
        void RemoveAllListeners();
        void RemoveListener(UnityAction<T> action);
        void AddListener(UnityAction<T> action);
    }

    /// <summary>
    /// The Event(T) class provides a simple wrapper over Unity's builtin event
    /// class.
    /// </summary>
    [Serializable]
    public class Event<T>
        : IEvent<T>
    {
        [SerializeField] private UnityEvent<T> _raised;
        public void RemoveAllListeners() => _raised.RemoveAllListeners();
        public void RemoveListener(UnityAction<T> action) => _raised.RemoveListener(action);
        public void AddListener(UnityAction<T> action) => _raised.AddListener(action);
        public void Invoke(T args) => _raised.Invoke(args);
    }
}