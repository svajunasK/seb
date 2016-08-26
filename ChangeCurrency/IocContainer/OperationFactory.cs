using Microsoft.Practices.Unity;

namespace ChamgeCurrency.Contracts
{
    public class OperationFactory : IOperationFactory
    {
        private readonly IUnityContainer _container;

        public OperationFactory(IUnityContainer container)
        {
            _container = container;
        }

        public T Create<T>() where T : class, IOperation
        {
            return _container.Resolve<T>();
        }
    }
}
