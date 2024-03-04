using JeeLee.UniInjection.Delegates;
using System;

namespace JeeLee.UniInjection.Bindings
{
    public interface IBinding
    {
        Type type { get; }
        CreateBindingHandler CreateHandler { get; }

        IBinding To<TType>();
        IBinding FromNew(params object[] args);
        IBinding FromInstance<TInstance>(TInstance instance);
        IBinding AsSingleton();
    }
}
