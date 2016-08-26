using System.Collections.Generic;

namespace ChamgeCurrency.Contracts
{
    public interface IValidator
    {
    }

    public interface IValidator<in T> : IValidator
    {
        IList<ValidationErrorInfo> Validate(T dto);
    }
}