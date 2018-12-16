
namespace Tsubaki.Utilities.Serialization
{
    using System.IO;
    using System.Collections;

    public interface IGraphSerializer
    {
        T From<T>(string text);
        string To<T>(T graph);
    }
}

