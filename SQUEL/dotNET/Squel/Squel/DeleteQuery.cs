using System;

namespace Squel
{
    public class DeleteQuery : QueryBase, IQuery
    {
        private const string DELETE = "DELETE ";
        private const string FROM = "FROM ";

        private string _from;

        public string ToSQLString()
        {
            return string.Format("{0}{1}{2}", DELETE, FROM, _from);
        }

        public DeleteQuery From(string from)
        {
            _from = from;
            return this;
        }
    }
}
