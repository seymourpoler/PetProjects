using Newtonsoft.Json;

namespace WiMi.CrossCutting.Serializers
{
	public class JsonSerializer : ISerializer
    {
		public string Serializer<T>(T entity) where T : class
		{
			return JsonConvert.SerializeObject(entity);
		}
    }
}
