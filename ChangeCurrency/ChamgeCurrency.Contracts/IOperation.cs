namespace ChamgeCurrency.Contracts
{
    public interface IOperation
    {
    }

    public interface IOperation<in TRequest> : IOperation
    {
        void Operate(TRequest request);
    }

    public interface IOperation<in TRequest, out TResponse> : IOperation
    {
        TResponse Operate(TRequest request = default(TRequest));
    }
}
