using System;

namespace SimplePubSub
{
    public class Hub
    {
        public void Subscribe<T>(Action<T> action) where T : class
        {
            throw new NotImplementedException();
        }

        public  void Subscribe<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T>(Action<T> handler = null)
        {
            throw new NotImplementedException();
        }
    }
}
