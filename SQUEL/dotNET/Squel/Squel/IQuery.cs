using System;

namespace Squel
{
    public interface IQuery
    {
        string ToSQLString();
    }
}
