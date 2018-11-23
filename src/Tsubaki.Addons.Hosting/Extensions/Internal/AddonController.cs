// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting.Extensions.Internal
{
    using System.Reflection;

    using Tsubaki.Addons.Contracts;

    internal sealed class AddonController : IAddonController
    {
        private readonly string _name;
        private bool _stateCache;
        bool IAddonController.IsEnabled => this.Enabled;

        internal bool Enabled
        {
            get => this._stateCache;

            private set
            {
                if (this._stateCache != value)
                {
                    this._stateCache = value;
                    Addons.Toggle[this._name] = value;
                }
            }
        }

        internal AddonController(IAddonContract addon)
        {
            var attr = addon.GetType().GetCustomAttribute<AddonAttribute>();
            if (attr is IAddonDefinition def)
            {
                this._name = def.Name;
                this.Enabled = Addons.Toggle[this._name];
            }
        }

        void IAddonController.Disable()
        {
            this.Enabled = false;
        }

        void IAddonController.Enable()
        {
            this.Enabled = true;
        }

        void IAddonController.Toggle()
        {
            this.Enabled = !this.Enabled;
        }
    }
}