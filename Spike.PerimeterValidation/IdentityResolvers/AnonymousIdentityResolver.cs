
namespace Spike.PerimeterValidation.IdentityResolvers
{
    using Common.Security;
    using System;

    [Serializable]
    public class AnonymousIdentityResolver : IdentityResolverBase
    {
        public const string AnnonmousName = "Anonymous";

        public override CoreIdentity ResolveCurrentIdentity()
        {
            return new CoreIdentity(AnnonmousName, false);
        }
    }
}
