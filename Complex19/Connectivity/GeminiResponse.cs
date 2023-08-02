namespace Complex19.Connectivity
{
    internal class GeminiResponse : IGeminiResponse
    {
        public GeminiResponse( IGeminiRequest request, GeminiResponseCode responseCode, string metaData) 
        { 
            Request = request;
            ResponseCode = responseCode;
            MetaData = metaData;
            Content = new GeminiDataStream(request.Url);
        }

        public GeminiResponseCode ResponseCode { get; }

        public string MetaData { get;}

        public GeminiDataStream Content { get; }

        public IGeminiRequest Request { get; }

        public void Dispose()
        {
            Content.Dispose();
        }
    }
}
