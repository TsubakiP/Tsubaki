// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D


namespace Tsubaki.Addons.Contracts
{
    using Tsubaki.Addons.Models;

    public interface IAddonContract
    {
        bool? Execute(Domains domains, IAddonInteractive interactive);
    }
}