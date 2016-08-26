using System;
using System.Linq;

namespace ChamgeCurrency.Contracts
{
    public class OperationBase
    {
        protected IContext Context { get; }
        protected ILogger Logger => Context.Logger;

        public OperationBase(IContext context)
        {
            Context = context;
        }

        protected void ExecuteOperation(Action operationAction)
        {
            try
            {
                operationAction();
            }
           
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
                throw;
            }
        }

        protected void Validate<TRequest>(TRequest request)
        {
            var validator = Context.ValidatorFactory.GetValidatorFor<TRequest>();
            if (validator == null)
            {
                throw new Exception("Could not resolve validator for " + request);
                
            }
            else
            {
                var errorMessages = validator.Validate(request);
                if (errorMessages.Any())
                {
                    throw new ValidationException(errorMessages);
                }
            }
        }
    }
}
