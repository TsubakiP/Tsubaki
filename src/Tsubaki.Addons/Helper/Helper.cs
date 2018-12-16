// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Helper
{
    using System.Diagnostics;
    using static Tsubaki.Utilities.Serialization.Serializer;

    public static class Helper
    {
        /// <summary>
        /// Deserializes the JSON to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the graph to deserialize to.</typeparam>
        /// <param name="json">The JSON data to deserializes.</param>
        /// <returns>The deserialized graph from the JSON string.</returns>
        [DebuggerStepThrough]
        public static T FromJson<T>(this string json)
        {
            return Json.From<T>(json);
        }

        /// <summary>
        /// Deserializes the TOML to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the graph to deserialize to.</typeparam>
        /// <param name="toml">The TOML data to deserializes.</param>
        /// <returns>The deserialized graph from the TOML string.</returns>
        [DebuggerStepThrough]
        public static T FromToml<T>(this string toml)
        {
            return Toml.From<T>(toml);
        }

        /// <summary>
        /// Deserializes the XML to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the graph to deserialize to.</typeparam>
        /// <param name="xml">The XML data to deserializes.</param>
        /// <returns>The deserialized graph from the XML string.</returns>
        [DebuggerStepThrough]
        public static T FromXml<T>(this string xml)
        {
            return Xml.From<T>(xml);
        }

        /// <summary>
        /// Deserializes the YAML to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the graph to deserialize to.</typeparam>
        /// <param name="yaml">The YAML data to deserializes.</param>
        /// <returns>The deserialized graph from the YAML string.</returns>
        [DebuggerStepThrough]
        public static T FromYaml<T>(this string yaml)
        {
            return Yaml.From<T>(yaml);
        }

        /// <summary>
        /// Serializes the specified graph to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the graph to serialize to.</typeparam>
        /// <param name="graph">The graph to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        [DebuggerStepThrough]
        public static string ToJson<T>(this T graph)
        {
            return Json.To(graph);
        }

        /// <summary>
        /// Serializes the specified graph to a TOML string.
        /// </summary>
        /// <typeparam name="T">The type of the graph to serialize to.</typeparam>
        /// <param name="graph">The graph to serialize.</param>
        /// <returns>A TOML string representation of the object.</returns>
        [DebuggerStepThrough]
        public static string ToToml<T>(this T graph)
        {
            return Toml.To(graph);
        }

        /// <summary>
        /// Serializes the specified graph to a XML string.
        /// </summary>
        /// <typeparam name="T">The type of the graph to serialize to.</typeparam>
        /// <param name="graph">The graph to serialize.</param>
        /// <returns>A XML string representation of the object.</returns>
        [DebuggerStepThrough]
        public static string ToXml<T>(this T graph)
        {
            return Xml.To(graph);
        }

        /// <summary>
        /// Serializes the specified graph to a YAML string.
        /// </summary>
        /// <typeparam name="T">The type of the graph to serialize to.</typeparam>
        /// <param name="graph">The graph to serialize.</param>
        /// <returns>A YAML string representation of the object.</returns>
        [DebuggerStepThrough]
        public static string ToYaml<T>(this T graph)
        {
            return Yaml.To(graph);
        }
    }
}