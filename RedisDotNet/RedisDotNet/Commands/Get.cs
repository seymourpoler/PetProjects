using System;
using System.Linq;
using System.Text;

namespace RedisDotNet.Commands
{
    public class Get : BaseCommand
    {
        public Get(string host, int port) 
            : base(host, port) { }

        public string Execute(string key)
        {
            var dataToBeSent = new StringBuilder("*2\r\n");
            dataToBeSent.Append("$3\r\nGET\r\n");
            dataToBeSent.Append("$").Append(key.Length).Append("\r\n");
            dataToBeSent.Append(key).Append("\r\n");
            
            var bytes = Encoding.UTF8.GetBytes(dataToBeSent.ToString());
            _socket.Send(bytes);
            
            //TODO: refactor
            var  line = ReadLine ();
            if (String.IsNullOrWhiteSpace(line))
                throw new RedisException("Zero length respose");
		
            var firstCharacter = line.First();
            if (firstCharacter == '-')
                throw new RedisException(line.StartsWith ("-ERR ") ? line.Substring (5) : line.Substring (1));

            if (firstCharacter == '$'){
                if (line == "$-1")
                    return null;
			
                if (Int32.TryParse (line.Substring (1), out int n))
                {
                    byte [] retbuf = new byte [n];

                    int bytesRead = 0;
                    do {
                        int read = _buffer.Read (retbuf, bytesRead, n - bytesRead);
                        if (read < 1)
                            throw new RedisException("Invalid termination mid stream");
                        bytesRead += read; 
                    }
                    while (bytesRead < n);
                    if (_buffer.ReadByte () != '\r' || _buffer.ReadByte () != '\n')
                        throw new RedisException("Invalid termination");
                    var result = Encoding.UTF8.GetString(retbuf);
                    return result;
                }
                throw new RedisException("Invalid length");
            }
            throw new RedisException("Unexpected reply: " + line);
        }
    }
}