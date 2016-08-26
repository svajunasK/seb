namespace ChamgeCurrency.Contracts
{
    public class ValidationErrorInfo
    {
        public string Message { get; private set; }
        public ITranslation LocalizedMessage { get; private set; }

        public ValidationErrorInfo(string errorMessage)
        {
            Message = errorMessage;
        }

        public ValidationErrorInfo(ITranslation errorMessage)
        {
            LocalizedMessage = errorMessage;
        }
    }
}