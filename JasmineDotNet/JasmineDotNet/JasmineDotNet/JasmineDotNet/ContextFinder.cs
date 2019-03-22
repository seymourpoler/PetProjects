using System;

namespace JasmineDotNet
{
    public class ContextFinder
    {
        public Context Find(Type type)
        {
            if (type.IsNull())
            {
                return Context.CreateEmpty();
            }

            throw new System.NotImplementedException();
        }
    }
}
