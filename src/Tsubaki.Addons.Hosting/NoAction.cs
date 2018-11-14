// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting
{
    using Tsubaki.Addons.Contracts;

    /// <summary>
    /// No action addon, When provider can't find the addon will return this instance back.
    /// </summary>
    /// <seealso cref="Tsubaki.Addons.Contracts.IAddonContract" />
    public sealed class NoAction : IAddonContract
    {
#pragma warning disable CS1591
        static NoAction()
        {
            Singleton = new NoAction();
        }
        internal static NoAction Singleton { get; }

        private class NoActionDefinition : IAddonDefinition
        {
            public string Name { get; }

            public string[] Domains { get; }

            internal NoActionDefinition()
            {
                this.Name = "NoAction";
                this.Domains = new string[0];
            }
        }

        private NoAction()
        {
            this.Definition = new NoActionDefinition();
        }

        public IAddonDefinition Definition { get; }

        public bool? Execute(string[] args, out object callback)
        {
            callback = null;
            return false;
        }

        public bool Enabled { get => false; set { } }

#pragma warning restore CS1591
    }
}