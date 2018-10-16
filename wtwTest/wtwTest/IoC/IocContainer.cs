using System;
using System.Collections.Generic;
using System.Linq;

namespace wtwTest {
    public class IocContainer
    {
        private readonly IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();
        public void Register<TTypeToRegister, TConcrete>()
        {
            Register<TTypeToRegister, TConcrete>(LifecycleType.Transient);
        }
        public void Register<TTypeToRegister, TConcrete>(LifecycleType lifeCycle)
        {
            registeredObjects.Add(new RegisteredObject(typeof(TTypeToRegister), typeof(TConcrete), lifeCycle));
        }
        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }
        public object Resolve(Type typeToResolve)
        {
            return ResolveObject(typeToResolve);
        }

        private object ResolveObject(Type typeToResolve)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new Exception($"The type {typeToResolve.Name} has not been registered");
            }
            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance == null || registeredObject.LifecycleType == LifecycleType.Transient)
            {
                var parameters = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
            }
            return registeredObject.Instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}