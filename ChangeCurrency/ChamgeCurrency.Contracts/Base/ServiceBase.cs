using System.Diagnostics;

namespace ChamgeCurrency.Contracts
{
    [DebuggerStepThrough]
    public abstract class ServiceBase
    {
        protected ServiceBase(IOperationFactory operationFactory)
        {
            OperationFactory = operationFactory;
        }

        protected IOperationFactory OperationFactory { get; private set; }

        protected TOperation CreateOperation<TOperation>()
            where TOperation : class, IOperation
        {
            var operation = OperationFactory.Create<TOperation>();
            return operation;
        }
    }
}
