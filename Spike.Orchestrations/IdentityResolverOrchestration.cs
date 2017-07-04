
using Spike.PerimeterValidation.Common.Security;

namespace Spike.Orchestrations
{
    using PerimeterValidation;
    using PerimeterValidation.Common.Attributes;

    public class IdentityResolverOrchestration
    {
        [ValidationAspect(IdentityResolverType.Anonymous)]
        public string ResolveAnnymousIdentity([Identity]CoreIdentity originator = null)
        {
            return originator?.IdentityReference;
        }

        [ValidationAspect(IdentityResolverType.WindowsIdentity)]
        public string ResolveWindowsIdentity([Identity]CoreIdentity originator = null)
        {
            return originator?.IdentityReference;
        }
    }
}
