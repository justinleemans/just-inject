using JeeLee.JustInject.Delegates;
using System;

namespace JeeLee.JustInject.Bindings
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
