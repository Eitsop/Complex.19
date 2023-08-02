namespace Complex19.Connectivity
{
    internal class GeminiRequest : IGeminiRequest
    {
        public GeminiRequest( Uri url ) 
        { 
            Url = url;
        }

        public Uri Url { get; }
    }
}
