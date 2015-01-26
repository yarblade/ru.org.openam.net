using System;

namespace OpenAM.Core.Exceptions
{
    public interface IExceptionShield
    {
        void Process(Action action);
        T Process<T>(Func<T> func);
    }
}