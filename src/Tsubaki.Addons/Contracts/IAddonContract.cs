
namespace Tsubaki.Addons.Contracts
{
    using System.Composition;
    
    public interface IAddonContract
    {
        bool? Execute(string[] args, IAddonInteractive interactive);
    }

}
