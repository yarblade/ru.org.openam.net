using System.Web;

namespace OpenAM.Core.Web
{
    public class CookieHelper : ICookieHelper
    {
        public void ResetCookies(HttpResponseBase response, string[] resetCookies)
        {
            foreach (var cookie in resetCookies)
            {
                response.AddHeader("Set-Cookie", cookie);
            }
        }

        public string GetCookieValue(HttpRequestBase request, string cookieName)
        {
            var cookie = request.Cookies[cookieName];

            return cookie != null && !string.IsNullOrWhiteSpace(cookie.Value) ? cookie.Value : null;
        }
    }
}