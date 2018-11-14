﻿// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Contracts
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Provides the definition for the developer to identify addon.
    /// </summary> 
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddonDefinition
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Name { get; }

        /// <summary>
        /// Gets the domains.
        /// </summary>
        /// <value>The domains.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string[] Domains { get; }
    }
}