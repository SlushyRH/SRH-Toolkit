using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRH.Toolkit
{
    /// <summary>
    /// Static Instnace allows a class to be used statically through the Instance keyword.
    /// <see href="https://github.com/SlushyRH/SRH-Toolkit#singleton-usage">How To Use</see>
    /// </summary>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Same as the static instance but this will destroy any new versions created, leaving the original Instance to stay the same.
    /// <see href="https://github.com/SlushyRH/SRH-Toolkit#singleton-usage">How To Use</see>
    /// </summary>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null) Destroy(Instance);
            base.Awake();
        }
    }

    /// <summary>
    /// Same as the Singleton but this will survive through scene loads. Perfect for data thats needs to be persistent.
    /// <see href="https://github.com/SlushyRH/SRH-Toolkit#singleton-usage">How To Use</see>
    /// </summary>
    public abstract class SingletonPersistent<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
