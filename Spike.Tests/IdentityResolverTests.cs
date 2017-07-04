
using Spike.PerimeterValidation.Common.Security;

namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orchestrations;
    using PerimeterValidation.IdentityResolvers;

    [TestClass]
    public class IdentityResolverTests
    {
        [TestMethod]
        public void TestAnonymousNoParameter()
        {
            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveAnnymousIdentity();

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            Assert.AreEqual(AnonymousIdentityResolver.AnnonmousName, identityReference);
        }

        [TestMethod]
        public void TestWindowsNoParameter()
        {
            // impersonate a windows identity

            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveWindowsIdentity();

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            // Test that user is impersonated identity
        }

        [TestMethod]
        public void TestAnonymousOverrideIdentityResolver()
        {
            var testOriginator = new CoreIdentity("overrideAnnonymous", true);

            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveAnnymousIdentity(testOriginator);

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            Assert.AreEqual(testOriginator.IdentityReference, identityReference);
        }
        
        [TestMethod]
        public void TestWindowsOverrideIdentityResolver()
        {
            var testOriginator = new CoreIdentity("overrideWindows", true);

            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveWindowsIdentity(testOriginator);

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            Assert.AreEqual(testOriginator.IdentityReference, identityReference);
        }
    }
}
