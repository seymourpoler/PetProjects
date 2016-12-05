using Newtonsoft.Json;
using System.Collections.Generic;

namespace Infrestructura
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T entity) where T : class;
        T Deserialize<T>(string data) where T : class;
    }

    public class JsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T entity) where T : class
        {
            return JsonConvert.SerializeObject(entity,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter> {
                        new Newtonsoft.Json.Converters.StringEnumConverter()
                    }
                });
        }
    }
}
