// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting
{
    using System.Collections.Generic;

    using Tsubaki.Configuration;
    using Tsubaki.Configuration.Attributes;

    partial class Addons
    {
        [Route(PATH + "/Activations")]
        private sealed class AddonActivation : SelfKeeper<AddonActivation>, IAddonActivation
        {
            private const bool ENABLED_DEFAULT = true;
            public Dictionary<string, bool> EnabledList { get; private set; }

            public bool this[string name]
            {
                get
                {
                    if (this.EnabledList.TryGetValue(name, out var result))
                    {
                        return result;
                    }
                    else
                    {
                        return this[name] = ENABLED_DEFAULT;
                    }
                }
                set
                {
                    this.EnabledList[name] = value;
                    this.Save();
                }
            }

            public AddonActivation()
            {
                this.EnabledList = new Dictionary<string, bool>();
            }
        }

        public static readonly IAddonActivation Toggle = AddonActivation.Load();
    }
}