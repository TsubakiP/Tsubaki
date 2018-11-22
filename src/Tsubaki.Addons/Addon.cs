// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons
{
    using System;

    using System.ComponentModel;
    using System.Runtime.InteropServices;

    using Tsubaki.Addons.Contracts;

    /// <summary>
    /// Provides basic features for the addon.
    /// </summary>
    /// <seealso cref="Tsubaki.Addons.Contracts.IAddonContract"/>
    [Guid("BD47D5EE-83D5-4017-B5F3-1E8549402470")]
    public abstract class Addon : IAddonContract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Addon"/> class.
        /// </summary>
        protected Addon()
        {
            this.OnInitialize();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool? IAddonContract.Execute(string[] args, out object callback)
        {
            callback = null;

            return this.ExecuteImpl(args, ref callback);
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        protected abstract bool ExecuteImpl(string[] args, ref object callback);

        /// <summary>
        /// Called when object initialize.
        /// </summary>
        protected virtual void OnInitialize()
        {
        }
    }
}