using System;
using UnityEngine;

namespace BinaryEyes.Common
{
    /// <summary>
    /// Provides a singleton implementation derived from a MonoBehaviour class.
    /// </summary>
    public class SingletonComponent<T>
        : MonoBehaviour where T : SingletonComponent<T>
    {
        public static T Instance { get; private set; }
        public static bool Exists => Instance != null;
        public bool IsPersistent;

        protected virtual void Awake()
        {
            ValidateSingletonInstance();
            Instance = (T)this;
            if (IsPersistent)
                DontDestroyOnLoad(gameObject);
        }

        private void ValidateSingletonInstance()
        {
            if (Instance == null) 
                return;

            if (Instance == this) 
                return;

            var msg = $"{typeof(T).Name}: singleton instance already exist [{name}]";
            throw new InvalidOperationException(msg);
        }
    }
}
