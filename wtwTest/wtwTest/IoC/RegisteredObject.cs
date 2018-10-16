using System;

namespace wtwTest {
    public class RegisteredObject
    {
        public RegisteredObject(Type typeToResolve, Type concreteType, LifecycleType lifecycleType = LifecycleType.Transient)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
            LifecycleType = lifecycleType;
        }

        public Type TypeToResolve { get; private set; }
        public Type ConcreteType { get; private set; }
        public object Instance { get; private set; }
        public LifecycleType LifecycleType { get; private set; }
        public void CreateInstance(params object[] args)
        {
            Instance = Activator.CreateInstance(ConcreteType, args);
        }
    }
}