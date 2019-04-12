namespace RedisDotNet
{
    public interface IRedis
    {
        void Set<T>(string key, T value);
    }
}