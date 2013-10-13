using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Entities;

namespace Domain
{
    public static class Extensions
    {
        public static string ToJSON<T>(this List<T> list)
        {
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(list);
        }
    }
}
