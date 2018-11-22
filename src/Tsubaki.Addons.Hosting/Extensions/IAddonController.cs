namespace Tsubaki.Addons.Hosting
{
    public interface IAddonController
    {
        bool IsEnabled { get; }

        void Disable();
        void Enable();
        void Toggle();
    }
}