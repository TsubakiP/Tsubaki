// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons
{
    using System;

    using System.Composition;

    using Tsubaki.Addons.Contracts;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class AddonAttribute : ExportAttribute, IAddonDefinition
    {
        public string[] Domains { get; }

        public string Name { get; }

        public AddonAttribute(string name, params string[] domains) : base(typeof(IAddonContract))
        {
            this.Name = name ?? this.GetType().GUID.ToString();
            this.Domains = domains ?? Array.Empty<string>();
        }
    }
}