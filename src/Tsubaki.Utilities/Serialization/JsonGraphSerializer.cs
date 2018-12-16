
namespace Tsubaki.Utilities.Serialization.Json
{
    using System;
    using JsonConvert = Newtonsoft.Json.JsonConvert;
    using Formatting = Newtonsoft.Json.Formatting;

    public class JsonGraphSerializer : IGraphSerializer
    {
        public virtual T From<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return SerializerHelper.Default<T>();
            }
        }
        public virtual string To<T>(T graph)
        {
            try
            {
                return JsonConvert.SerializeObject(graph, Formatting.Indented);
            }
            catch
            {
                return SerializerHelper.Default();
            }
        }
    }

}

