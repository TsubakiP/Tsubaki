
namespace Tsubaki.Utilities.Serialization.Yaml
{

    using YamlDeserializer = global::YamlDotNet.Serialization.Deserializer;
    using YamlSerializer = global::YamlDotNet.Serialization.Serializer;
    using System.IO;

    public class YamlGraphSerializer : IGraphSerializer
    {
        private readonly YamlDeserializer _deserializer;
        private readonly YamlSerializer _serializer;

        public YamlGraphSerializer()
        {
            this._deserializer = new YamlDeserializer();
            this._serializer = new YamlSerializer();
        }


        public virtual T From<T>(string yaml)
        {
            try
            {
                var sr = new StringReader(yaml);
                var result = this._deserializer.Deserialize<T>(sr);
                return result;
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
                var sw = new StringWriter();
                this._serializer.Serialize(sw, graph);
                return sw.ToString();
            }
            catch
            {
                return SerializerHelper.Default();
            }
        }
    }
}

