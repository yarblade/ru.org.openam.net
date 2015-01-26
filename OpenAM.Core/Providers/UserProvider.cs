using System.Security.Principal;
using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Session;

namespace OpenAM.Core.Providers
{
    public class UserProvider : IUserProvider
    {
        public IPrincipal GetUser(Session session)
        {
            return session != null && session.UserId != null ? new GenericPrincipal(new GenericIdentity(session.UserId), new string[0]) : null;
        }

        public IPrincipal GetAnonymousUser()
        {
            return new GenericPrincipal(new GenericIdentity(string.Empty), new string[0]);
        }
    }
}