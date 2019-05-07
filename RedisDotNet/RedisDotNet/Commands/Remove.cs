using System.Text;

namespace RedisDotNet.Commands
{
    public class Remove : BaseCommand
    {
        public Remove(string host, int port) 
            : base(host: host, port: port) { }

        public void Execute(string key)
        {
            var dataToBeSent = new StringBuilder("*2\r\n");
            dataToBeSent.Append("$3\r\nDEL\r\n");
            dataToBeSent.Append("$").Append(key.Length).Append("\r\n");
            dataToBeSent.Append(key).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);

            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("not remove key");
            }

            const string success = "1";
            var line = ReadLine();
            if (line != success)
            {
                throw new RedisException(line.StartsWith ("ERR ") ? line.Substring (4) : line);
            }
        }
    }
}