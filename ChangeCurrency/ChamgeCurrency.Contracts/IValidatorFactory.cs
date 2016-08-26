using System;
using System.Collections.Generic;

namespace ChamgeCurrency.Contracts
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidatorFor<T>();
        void RegisterValidators(IEnumerable<Type> validatorTypes);
    }
}