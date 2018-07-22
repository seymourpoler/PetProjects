using Newtonsoft.Json;

namespace WiMi.CrossCutting
{
	public class JsonSerializer : ISerializer
    {
		public string Serializer<T>(T entity) where T : class
		{
			return JsonConvert.SerializeObject(entity);
		}
    }
}
