namespace Gambon.Sql
{
    public abstract class SqlBaseBuilder
    {
        protected bool ThereIsNo(dynamic condition)
        {
            return condition == null;
        }
    }
}
