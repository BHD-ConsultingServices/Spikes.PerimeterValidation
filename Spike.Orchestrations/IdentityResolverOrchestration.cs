
namespace Spike.Orchestrations
{
    using PerimeterValidation;
    using PerimeterValidation.Common.Attributes;

    public class IdentityResolverOrchestration
    {
        [ValidationAspect(IdentityResolverType.Anonymous)]
        public string ResolveAnnymousIdentity([Identity]string originatorReference = null)
        {
            return originatorReference;
        }

        [ValidationAspect(IdentityResolverType.WindowsIdentity)]
        public string ResolveWindowsIdentity([Identity]string originatorReference = null)
        {
            return originatorReference;
        }
    }
}
