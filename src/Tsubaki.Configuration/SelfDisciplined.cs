// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;

    using Tsubaki.Configuration.Attributes;
    using Tsubaki.Configuration.Contracts;
    using Tsubaki.Configuration.Serialization.YamlDotNet;

    public abstract class SelfDisciplined<T> : IDisposable where T : class, new()
    {
        private readonly static ISerializer s_default = new YmlSerializer();

        private static ISerializer s_serializer;

        public static ISerializer Serializer
        {
            get => s_serializer ?? s_default;
            set => s_serializer = value;
        }

        public static T Load(bool createWithoutThrown = true)
        {
            var type = typeof(T);
            var file = type.GetCustomAttribute<RouteAttribute>() is RouteAttribute cf ? cf.File ?? type.Name : type.Name;
            var f = new FileInfo(file);
            if (!f.Exists)
                return new T();

            var result = default(T);
            using (var fs = f.Open(FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fs))
                {
                    if (!Serializer.TryDeserialize(sr, out result))
                    {
                        result = createWithoutThrown
                            ? new T()
                            : throw new SerializationException("can't deserialize yaml");
                    }
                }
            }
            return result;
        }

        public bool Save()
        {
            var type = this.GetType();
            var file = type.GetCustomAttribute<RouteAttribute>() is RouteAttribute cf ? cf.File ?? type.Name : type.Name;
            var f = new FileInfo(file);
            using (var fs = f.Open(FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    return Serializer.TrySerialize(sw, this);
                }
            }
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
            this.Save();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose()
        {
        }
    }
}