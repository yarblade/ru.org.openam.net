using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAM.Core.Entities.Auth;
using OpenAM.Core.Providers;
using OpenAM.Core.Serialization;
using OpenAM.Core.Settings;
using OpenAM.Core.Web;

namespace OpenAM.Core.UnitTests.BlackBox.Providers
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SessionProviderTests
    {
        private IGenericResponseProvider _responseProvider;
        private SessionProvider _sessionProvider;

        [TestInitialize]
        public void TestInit()
        {
            var settings = new SessionProviderSettings
            {
                AuthType = AuthType.Service,
                OrgName = "/clients",
                IndexName = "ldap",
                Login = MotherObject.Login,
                Password = MotherObject.Password
            };
            var xmlSerializer = new XmlSerializer();
            var requestIdProvider = new RequestIdProvider();

            _responseProvider = new GenericResponseProvider(
                new RequestSerializer(requestIdProvider, xmlSerializer),
                new HttpClient(new HttpClientSettings { ContentType = "text/xml; encoding='utf-8'", UserAgent = "openam.org.ru/1.0 (.Net)", KeepAlive = true }),
                new ResponseSerializer(xmlSerializer),
                MotherObject.Url + "/authservice");

            _sessionProvider = new SessionProvider(requestIdProvider, _responseProvider, settings);
        }

        [TestMethod, TestCategory("BlackBox")]
        public void GetSessionTest()
        {
            var naming = MotherObject.CreateNamingProvider(MotherObject.Url + "/namingservice").GetNaming();

            var session = _sessionProvider.GetSession(naming);
            Assert.IsNotNull(session, "Session can't be null.");
            Assert.IsNotNull(session.Token, "Session Token can't be null.");
            Assert.IsNotNull(session.Properties, "Session Properties can't be null.");
            Assert.IsNotNull(session.Properties["Host"], "Session Properties.Host can't be null.");
        }
    }
}