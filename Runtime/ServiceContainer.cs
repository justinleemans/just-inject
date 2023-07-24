using JustInject.Bindings;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JustInject
{
    public class ServiceContainer
    {
        private Dictionary<Type, IBinding> _bindings = new Dictionary<Type, IBinding>();
        
        public ServiceContainer()
        {
            Bind<ServiceContainer>().FromInstance(this);
        }

        public void Inject(object dependant)
        {
            Type type = dependant.GetType();

            while (type != null)
            {
                var fields = type.GetFields(BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Instance);

                foreach (var field in fields)
                {
                    if (field.GetCustomAttribute<InjectAttribute>(false) == null)
                    {
                        continue;
                    }

                    if (_bindings.TryGetValue(field.FieldType, out IBinding value))
                    {
                        field.SetValue(dependant, value.CreateHandler(this));
                    }
                }
                
                type = type.BaseType;
            }
        }

        public Binding<TBinding> Bind<TBinding>()
        {
            var binding = new Binding<TBinding>();

            _bindings.Add(typeof(TBinding), binding);

            return binding;
        }
    }
}
