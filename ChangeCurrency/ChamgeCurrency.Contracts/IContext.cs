namespace ChamgeCurrency.Contracts
{
    public interface IContext
    {
        ILogger Logger { get; }
        IValidatorFactory ValidatorFactory { get; }
     }
}
