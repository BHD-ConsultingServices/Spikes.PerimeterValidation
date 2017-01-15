
namespace Spike.PerimeterValidation.Contracts
{
    using System;
    using System.Collections.Generic;

    public class ValidationException : Exception
    {
        public ValidationException(List<ErrorItem> errors, string description = null)
        {
            Errors = errors;
            Description = description;
        }

        public string Description { get; private set; }

        public List<ErrorItem> Errors { get; set; }
    }
}
