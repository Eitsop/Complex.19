using Complex19.Extensions;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Complex19.Connectivity
{
    internal class GeminiClient : IGeminiClient
    {
        private readonly IGeminiStatusLineParserFactory _statusLineParserFactory;

        public GeminiClient( IGeminiStatusLineParserFactory geminiStatusLineParserFactory ) 
        { 
            _statusLineParserFactory = geminiStatusLineParserFactory;
        }

        public IGeminiResponse SendRequest(IGeminiRequest request)
        {
            var rxBuffer = new byte[ConnectivityConstants.ReceiveBufferSize];

            var client = new TcpClient();
            var port = request.Url.IsDefaultPort ? ConnectivityConstants.DefaultGeminiPort : request.Url.Port;
            client.Connect(request.Url.Host, port);
            var clientStream = client.GetStream();
            var sslStream = new SslStream(clientStream, false, certifyServer);
            sslStream.AuthenticateAsClient(request.Url.Host);

            sslStream.Write( Encoding.UTF8.GetBytes(request.Url.ToString() + ConnectivityConstants.CRLF ) );

            var totalBytesReceived = 0;
            IGeminiResponse response = null;

            while( client.Connected )
            {
                var bytesReceived = sslStream.Read(rxBuffer, totalBytesReceived, ConnectivityConstants.ReceiveBufferSize - totalBytesReceived);
                totalBytesReceived += bytesReceived;
                if ( bytesReceived > 0 )
                {
                    Debug.WriteLine(totalBytesReceived.ToString());
                    var crlfIndex = rxBuffer.LocateFirst( ConnectivityConstants.CRLFByteSequence );
                    if( response == null )
                    {
                        if( crlfIndex >=0 )
                        {
                            var statusLineParser = _statusLineParserFactory.CreateParser( request, rxBuffer.Take( crlfIndex ) );
                            response = statusLineParser.Parse();
                            if( response != null )
                            {
                                response.Content.Write(rxBuffer.Skip(crlfIndex + ConnectivityConstants.CRLFByteSequence.Length + 1).ToArray());
                            }
                        }
                    }
                    else
                    {
                        response.Content.Write(rxBuffer, 0, bytesReceived);
                    }

                    if( response != null )
                    {
                        totalBytesReceived = 0;
                    }
                }
                else 
                { 
                    break; 
                }
            }
            client.Close();

            if( response != null )
            {
                response.Content.Seek( 0, SeekOrigin.Begin );
            }

            return response;
        }

        private bool certifyServer(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            Debug.WriteLine(certificate.Subject);
            Debug.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }
    }
}