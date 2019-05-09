using System.Text;

namespace RedisDotNet.Commands
{
    public class Expire : BaseCommand
    {
        public Expire(string host, int port) 
            : base(host, port) { }

        public void Execute(string key, int timeInSeconds)
        {
            var dataToBeSent = new StringBuilder();
            dataToBeSent.Append("*3\r\n");
            dataToBeSent.Append("$6\r\nEXPIRE\r\n");
            dataToBeSent.Append("$").Append(Encoding.UTF8.GetByteCount(key)).Append("\r\n");
            dataToBeSent.Append(key).Append("\r\n");
            dataToBeSent.Append("$").Append(Encoding.UTF8.GetByteCount(timeInSeconds.ToString())).Append("\r\n");
            dataToBeSent.Append(timeInSeconds).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
            
            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("not set expiration time for key");
            }

            var line = ReadLine();
            const string success = "1";
            if (line != success)
            {
                throw new RedisException(line.StartsWith ("ERR ") ? line.Substring (4) : line);
            }
        }
    }
}