using System;

namespace ChamgeCurrency.Contracts
{
    public interface ILogger
    {
        void Error(string errorMessage, Exception ex);
        void Debug(Func<string> p);
        void Error(Exception exception);
    }
}