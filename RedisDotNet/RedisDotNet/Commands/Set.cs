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
            dataToBeSent.Append(Encoding.UTF8.GetString(values)).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
            
            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("key not set");
            }

            var line = ReadLine();
            if (line != success)
            {
                throw new RedisException(line.StartsWith ("ERR ") ? line.Substring (4) : line);
            }
        }
    }
}