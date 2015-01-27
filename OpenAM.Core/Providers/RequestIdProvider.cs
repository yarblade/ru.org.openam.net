namespace OpenAM.Core.Providers
{
    public class RequestIdProvider : IDataProvider<int>
    {
        private static int _requestId = 1;

        public int Get()
        {
            return _requestId++;
        }
    }
}