using System;
using System.Collections.Generic;

namespace ChamgeCurrency.Contracts
{
    public interface IContainer
    {
        object Resolve(Type instanceType);
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
        IEnumerable<object> ResolveAll(Type type);
    }
}
