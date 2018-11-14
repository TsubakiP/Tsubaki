// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
namespace Tsubaki.Addons
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Runtime.InteropServices;

    using Tsubaki.Configuration;
    using Tsubaki.Addons.Contracts;

    using System.Collections.Generic;
    using System.Collections;

    /// <summary>
    /// Basic information about tagging addons
    /// </summary>
    /// <seealso cref="System.ComponentModel.Composition.ExportAttribute" />
    /// <seealso cref="Tsubaki.Addons.Contracts.IAddonDefinition" />
    /// <seealso cref="ExportAttribute" />
    /// <seealso cref="IAddonDefinition" />
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class AddonAttribute : ExportAttribute, IAddonDefinition, IAddonActivation
    {
        /// <summary>
        /// Gets the domains.
        /// </summary>
        /// <value>The domains.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] Domains { get; }


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AddonAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="domains">The domains.</param>
        public AddonAttribute(string name, params string[] domains) : base(typeof(IAddonContract))
        {
            this.Name = string.IsNullOrWhiteSpace(name) ? this.GetType().GUID.ToString() : name;

            this.Domains = domains;

            this._config = AddonConfig.Load(this.Name);
            if (!this._config.Enabled.HasValue)
            {
                this.Enabled = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IAddonContract" /> is enabled.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Enabled
        {
            get
            {
                return this._config.Enabled.Value;
            }
            set
            {
                this._config.Enabled = value;
                this._config.Save(this.Name);
            }
        }
        private　readonly　AddonConfig _config;


        private class AddonConfig : SelfDisciplined<AddonConfig>
        {
            public bool? Enabled { get; set; } 
        }
        
    }
}