using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Complex19.Connectivity
{
    public class GeminiDataStream : Stream
    {
        private readonly string _fileName;
        private Stream _stream = new MemoryStream();

        public GeminiDataStream(Uri uri) 
        {
            var cacheFolder = FileSystem.Current.CacheDirectory;
            _fileName = Path.Combine(cacheFolder, Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(uri.AbsoluteUri))));
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_stream.Length + count > ConnectivityConstants.MaximumMemoryCacheSize && !(_stream is MemoryStream))
            {
                var fileStream = new FileStream(_fileName, FileMode.Create, FileAccess.ReadWrite);
                _stream.CopyTo(fileStream);
                _stream.Dispose();
                _stream = fileStream;
            }

            _stream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if( _stream is FileStream)
            {
                File.Delete(_fileName);
            }
        }
    }
}
