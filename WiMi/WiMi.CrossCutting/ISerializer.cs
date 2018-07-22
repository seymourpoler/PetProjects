namespace WiMi.CrossCutting
{
    public interface ISerializer
    {
		string Serializer<T>(T entity) where T : class;
    }
}
