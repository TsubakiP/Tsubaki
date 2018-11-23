// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting.Extensions
{
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Hosting.Extensions.Internal;

    public static class AddonExtensions
    {
        public static IAddonController Control<TAddon>(this TAddon addon) where TAddon : IAddonContract
        {
            var ctrl = new AddonController(addon);
            return ctrl;
        }
    }
}