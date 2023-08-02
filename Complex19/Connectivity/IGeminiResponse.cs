using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex19.Connectivity
{
    public interface IGeminiResponse : IDisposable
    {
        IGeminiRequest Request { get; }
        GeminiResponseCode ResponseCode { get; }
        string MetaData { get; }
        GeminiDataStream Content { get; }
    }
}
