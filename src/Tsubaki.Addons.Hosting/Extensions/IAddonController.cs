// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
namespace Tsubaki.Addons.Hosting.Extensions
{
    public interface IAddonController
    {
        bool IsEnabled { get; }

        void Disable();

        void Enable();

        void Toggle();
    }
}