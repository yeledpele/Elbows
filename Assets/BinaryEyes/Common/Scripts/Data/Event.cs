using System;
using UnityEngine.Events;
using UnityEngine;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The IEvent interface provides the public API for user interaction
    /// with an event wrapper.
    /// </summary>
    public interface IEvent
    {
        void RemoveAllListeners();
        void RemoveListener(UnityAction action);
        void AddListener(UnityAction action);
    }

    /// <summary>
    /// The Event class provides a simple wrapper over Unity's built in events.
    /// </summary>
    [Serializable]
    public class Event
        : IEvent
    {
        [SerializeField] private UnityEvent _raised;
        public void RemoveAllListeners() => _raised.RemoveAllListeners();
        public void RemoveListener(UnityAction action) => _raised.RemoveListener(action);
        public void AddListener(UnityAction action) => _raised.AddListener(action);
        public void Invoke() => _raised.Invoke();
    }
}