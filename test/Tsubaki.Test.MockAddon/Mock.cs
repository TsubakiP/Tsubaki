
namespace Tsubaki.Test.MockAddon
{
    using System;
    using Tsubaki.Addons;

    [Addon("Mock","mock")]
    public class Mock : Addon
    {
        public const string MOCK_ADDON = nameof(Mock);

        protected override bool ExecuteImpl(string[] args, ref object callback)
        {
            callback = "Mock Addon";
            return true;
        }
    }
}
