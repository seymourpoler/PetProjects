namespace Infrestructura
{
    public interface IStringEncoder
    {
        byte[] EncodeToBytes(string text);
        string DecodeToString(byte[] bytes);
    }

    public class StringEncoder : IStringEncoder
    {
        public byte[] EncodeToBytes(string text)
        {
            byte[] result = new byte[text.Length * sizeof(char)];
            System.Buffer.BlockCopy(text.ToCharArray(), 0, result, 0, result.Length);
            return result;
        }

        public string DecodeToString(byte[] bytes)
        {
            char[] result = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
            return new string(result);
        }
    }
}
