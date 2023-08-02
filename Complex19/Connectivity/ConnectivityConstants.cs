// SPDX-FileCopyrightText: 2023 Eitsop
// SPDX-License-Identifier: MIT

using System.Text;

namespace Complex19.Connectivity
{
    internal static class ConnectivityConstants
    {
        public static int DefaultGeminiPort = 1965;
        public static string CRLF = "\r\n";
        public static int ReceiveBufferSize = 8192;
        public static int MaximumMemoryCacheSize = 8192;

        public static byte[] CRLFByteSequence { get; } = Encoding.UTF8.GetBytes(CRLF);
    }
}
