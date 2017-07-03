


namespace Spike.PerimeterValidation.Common.Security
{
    using System.Security.Principal;
    using System;

    [Serializable]
    public abstract class IdentityResolverBase : IIdentityResolver
    {
        public CoreIdentity GetGenericIdentity(IIdentity identity)
        {
            return new CoreIdentity(identity.Name, identity.IsAuthenticated);
        }

        public abstract CoreIdentity ResolveCurrentIdentity();
    }
}
