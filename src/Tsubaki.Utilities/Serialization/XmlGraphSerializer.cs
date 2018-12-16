

namespace Tsubaki.Utilities.Serialization.Xml
{
    using System.Xml.Serialization;
    using System.Xml;
    using System.IO;

    public class XmlGraphSerializer : IGraphSerializer
    {
        public virtual T From<T>(string xml)
        {
            var xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(xml);
                var reader = new XmlNodeReader(xdoc.DocumentElement);
                var ser = new XmlSerializer(typeof(T));
                var graph = (T)ser.Deserialize(reader);

                return graph;
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
                var ser = new XmlSerializer(typeof(T));
                var writer = new StringWriter();
                ser.Serialize(writer, graph);
                return writer.ToString();
            }
            catch
            {
                return SerializerHelper.Default();
            }
        }
    }
}

