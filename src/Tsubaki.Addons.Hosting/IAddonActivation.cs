// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting
{
    using System.ComponentModel;

    /// <summary>
    /// Indicates if the addon is available.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddonActivation
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contracts.IAddonContract"/> is enabled.
        /// </summary>
        /// <value>The identifier.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool this[string addonName] { get; set; }
    }
}