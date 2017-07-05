
namespace Spike.PerimeterValidation.Validation
{
    using System;

    public static class ValidationExtenders
    {
        #region Mandatory
        
        public static bool Mandatory(this string field)
        {
            return !string.IsNullOrWhiteSpace(field);
        }
        public static bool Mandatory(this int field)
        {
            return field > 0;
        }
        public static bool Mandatory(this DateTime field)
        {
            return field > new DateTime();
        }

        #endregion

        #region Date & Time

        public static bool Future(this DateTime field)
        {
            return field > DateTime.Now;
        }

        public static bool Past(this DateTime field)
        {
            return field < DateTime.Now;
        }

        public static bool Between(this DateTime field, DateTime start, DateTime end)
        {
            return field >= start && field <= end;
        }

        #endregion
    }
}
