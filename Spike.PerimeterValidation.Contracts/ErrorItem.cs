
namespace Spike.PerimeterValidation.Contracts
{
    public class ErrorItem
    {
        public static ErrorItem CreateMandatoryError(string arguement, string property)
        {
            var description = $"Mandatory property not supplied. Property [{property}]";

            return new ErrorItem(arguement, description);
        }

        public ErrorItem(string arguement, string description = null)
        {
            Arguement = arguement;
            Description = description ?? string.Empty;
        }

        public string Arguement { get; set; }

        public string Description { get; set; }
    }
}
