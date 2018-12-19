
namespace Tsubaki.Addons.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Domains
    {
        
        public Domains(): this(null)
        {

        }


        private readonly IDictionary<string, string> _pairs;

        public Domains(IEnumerable<KeyValuePair< string, string>> pairs) 
        {
            this._pairs = new Dictionary<string, string>();
            var a = pairs?.ToArray() ?? new KeyValuePair<string, string>[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(a[i].Value))
                    this._pairs.Add(a[i]);
            }

            this.Keywords = this._pairs.Keys.ToArray();
        }

        public string[] Keywords { get; }

        public bool Get(string domain, out Parameter parameter)
        {
            parameter = Parameter.Empty;            

            if (this._pairs.TryGetValue(domain, out var p) && !string.IsNullOrWhiteSpace(p))
            {
                parameter = new Parameter(p);
                return true;
            }
            return false;

        }

        public bool this[string domain]
            => this.Get(domain, out var _);
        
    }
}
