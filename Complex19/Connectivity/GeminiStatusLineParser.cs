// SPDX-FileCopyrightText: 2023 Eitsop
// SPDX-License-Identifier: MIT

using System.Text;

namespace Complex19.Connectivity
{
    internal class GeminiStatusLineParser : IGeminiStatusLineParser
    {
        private readonly IEnumerable<byte> _bytesToParse;
        private readonly IGeminiRequest _request;

        public GeminiStatusLineParser(
            IGeminiRequest request,
            IEnumerable<byte> bytes)
        {
            _request = request;
            _bytesToParse = bytes;
        }

        public IGeminiResponse Parse()
        {
            var bytesAsArray = _bytesToParse as byte[] ?? _bytesToParse.ToArray();
            var statusLine = Encoding.UTF8.GetString(bytesAsArray, 0, bytesAsArray.Length).Trim();
            var spaceIndex = statusLine.IndexOf(' ');
            if (spaceIndex != -1)
            {
                var statusCode = statusLine[..spaceIndex];

                if (!int.TryParse(statusCode, out var code))
                {
                    // TODO
                    throw new InvalidDataException();
                }

                if (!Enum.IsDefined(typeof(GeminiResponseCode), code))
                {
                    // TODO
                    throw new InvalidDataException();
                }

                var metaData = statusLine[(spaceIndex + 1)..];
                var response = new GeminiResponse(_request, (GeminiResponseCode)code, metaData);
                return response;
            }
            else
            {
                // TODO
                throw new InvalidDataException();
            }
        }
    }
}