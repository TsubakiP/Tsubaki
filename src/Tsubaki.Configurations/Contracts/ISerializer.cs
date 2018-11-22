// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Contracts
{
    using System.IO;

    public interface ISerializer
    {
        bool TryDeserialize<T>(TextReader reader, out T result);

        bool TrySerialize<T>(TextWriter writer, T graph);
    }
}