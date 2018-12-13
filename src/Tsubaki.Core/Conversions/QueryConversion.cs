
namespace Tsubaki.Core.Conversions
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public sealed class QueryConversion : IQueryConversion
    {
        internal static IQueryConversion Create(string action, IEnumerable<KeyValuePair<string,string>> pairs)
        {
            return new QueryConversion(action, pairs);
        }  

        private QueryConversion(string action, IEnumerable<KeyValuePair<string, string>> d)
        {
            this.Intent = action;
            this.Parameters = d.ToImmutableDictionary(x => x.Key, x => x.Value);
        }
        public string Intent { get; }
        public IReadOnlyDictionary<string, string> Parameters { get; }

    }
}
