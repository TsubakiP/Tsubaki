
namespace Tsubaki.Core.Conversions
{
    using System.Collections.Generic;

    public interface IQueryConversion
    {
        string Intent { get; }
        IReadOnlyDictionary<string, string> Parameters { get; }
    }
}
