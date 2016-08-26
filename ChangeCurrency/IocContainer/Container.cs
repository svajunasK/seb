using ChamgeCurrency.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IocContainer
{
    public class Container : IContainerRegistration
    {
        private readonly IUnityContainer _unityContainer;

        public Container(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object Resolve(Type instanceType)
        {
            return _unityContainer.Resolve(instanceType);
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _unityContainer.ResolveAll<T>();
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            return _unityContainer.ResolveAll(type);
        }

        void IContainerRegistration.RegisterType<TInterface, TType>(bool singletone)
        {
            LifetimeManager lifetimeManager = singletone
                ? new ContainerControlledLifetimeManager()
                : (LifetimeManager)new TransientLifetimeManager();

            _unityContainer.RegisterType<TInterface, TType>(lifetimeManager);
        }

        public void RegisterType<TType>(bool singletone = false)
        {
            LifetimeManager lifetimeManager = singletone
                ? new ContainerControlledLifetimeManager()
                : (LifetimeManager)new TransientLifetimeManager();

            _unityContainer.RegisterType<TType>(lifetimeManager);
        }

        public void RegisterType(Type typeFrom, Type typeTo, bool singletone = false)
        {
            LifetimeManager lifetimeManager = singletone
                ? new ContainerControlledLifetimeManager()
                : (LifetimeManager)new TransientLifetimeManager();

            _unityContainer.RegisterType(typeFrom, typeTo, lifetimeManager);
        }

        void IContainerRegistration.RegisterInstance<TInterface>(TInterface instance)
        {
            _unityContainer.RegisterInstance(instance);
        }

        void IContainerRegistration.RegisterServices(IEnumerable<Type> serviceTypes)
        {
            if (serviceTypes == null)
                return;
            
            foreach (var service in serviceTypes)
            {
                if (service.IsInterface || service.IsAbstract || !typeof(ServiceBase).IsAssignableFrom(service))
                    continue;

                Type[] interfaces = service.GetInterfaces();
                foreach (Type interfaceType in interfaces)
                {
                    _unityContainer.RegisterType(interfaceType, service
                        , new ContainerControlledLifetimeManager());
                }
            }
        }

        void IContainerRegistration.RegisterOperations(IEnumerable<Type> operationTypes)
        {
            if (operationTypes == null)
                return;

            foreach (var operation in operationTypes)
            {
                if (operation.IsInterface || operation.IsAbstract || !typeof(IOperation).IsAssignableFrom(operation))
                    continue;

                Type[] interfaces = operation.GetInterfaces();

                foreach (Type interfaceType in interfaces)
                {
                    if (interfaceType.IsGenericType && (
                        interfaceType.GetGenericTypeDefinition() == typeof(IOperation<,>)))
                    {
                        _unityContainer.RegisterType(interfaceType, operation
                            , new TransientLifetimeManager());
                    }
                }
            }
        }

        void IContainerRegistration.RegisterValidators(IEnumerable<Type> validatorTypes)
        {
            if (validatorTypes == null)
            {
                return;
            }

            validatorTypes = validatorTypes.Where(
                type => type.IsClass 
            && !type.IsAbstract 
            && !type.IsGenericType 
            && typeof(IValidator).IsAssignableFrom(type));

            var validatorFactory = Resolve<IValidatorFactory>();
            validatorFactory.RegisterValidators(validatorTypes);
        }
        
    }
}
