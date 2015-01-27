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

        public static string OrgName
        {
            get { return ConfigurationManager.AppSettings["OrgName"]; }
        }

        public static string IndexName
        {
            get { return ConfigurationManager.AppSettings["IndexName"]; }
        }
    }
}