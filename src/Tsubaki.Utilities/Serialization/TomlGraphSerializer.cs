

namespace Tsubaki.Utilities.Serialization.Toml
{
    using Nett;

    public class TomlGraphSerializer : IGraphSerializer
    {
        public virtual T From<T>(string toml)
        {
            try
            {
                return Toml.ReadString<T>(toml);
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
                return Toml.WriteString(graph);
            }
            catch
            {

                return SerializerHelper.Default();
            }
        }
    }

}

