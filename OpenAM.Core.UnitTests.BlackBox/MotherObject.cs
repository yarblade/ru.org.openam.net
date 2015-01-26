using System.Configuration;
using OpenAM.Core.Providers;
using OpenAM.Core.Serialization;
using OpenAM.Core.Settings;
using OpenAM.Core.Web;

namespace OpenAM.Core.UnitTests.BlackBox
{
    internal static class MotherObject
    {
        public static string Url
        {
            get { return ConfigurationManager.AppSettings["Url"]; }
        }

        public static string Login
        {
            get { return ConfigurationManager.AppSettings["Login"]; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings["Password"]; }
        }

        public static NamingProvider CreateNamingProvider(string url)
        {
            var requestIdProvider = new RequestIdProvider();
            var xmlSerializer = new XmlSerializer();

            var responseProvider = new GenericResponseProvider(
                new RequestSerializer(requestIdProvider, xmlSerializer),
                new HttpClient(new HttpClientSettings { ContentType = "text/xml; encoding='utf-8'", UserAgent = "openam.org.ru/1.0 (.Net)", KeepAlive = true }),
                new ResponseSerializer(xmlSerializer),
                url);

            return new NamingProvider(requestIdProvider, responseProvider, url);
        }
    }
}