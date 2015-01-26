using System.Security.Principal;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Session;

namespace OpenAM.Core.Providers
{
    public interface IUserProvider
    {
        IPrincipal GetUser(Session session);
        IPrincipal GetAnonymousUser();
    }
}