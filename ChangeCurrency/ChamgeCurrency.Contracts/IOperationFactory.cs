namespace ChamgeCurrency.Contracts
{
    public interface IOperationFactory
    {
        T Create<T>() where T : class, IOperation;
    }
}
