// SPDX-FileCopyrightText: 2023 Eitsop
// SPDX-License-Identifier: MIT

namespace Complex19.Connectivity
{
    public interface IGeminiStatusLineParserFactory
    {
        IGeminiStatusLineParser CreateParser(
            IGeminiRequest request,
            IEnumerable<byte> bytes);
    }
}