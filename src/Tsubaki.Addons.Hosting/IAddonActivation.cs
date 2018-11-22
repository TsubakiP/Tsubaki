
namespace Tsubaki.Addons.Hosting
{
    public interface IAddonActivation
    {
        bool this[string addonName] { get; set; }
    }



}
