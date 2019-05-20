using System.Text;

namespace RedisDotNet.Commands
{
    public class Rename : BaseCommand
    {
        public Rename(string host, int port) 
            : base(host, port) { }

        public void Execute(string oldKey, string newKey)
        {
            var dataToBeSent = new StringBuilder();
            dataToBeSent.Append("*3\r\n");
            dataToBeSent.Append("$6\r\nRENAME\r\n");
            dataToBeSent.Append("$").Append(Encoding.UTF8.GetByteCount(oldKey)).Append("\r\n");
            dataToBeSent.Append(oldKey).Append("\r\n");
            dataToBeSent.Append("$").Append(Encoding.UTF8.GetByteCount(newKey)).Append("\r\n");
            dataToBeSent.Append(newKey).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
            
            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("not rename key");
            }
            
            var line = ReadLine();
            if (line != success)
            {
                throw new RedisException(line.StartsWith ("ERR ") ? line.Substring (4) : line);
            }
        }
    }
}