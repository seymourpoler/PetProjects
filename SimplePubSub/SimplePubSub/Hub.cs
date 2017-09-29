using System;
using System.Collections.Generic;

namespace SimplePubSub
{
    public class Hub
    {
        private Dictionary<string, Delegate> handlers;
        private object locker;
        public Hub()
        {
            locker = new object();
            handlers = new Dictionary<string, Delegate>();
        }

        public void Subscribe<T>(Action<T> action) where T : class
        {
            lock (locker)
            {
                handlers.Add(typeof(T).ToString(), action);
            }
        }

        public  void Publish<T>(T message) where T : class
        {
            lock(locker)
            {
                var handler = handlers[typeof(T).ToString()];
                if (handler == null) return;
                ((Action<T>)handler)(message);
            }
        }

        public void Unsubscribe<T>(Action<T> handler = null)
        {
            throw new NotImplementedException();
        }
    }
}
