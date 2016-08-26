using System;
using System.Collections.Generic;

namespace ChamgeCurrency.Contracts
{
    public interface IContainerRegistration : IContainer
    {
        void RegisterType<TInterface, TType>(bool singletone = false) where TType : TInterface;
        void RegisterType<TType>(bool singletone = false);
        void RegisterType(Type typeFrom, Type typeTo, bool singletone = false);
        void RegisterInstance<TInterface>(TInterface instance);

        void RegisterServices(IEnumerable<Type> serviceTypes);
        void RegisterOperations(IEnumerable<Type> operationTypes);
        void RegisterValidators(IEnumerable<Type> validatorTypes);
    }
}
