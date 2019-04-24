namespace RedisDotNet
{
    public interface IRedis
    {
        void Set(string key, string value);
        void Set(string key, byte[] value);
        void FlushAll();
        void Remove(string key);
        void ContainsKey(string key);
    }
}