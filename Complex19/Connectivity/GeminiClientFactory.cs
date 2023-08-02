using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex19.Connectivity
{
    internal class GeminiClientFactory : IGeminiClientFactory
    {
        private readonly IGeminiStatusLineParserFactory _geminiStatusLineParserFactory;

        public GeminiClientFactory(IGeminiStatusLineParserFactory geminiStatusLineParserFactory) 
        {
            _geminiStatusLineParserFactory = geminiStatusLineParserFactory;
        }

        public IGeminiClient CreateClient()
        {
            return new GeminiClient(_geminiStatusLineParserFactory);
        }
    }
}
