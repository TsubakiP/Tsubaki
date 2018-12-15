// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.MockAddon
{
    using Tsubaki.Addons;
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Models;

    [Addon("Mock", "mock")]
    public class Mock : Addon
    {
        public const string MOCK_ADDON = nameof(Mock);

        protected override bool ExecuteImpl(Domains domains, IAddonInteractive interactive)
        {
            interactive.WriteText("Mock Addon");
            return true;
        }
    }
}