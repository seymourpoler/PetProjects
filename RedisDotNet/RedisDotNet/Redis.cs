using System;
using System.Text;

namespace RedisDotNet
{
    public class Redis : IDisposable, IRedis
    {
        readonly ISocketSender _socketSender;
        
        public Redis(ISocketSender socketSender)
        {
            _socketSender = socketSender;
        }

        public void Dispose()
        {
            GC.SuppressFinalize (this);
            throw  new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            Check.IsNull<ArgumentNullException>(key);
            Check.IsNull<ArgumentNullException>(value);
            
            Set(key: key, value: Encoding.UTF8.GetBytes(value));
        }

        public void Set(string key, byte[] value)
        {
            Check.IsNull<ArgumentNullException>(key);
            Check.IsNull<ArgumentNullException>(value);
            
            var dataToBeSent = BuildDataToBeSent(key: key, values: value);
            
            _socketSender.Send(dataToBeSent);
            _socketSender.Send(value);
            _socketSender.Send(new[] {(byte) '\r', (byte) '\n'});
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

        public void FlushAll()
        {
            var dataToBeSent = new StringBuilder("*1\r\n");
            dataToBeSent.Append("$8\r\nFLUSHALL\r\n");
            _socketSender.Send(dataToBeSent.ToString());
        }

        public void Remove(string key)
        {
            var dataToBeSent = new StringBuilder("*1\r\n");
            dataToBeSent.Append("$3\r\nDEL\r\n");
            dataToBeSent.Append(key);
            _socketSender.Send(dataToBeSent.ToString());
        }

        public void ContainsKey(string key)
        {
            var dataToBeSent = new StringBuilder("*1\r\n");
            dataToBeSent.Append("$6\r\nEXISTS\r\n");
            dataToBeSent.Append(key);
            _socketSender.Send(dataToBeSent.ToString());
        }
    }
}