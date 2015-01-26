using OpenAM.Core.Entities;
using OpenAM.Core.Entities.Naming;

namespace OpenAM.Core.Providers
{
    public interface INamingProvider
    {
        Naming GetNaming();
    }
}