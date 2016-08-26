using System.Collections.Generic;
using System.Diagnostics;

namespace ChamgeCurrency.Contracts
{
    [DebuggerStepThrough]
    public abstract class Operation<TRequest, TResponse> : OperationBase, IOperation<TRequest, TResponse>
    {
        protected Operation(IContext context) : base(context) { }

        public TResponse Operate(TRequest request = default(TRequest))
        {
            if (!EqualityComparer<TRequest>.Default.Equals(request, default(TRequest)))
            {
                Validate(request);
            }
            
            TResponse response = default(TResponse);
            ExecuteOperation(() => { response = OnOperate(request); });
            
            return response;
        }
        
        protected abstract TResponse OnOperate(TRequest request);
    }
}
