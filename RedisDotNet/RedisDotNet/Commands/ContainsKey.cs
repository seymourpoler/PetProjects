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
            dataToBeSent.Append("$");
            dataToBeSent.Append(key.Length);
            dataToBeSent.Append("\r\n");
            dataToBeSent.Append(key);
            dataToBeSent.Append("\r\n");
            var result = _socket.Send(Encoding.UTF8.GetBytes(dataToBeSent.ToString()));
            const int success = 1;
            return success == result;
        }
    }
}