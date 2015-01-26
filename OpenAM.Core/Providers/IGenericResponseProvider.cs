using OpenAM.Core.Entities;

namespace OpenAM.Core.Providers
{
    public interface IGenericResponseProvider
    {
        TResponse Get<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase
            where TResponse : ResponseBase;
    }
}