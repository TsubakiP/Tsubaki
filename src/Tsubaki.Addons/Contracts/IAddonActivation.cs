// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Contracts
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Indicates if the addon is available.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddonActivation
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IAddonContract"/> is enabled.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Enabled { get; set; }
    }
}