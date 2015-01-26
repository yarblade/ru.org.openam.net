using System;
using OpenAM.Core.Entities;
using OpenAM.Core.Settings;

namespace OpenAM.Core.Web
{
    public interface IUrlHelper
    {
        bool RedirectIsNeeded(Uri url, AgentSettings settings);
        string GetRedirectUrl(Uri url, AgentSettings settings);
        bool LogoutIsNeeded(Uri url, AgentSettings settings);
        bool AuthorizationIsNeeded(Uri url, AgentSettings settings);
    }
}