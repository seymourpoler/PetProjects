namespace RedisDotNet
{
    public interface IRedis
    {
        void Set(string key, string value);
    }
}