using System.Text;

namespace RedisDotNet.Commands
{
    public class Set : BaseCommand
    {
        public Set(string host, int port)
            : base(host: host, port: port) { }

        public bool Execute(string key, byte[] value)
        {
            var dataToBeSent = BuildDataToBeSent(key: key, values:value);
            _socket.Send(Encoding.UTF8.GetBytes(dataToBeSent));
            _socket.Send(value);
            _socket.Send(new[] {(byte) '\r', (byte) '\n'});
            var result = _buffer.ReadByte();
            return true;
        }
        
        static string BuildDataToBeSent(string key, byte [] values)
        {
            var result = new StringBuilder();
            result.Append("*3\r\n");
            result.Append("$3\r\nSET\r\n");
            result.Append("$").Append(Encoding.UTF8.GetByteCount(key)).Append("\r\n");
            result.Append(key).Append("\r\n");
            result.Append("$").Append(values.Length).Append("\r\n");

            return result.ToString();
        }
    }
}