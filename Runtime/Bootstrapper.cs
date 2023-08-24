using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JustInject
{
    [DefaultExecutionOrder(-999)]
    public abstract class Bootstrapper : MonoBehaviour
    {
        private static readonly Dictionary<Type, Bootstrapper> GlobalBootstrappers = new Dictionary<Type, Bootstrapper>();

        #region Serialized Fields

        [SerializeField]
        private bool _global;

        #endregion

        protected ServiceContainer Container { get; private set; }

        #region Unity Functions

        private void Awake()
        {
            if (_global)
            {
                RegisterAsSingleton();
            }
            else
            {
                InstallBindings();
            }

            foreach (var globalBootstrapper in GlobalBootstrappers)
            {
                globalBootstrapper.Value.InstallBindings();
            }
        }

        #endregion

        protected abstract void OnInstallBindings();

        private void RegisterAsSingleton()
        {
            if (GlobalBootstrappers.ContainsKey(GetType()))
            {
                Destroy(gameObject);
            }
            else
            {
                GlobalBootstrappers.Add(GetType(), this);
                DontDestroyOnLoad(gameObject);
            }
        }

        private void InstallBindings()
        {
            if (Container == null)
            {
                Container = new ServiceContainer();
                OnInstallBindings();
            }

            var sceneComponents = FindObjectsOfType<GameObject>()
                .Where(obj => obj.activeInHierarchy)
                .SelectMany(obj => obj.GetComponentsInChildren<MonoBehaviour>());

            foreach (var component in sceneComponents)
            {
                Container.Inject(component);
            }
        }
    }
}
