// SPDX-FileCopyrightText: 2023 Eitsop
// SPDX-License-Identifier: MIT

namespace Complex19.Connectivity
{
    internal class GeminiStatusLineParserFactory : IGeminiStatusLineParserFactory
    {
        public IGeminiStatusLineParser CreateParser(
            IGeminiRequest request,
            IEnumerable<byte> bytes)
        {
            return new GeminiStatusLineParser(request, bytes);
        }
    }
}