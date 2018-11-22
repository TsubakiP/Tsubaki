
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
        /// <value>
        /// The identifier.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool this[string addonName] { get; set; }
    }
}
