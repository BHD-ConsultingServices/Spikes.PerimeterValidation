
namespace Spike.Orchestrations
{
    using PerimeterValidation.Contracts;

    public class SecurityOrchestration : ISecurityOrchestration
    {
        public bool CheckValidIdentityByReference(string identityReference)
        {
            return true;
            // TODO: Lookup Identity
        }
    }
}
