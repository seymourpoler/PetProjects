namespace WiMi.CrossCutting.Serializers
{
    public interface ISerializer
    {
		string Serializer<T>(T entity) where T : class;
    }
}
