
namespace Spike.PerimeterValidation
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using Contracts;

    public static class ValidationExtenders
    {
        public static bool HasErrors(this List<ErrorItem> original)
        {
            return original != null && original.Count != 0;
        }

        public static object GetDefaultValue(this Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
