
namespace Tsubaki.Addons.Hosting.Extensions
{
    using Tsubaki.Addons.Contracts;

    public static class AddonExtensions
    {
        public static IAddonController Control<TAddon>(this TAddon addon) where TAddon : IAddonContract
        {
            var ctrl = new AddonController(addon);
            return ctrl;
        }
    }
}
