
namespace Spike.PerimeterValidation.Validation
{
    public class ValidationItemResult
    {
        public ValidationItemResult(bool isValid, string message = null)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}
