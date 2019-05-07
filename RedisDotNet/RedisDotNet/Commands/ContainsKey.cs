using System.Text;

namespace RedisDotNet.Commands
{
    public class ContainsKey : BaseCommand
    {
        public ContainsKey(string host, int port) 
            : base(host, port) { }

        public bool Execute(string key)
        {
            var dataToBeSent = new StringBuilder("*2\r\n");
            dataToBeSent.Append("$6\r\nEXISTS\r\n");
            dataToBeSent.Append("$").Append(key.Length).Append("\r\n");
            dataToBeSent.Append(key).Append("\r\n");
            
            _socket.Send(Encoding.UTF8.GetBytes(dataToBeSent.ToString()));
            var currentReadByteResult = _buffer.ReadByte(); 
            if (currentReadByteResult == fail)
            {
                throw new RedisException("not contains key");
            }

            const string success = "1";
            var line = ReadLine();
            if (line != success)
            {
                return false;
            }
            return true;
        }
    }
}