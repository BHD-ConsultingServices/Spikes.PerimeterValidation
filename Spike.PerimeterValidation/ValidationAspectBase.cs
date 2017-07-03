
using Spike.PerimeterValidation.IdentityResolvers;

namespace Spike.PerimeterValidation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PostSharp.Aspects;
    using System.Reflection;
    using Contracts;
    using Common.Attributes;
    using Common.Security;

    [Serializable]
    public abstract class ValidationAspectBase : OnMethodBoundaryAspect
    {
        public abstract void RegisterValidators();

        private List<TypeValidator> _typeValidators;

        private readonly IIdentityResolver _identityResolver;

        public ValidationAspectBase(IdentityResolverType identityResolver)
        {
            switch (identityResolver)
            {
                 case IdentityResolverType.WindowsIdentity: _identityResolver = new WindowsIdentityResolver();
                    break;

                default:
                    _identityResolver = new AnonymousIdentityResolver();
                    break;
            }

        }

        public List<TypeValidator> TypeValidators
        {
            get
            {
                if (_typeValidators != null)
                {
                    return _typeValidators;
                }

                _typeValidators = new List<TypeValidator>();
                RegisterValidators();
                return _typeValidators;
            }
        }

        public void AddTypeValidator<T>(Func<T, List<ErrorItem>> validation)
        {
            Func<object, List<ErrorItem>> genericValidator = (f) => validation((T)f);
            var validator = new TypeValidator(typeof(T), genericValidator);

            TypeValidators.Add(validator);
        }

        public void ValidateByType(Type type, string arguement, object value, ref List<ErrorItem> errors)
        {
            var validator = TypeValidators.SingleOrDefault(v => v.ObjectType == type);

            if (errors != null && validator?.Validator != null)
            {
                errors.AddRange(validator.Validator(value));
            }
        }

        public void ValidateMandatoryProperties(Type type, string arguement, object value, ref List<ErrorItem> errorList)
        {
            var properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(MandatoryAttribute)).Any());

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value);

                if (propertyValue == type.GetDefaultValue())
                {
                    errorList.Add(ErrorItem.CreateMandatoryError(arguement, property.Name));
                }
            }
        }
    

        public void Validate(Type type, string method, string arguement, object value)
        {
            var errors = new List<ErrorItem>();

            ValidateByType(type, arguement, value, ref errors);
            ValidateMandatoryProperties(type, arguement, value, ref errors);
            
            if (!errors.HasErrors()) return;

            var message = $"Parimiter validation on [{method}] failed for [{arguement}] of type [{type}]. Please see inner validation errors for detail.";
            throw new ValidationException(errors, message);
        }


        public override void OnEntry(MethodExecutionArgs args)
        {
            try
            {
                for (var x = 0; x < args.Arguments.Count; x++)
                {
                    var parmInfo = args.Method.GetParameters()[x];
                    var parmValue = args.Arguments.GetArgument(x);

                    if (parmInfo.GetCustomAttributes(typeof(IdentityAttribute)).Any())
                    {
                        if (!string.IsNullOrWhiteSpace(parmValue.ToString()))
                        {
                            continue;
                        }
                        
                        var currentIdentity = _identityResolver.ResolveCurrentIdentity();

                        parmValue = currentIdentity?.IdentityReference ?? string.Empty;
                        args.Arguments.SetArgument(x, parmValue);

                        continue;
                    }

                    if (parmInfo.ParameterType.IsPrimitive)
                    {
                        continue;
                    }

                    Validate(parmInfo.ParameterType, args.Method.Name, parmInfo.Name, parmValue);
                }
            }
            catch (ValidationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                // TODO: Add Logging
            }

            base.OnEntry(args);
        }
    }
}
