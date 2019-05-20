namespace RedisDotNet
{
    public interface IRedis
    {
        void Set(string key, string value);
        void Set(string key, byte[] value);
        void Set(string key, string value, int expireInSeconds);
        void FlushAll();
        void Remove(string key);
        bool ContainsKey(string key);
        void Rename(string oldKey, string newKey);
        string Get(string key);
    }
}