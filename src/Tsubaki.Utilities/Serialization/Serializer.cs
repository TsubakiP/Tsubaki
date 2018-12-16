
namespace Tsubaki.Utilities.Serialization
{
    using Tsubaki.Utilities.Serialization.Json;
    using Tsubaki.Utilities.Serialization.Xml;
    using Tsubaki.Utilities.Serialization.Yaml;
    using System;
    using Tsubaki.Utilities.Serialization.Toml;


    /// <summary>
    /// The general serializers
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// The Json serializer.
        /// </summary>
        public static IGraphSerializer Json { get; } = new JsonGraphSerializer();

        /// <summary>
        /// The Yaml serializer.
        /// </summary>
        public static IGraphSerializer Yaml { get; } = new YamlGraphSerializer();

        /// <summary>
        /// The Xml serializer.
        /// </summary>
        public static IGraphSerializer Xml { get; } = new XmlGraphSerializer();

        /// <summary>
        /// The Toml serializer.
        /// </summary>
        public static IGraphSerializer Toml { get; } = new TomlGraphSerializer();
        

    }
}

