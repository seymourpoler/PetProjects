using System.Text;

namespace RedisDotNet.Commands
{
    public class FlushAll : BaseCommand
    {
        public FlushAll(string host, int port) 
            : base(host, port) { }

        public void Execute()
        {
            var dataToBeSent = new StringBuilder("*1\r\n");
            dataToBeSent.Append("$8\r\nFLUSHALL\r\n");
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
        }
    }
}