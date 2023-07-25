using JustInject.Delegates;
using System;

namespace JustInject.Bindings
{
    public class Binding<TBinding> : IBinding
    {
        private Type _type;
        private CreateBindingHandler _createHandler;
        private bool _isSingleton;
        private object _instance;
        
        public Type type => _type;
        public CreateBindingHandler CreateHandler => _createHandler;

        public Binding()
        {
            To<TBinding>().FromNew();
        }

        public IBinding To<TType>()
        {
            _type = typeof(TType);

            return this;
        }

        public IBinding FromNew()
        {
            _createHandler = container =>
            {
                if (!_isSingleton || _instance == null)
                {
                    _instance = Activator.CreateInstance(_type);
                    container.Inject(_instance);
                }

                return _instance;
            };
            
            return this;
        }

        public IBinding FromInstance<TInstance>(TInstance instance)
        {
            _createHandler = container =>
            {
                _instance ??= instance;

                container.Inject(_instance);

                return _instance;
            };
            
            return AsSingleton();
        }

        public IBinding AsSingleton()
        {
            _isSingleton = true;
            
            return this;
        }
    }
}
