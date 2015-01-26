using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAM.Core.Providers;

namespace OpenAM.Core.UnitTests.BlackBox.Providers
{
    [TestClass, ExcludeFromCodeCoverage]
    public class NamingProviderTests
    {
        private NamingProvider _namingProvider;
        private string _url;

        [TestInitialize]
        public void TestInit()
        {
            _url = MotherObject.Url + "/namingservice";

            _namingProvider = MotherObject.CreateNamingProvider(MotherObject.Url + "/namingservice");
        }

        [TestMethod, TestCategory("BlackBox")]
        public void GetNamingTest()
        {
            var naming = _namingProvider.GetNaming();
            Assert.IsNotNull(naming, "Naming can't be null.");
            Assert.IsNotNull(naming.AuthUrl, "AuthUrl can't ve null.");
            Assert.IsTrue(naming.AuthUrl.StartsWith(_url), "AuthUrl must start from {0}", _url);
            Assert.IsNotNull(naming.IdentityUrl, "IdentityUrl can't ve null.");
            Assert.IsTrue(naming.IdentityUrl.StartsWith(_url), "IdentityUrl must start from {0}", _url);
            Assert.IsNotNull(naming.PolicyUrl, "PolicyUrl can't ve null.");
            Assert.IsTrue(naming.PolicyUrl.StartsWith(_url), "PolicyUrl must start from {0}", _url);
            Assert.IsNotNull(naming.SessionUrl, "SessionUrl can't ve null.");
            Assert.IsTrue(naming.SessionUrl.StartsWith(_url), "SessionUrl must start from {0}", _url);
        }
    }
}