
using Spike.PerimeterValidation.Contracts;

namespace Spike.PerimeterValidation
{
    using System;
    using System.Collections.Generic;

    public class TypeValidator
    {
        public Func<object, List<ErrorItem>> Validator {get; private set; }

        public Type ObjectType { get; private set; }

        public TypeValidator(Type objectType, Func<object, List<ErrorItem>> validator)
        {
            ObjectType = objectType;
            Validator = validator;
        }
    }
}
