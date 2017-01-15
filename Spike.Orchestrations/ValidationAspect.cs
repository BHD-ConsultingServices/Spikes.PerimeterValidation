
namespace Spike.Orchestrations
{
    using Contracts.Books;
    using System;
    using System.Collections.Generic;
    using PerimeterValidation;
    using PerimeterValidation.Contracts;

    [Serializable]
    public sealed class ValidationAspect : ValidationAspectBase
    {
        public const int TimeInYears = 20;

        private static readonly Func<AddBookRequest, List<ErrorItem>> 
            AddBookRequestValidator = value =>
            {
                var errors = new List<ErrorItem>();
                var parameter = "AddBookRequest";

            if (value.ReleaseDate < DateTime.Now.AddYears(-1*TimeInYears))
            {
                errors.Add(new ErrorItem(parameter, $"Please use book younger than [{TimeInYears}] years."));
            }

            return errors;
        };



        public override void RegisterValidators()
        {
            this.AddTypeValidator(AddBookRequestValidator);
        }
    }
}
