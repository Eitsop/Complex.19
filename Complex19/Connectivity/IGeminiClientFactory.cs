using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex19.Connectivity
{
    public interface IGeminiClientFactory
    {
        IGeminiClient CreateClient();
    }
}
