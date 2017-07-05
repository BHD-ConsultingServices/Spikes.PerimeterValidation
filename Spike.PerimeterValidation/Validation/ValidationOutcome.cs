
namespace Spike.PerimeterValidation.Validation
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValidationOutcome
    {
        private readonly string _objectType;

        public ValidationOutcome(string objectType)
        {
            _objectType = objectType;
        }

        public bool IsValid { get; set; }

        public int NumberOfErrors { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }

        public override string ToString()
        {
            if (IsValid)
            {
                return "Validated Succesfully";
            }

            var combinedErrors = string.Join(" ", ErrorMessages.Select(err => $" •{err}").ToArray());

            return $"Failed Validation: [{_objectType}] with [{NumberOfErrors}] validation errors >> {combinedErrors}";
        }
    }
}
