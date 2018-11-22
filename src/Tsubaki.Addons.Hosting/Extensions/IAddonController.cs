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