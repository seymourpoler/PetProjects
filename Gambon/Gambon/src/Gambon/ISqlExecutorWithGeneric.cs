using System.Collections.Generic;

namespace Gambon
{
    public interface ISqlExecutorWithGeneric
    {
        IEnumerable<T> ExecuteReader<T>(string sql) where T : class;
    }
}
