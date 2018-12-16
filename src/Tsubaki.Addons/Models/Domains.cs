
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
        
        /*
        public Domains(IDictionary<string, string> pairs)
        {
            var p = pairs ?? None;
            int index = 0;
            var list = new List<string>();
            foreach (var i in p)
            {


                index++;
            }
            this._pairs = p;
            this.Keywords = this._pairs.Keys.ToArray();
        }
        */
        public Domains(IEnumerable<KeyValuePair< string, string>> pairs) //: this(pairs?.ToDictionary(x => x.Key, x => x.Value))
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

        public Parameter this[string domain]
        {
            get
            {
                this.Get(domain, out var result);
                return result;
            }
        }
    }
}
