using OpenAM.Core.Entities.Naming;
using OpenAM.Core.Entities.Session;

namespace OpenAM.Core.Providers
{
    public interface ISessionProvider
    {
        Session GetSession(string authCookie);
        Session GetSession(Naming naming);
    }
}