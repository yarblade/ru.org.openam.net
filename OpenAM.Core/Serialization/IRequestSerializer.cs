using OpenAM.Core.Entities;

namespace OpenAM.Core.Serialization
{
    public interface IRequestSerializer
    {
        byte[] Serialize<T>(T obj) where T : RequestBase;
    }
}