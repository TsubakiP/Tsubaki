// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting
{
    using System;
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

        public bool? Execute(string[] args, IAddonInteractive interactive)
        {
            return false;
        }

        public bool Enabled { get => false; set { } }
        

        public string[] Domains => Array.Empty<string>();

        public string Name => nameof(NoAction);


#pragma warning restore CS1591
    }
}