
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
            var testReference = "overrideAnnonymous";

            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveAnnymousIdentity(testReference);

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            Assert.AreEqual(testReference, identityReference);
        }
        
        [TestMethod]
        public void TestWindowsOverrideIdentityResolver()
        {
            var testReference = "overrideWindows";

            var provider = new IdentityResolverOrchestration();
            var identityReference = provider.ResolveWindowsIdentity(testReference);

            Assert.IsFalse(string.IsNullOrWhiteSpace(identityReference));
            Assert.AreEqual(testReference, identityReference);
        }
    }
}
