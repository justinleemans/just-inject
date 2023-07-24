using UnityEngine;

namespace JustInject
{
    public abstract class Bootstrapper<T> : MonoBehaviour
    {
        private static Bootstrapper<T> _instance;

        [SerializeField]
        private bool _global;

        private void Awake()
        {
            if (_global)
            {
                MakeSingleton();
            }

            InstallBindings();
        }

        protected abstract void OnInstallBindings();

        private void InstallBindings()
        {
            OnInstallBindings();
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
