using System;
using System.Text;

namespace RedisDotNet.Commands
{
    public class Remove : BaseCommand
    {
        public Remove(string host, int port) 
            : base(host: host, port: port) { }

        public int Execute(string key)
        {
            var dataToBeSent = new StringBuilder("*2\r\n");
            dataToBeSent.Append("$3\r\nDEL\r\n");
            dataToBeSent.Append("$");
            dataToBeSent.Append(key.Length);
            dataToBeSent.Append("\r\n");
            dataToBeSent.Append(key);
            dataToBeSent.Append("\r\n");
            _socket.Send(Encoding.UTF8.GetBytes(dataToBeSent.ToString()));
            
            var c = _buffer.ReadByte ();
            throw new NotImplementedException();
        }
    }
}