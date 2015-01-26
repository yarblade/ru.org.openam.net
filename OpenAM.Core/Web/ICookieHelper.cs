using System.Web;

namespace OpenAM.Core.Web
{
    public interface ICookieHelper
    {
        void ResetCookies(HttpResponseBase response, string[] resetCookies);
        string GetCookieValue(HttpRequestBase request, string cookieName);
    }
}