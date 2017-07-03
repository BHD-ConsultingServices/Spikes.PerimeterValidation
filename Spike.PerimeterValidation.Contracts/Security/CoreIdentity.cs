
namespace Spike.PerimeterValidation.Common.Security
{
    public class CoreIdentity
    {
        public CoreIdentity()
        {
        }

        public CoreIdentity(string identityReference, bool isAuthenticated)
        {
            this.IdentityReference = identityReference;
            this.IsAuthenticated = isAuthenticated;
        }

        public string IdentityReference { get; set; }

        public bool IsAuthenticated { get; private set; }
    }
}
