
namespace Tsubaki.Test.MockAddon
{
    using System;
    using Tsubaki.Addons;
    using Tsubaki.Addons.Contracts;

    [Addon("Mock","mock")]
    public class Mock : Addon
    {
        public const string MOCK_ADDON = nameof(Mock);

        protected override bool ExecuteImpl(string[] args, IAddonInteractive interactive)
        {
            interactive.Text("Mock Addon");
            return true;
        }
    }
}
