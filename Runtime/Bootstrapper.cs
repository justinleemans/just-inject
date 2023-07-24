using System.Linq;
using UnityEngine;

namespace JustInject
{
    [DefaultExecutionOrder(-999)]
    public abstract class Bootstrapper<T> : MonoBehaviour
    {
        private static Bootstrapper<T> _instance;

        [SerializeField]
        private bool _global;

        protected ServiceContainer ServiceContainer { get; private set; }

        private void Awake()
        {
            if (_global)
            {
                MakeSingleton();
            }

            ServiceContainer = new ServiceContainer();

            InstallBindings();
        }

        protected abstract void OnInstallBindings();

        private void InstallBindings()
        {
            OnInstallBindings();

            var sceneComponents = FindObjectsOfType<GameObject>()
                .Where(obj => obj.activeInHierarchy)
                .SelectMany(obj => obj.GetComponentsInChildren<MonoBehaviour>());

            foreach (var component in sceneComponents)
            {
                ServiceContainer.Inject(component);
            }
        }

        private void MakeSingleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
