namespace ChamgeCurrency.Contracts
{
    public interface IOperation
    {
    }
    
    public interface IOperation<in TRequest, out TResponse> : IOperation
    {
        TResponse Operate(TRequest request = default(TRequest));
    }
}
