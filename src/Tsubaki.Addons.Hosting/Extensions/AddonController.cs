
namespace Tsubaki.Addons.Hosting
{
    using System.Reflection;
    using Tsubaki.Addons.Contracts;

    internal sealed class AddonController : IAddonController
    {
        private bool _stateCache;
        internal AddonController(IAddonContract addon)
        {
            var attr = addon.GetType().GetCustomAttribute<AddonAttribute>();
            if (attr is IAddonDefinition def)
            {
                this._name = def.Name;
                this.Enabled = Addons.Toggle[this._name];
            }
        }
        private readonly string _name;

        bool IAddonController.IsEnabled => this.Enabled;

        internal bool Enabled
        {
            get => this._stateCache;
            
            private set
            {
                if(this._stateCache != value)
                {
                    this._stateCache = value;
                    Addons.Toggle[this._name] = value;
                }
            }
        }

        void IAddonController.Enable()
        {
            this.Enabled = true;
        }

        void IAddonController.Disable()
        {
            this.Enabled = false;
        }

        void IAddonController.Toggle()
        {
            this.Enabled = !this.Enabled;
        }
    }

}
