
namespace Tsubaki.Addons.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string ToJson<T>(T graph)
        {
            return JsonConvert.SerializeObject(graph, Formatting.Indented);
        }
    }
}
