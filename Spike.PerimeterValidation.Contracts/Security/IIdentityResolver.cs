
namespace Spike.PerimeterValidation.Common.Security
{
    using System.Security.Principal;

    public interface IIdentityResolver
    {
        CoreIdentity GetGenericIdentity(IIdentity identity);

        CoreIdentity ResolveCurrentIdentity();
    }
}
