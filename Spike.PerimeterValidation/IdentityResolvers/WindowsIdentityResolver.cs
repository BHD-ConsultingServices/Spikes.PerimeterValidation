
namespace Spike.PerimeterValidation.IdentityResolvers
{
    using System.Security.Principal;
    using Common.Security;
    using System;

    [Serializable]
    public class WindowsIdentityResolver : IdentityResolverBase
    {
        public override CoreIdentity ResolveCurrentIdentity()
        {
            return GetGenericIdentity(WindowsIdentity.GetCurrent());
        }
    }
}
