namespace OpenAM.Core.Providers
{
    public class RequestIdProvider : IRequestIdProvider
    {
        private static int _requestId = 1;

        public int GetRequestId()
        {
            return _requestId++;
        }
    }
}
