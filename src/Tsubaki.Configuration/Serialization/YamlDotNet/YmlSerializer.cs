// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Serialization.YamlDotNet
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using Tsubaki.Configuration.Contracts;

    using YamlDeserializer = global::YamlDotNet.Serialization.Deserializer;
    using YamlSerializer = global::YamlDotNet.Serialization.Serializer;

    public sealed class YmlSerializer : ISerializer
    { 
        private readonly YamlDeserializer _deserializer;
        private readonly YamlSerializer _serializer;

        public YmlSerializer()
        {
            this._deserializer = new YamlDeserializer();

            this._serializer = new YamlSerializer();
        }

        public bool TryDeserialize<T>(TextReader reader, out T result)
        {
            result = default(T);
            try
            {
                result = this._deserializer.Deserialize<T>(reader);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public bool TrySerialize<T>(TextWriter writer, T graph)
        {
            try
            {
                this._serializer.Serialize(writer, graph);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}