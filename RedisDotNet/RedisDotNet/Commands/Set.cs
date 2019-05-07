using System.Text;

namespace RedisDotNet.Commands
{
    public class Set : BaseCommand
    {
        public Set(string host, int port)
            : base(host: host, port: port) { }

        public void Execute(string key, byte[] values)
        {
            var dataToBeSent = new StringBuilder();
            dataToBeSent.Append("*3\r\n");
            dataToBeSent.Append("$3\r\nSET\r\n");
            dataToBeSent.Append("$").Append(Encoding.UTF8.GetByteCount(key)).Append("\r\n");
            dataToBeSent.Append(key).Append("\r\n");
            dataToBeSent.Append("$").Append(values.Length).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
            _socket.Send(values);
            _socket.Send(new[] {(byte) '\r', (byte) '\n'});
            
            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("not set key");
            }

            var line = ReadLine();
            if (line != success)
            {
                throw new RedisException(line.StartsWith ("ERR ") ? line.Substring (4) : line);
            }
        }
    }
}