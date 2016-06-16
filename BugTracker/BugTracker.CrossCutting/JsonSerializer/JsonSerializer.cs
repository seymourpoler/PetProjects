using System;
using Newtonsoft.Json;

namespace BugTracker.CrossCutting.JsonSerializer
{
	public interface IJsonSerializer{
		
		string Serialize<T> (T entity);
		T Deserialize<T> (string data);
	}
	public class JsonSerializer : IJsonSerializer
	{
		public string Serialize<T> (T entity)
		{
			return JsonConvert.SerializeObject (entity);
		}

		public T Deserialize<T> (string data)
		{
			return JsonConvert.DeserializeObject<T> (data);
		}
	}
}

