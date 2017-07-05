
namespace Spike.PerimeterValidation.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;

    public class ObjectValidator<T> where T : class
    {
        public Type ObjectType = typeof(T);
        private readonly Dictionary<Expression<Func<T, bool>>, string> _rules = new Dictionary<Expression<Func<T, bool>>, string>();
        private readonly List<ValidationItemResult> _results = new List<ValidationItemResult>();

        public ObjectValidator<T> AddRule(Expression<Func<T, bool>> rule, string errorMessage = null)
        {
            _rules.Add(rule, errorMessage);
            return this; 
        }

        public ValidationOutcome Validate(T objectInstance)
        {
            foreach (var rule in _rules)
            {
                var isValid = rule.Key.Compile()(objectInstance);
                var result = new ValidationItemResult(isValid, isValid ? null : rule.Value);
                _results.Add(result);
            }

            var valid = _results.TrueForAll(t => t.IsValid);

            if (valid)
            {
                return new ValidationOutcome(ObjectType.ToString())
                {
                    IsValid = true
                };
            }

            var numberOfErrors = _results.Count(err => !err.IsValid);
            var errorMessages = _results
                .Where(msg => !string.IsNullOrWhiteSpace(msg.Message))
                .Select(msg => msg.Message);
            
            return new ValidationOutcome(ObjectType.ToString())
            {
                IsValid = false,
                NumberOfErrors = numberOfErrors,
                ErrorMessages = errorMessages
            };
        }
    }
}
