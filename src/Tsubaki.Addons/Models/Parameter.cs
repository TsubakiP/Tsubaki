
namespace Tsubaki.Addons.Models
{
    using System;
    using System.Linq;
    using System.Text;

    public sealed class Parameter : IEquatable<Parameter>
    {
        private static readonly string EMPTY = $"{char.MinValue}{char.MinValue}{char.MinValue}{char.MinValue}";
        public static readonly Parameter Empty = new Parameter(EMPTY);

        public bool HasValue { get; }

        private readonly string _value;

        internal Parameter(string value)
        {
            this.HasValue = !string.IsNullOrWhiteSpace(value); 
            this._value = this.HasValue ? value : EMPTY;

        }
         

        public override int GetHashCode() => this._value.GetHashCode();

        public override string ToString() => this.Value;
        public bool Equals(Parameter other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }

        public string Value
        {
            get
            {
                if (!this.HasValue)
                    throw new InvalidOperationException("Empty value");
                return this._value;
            }
        }

        public static implicit operator bool(Parameter parameter)
        {
            return parameter.HasValue;
        }
    }
}
