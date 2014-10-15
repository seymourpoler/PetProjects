using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace TodoList.Tests.UI.Controllers
{
    public class JsonHelper
    {
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}
