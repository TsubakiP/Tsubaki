// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Contracts
{
    using System.ComponentModel;
    using System.ComponentModel.Composition;

    /// <summary>
    /// Provides contracts for the addon.
    /// </summary>
    [InheritedExport] 
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddonContract : IAddonActivation
    {

        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAddonDefinition Definition { get; }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        bool? Execute(string[] args, out object callback);
    }
}