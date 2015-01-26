using OpenAM.Core.Entities;

namespace OpenAM.Core.Serialization
{
    public interface IResponseSerializer
    {
        T Deserialize<T>(byte[] data) where T : ResponseBase;
    }
}