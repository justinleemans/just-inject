using JustInject.Delegates;
using System;

namespace JustInject.Bindings
{
    public interface IBinding
    {
        Type type { get; }
        CreateBindingHandler CreateHandler { get; }

        IBinding To<TType>();
        IBinding FromNew();
        IBinding FromInstance<TInstance>(TInstance instance);
        IBinding AsSingleton();
    }
}
