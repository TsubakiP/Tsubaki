// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;
    using System.Linq;
    using Tsubaki.Addons.Hosting.Internal;
    using Tsubaki.Addons.Contracts;
    using System.Collections;

    /// <summary>
    /// The addons container.
    /// </summary>
    public static class Addons
    {

        private const string PATH = "./" + nameof(Addons);
        private static volatile List<Lazy<IAddonContract, IAddonDefinition>> s_container;
        static Addons()
        {
            var aggregate = new AggregateCatalog();
            AddonUtils.AddAssemblies(aggregate);
            AddonUtils.AddDirectories(aggregate, PATH);

            s_container = new LazyContainer<IAddonContract, IAddonDefinition>(aggregate).ToList();

#if DEBUG
            Debug.WriteLine("Loading addons...");
            foreach (var item in s_container)
            {
                var s = string.IsNullOrWhiteSpace(item.Metadata.Name) ? "<unnamed addon>" : item.Metadata.Name;
                Debug.WriteLine(s);
            }
            Debug.WriteLine("Loaded all addons");
#endif
        }

        public static IReadOnlyList<string> Names
        {
            get
            {
                lock (((ICollection)s_container).SyncRoot)
                {
                    var list = s_container.Select(x => x.Metadata.Name).ToArray();
                    return list;
                }
            }
        }

        /// <summary>
        /// Gets the specified <see cref="IAddonContract" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="force">if set to <c>true</c> [force].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">message - name</exception>
        /// <exception cref="AddonNotFoundException"></exception>
        public static IAddonContract Get(string name, bool force = true)
        {
            if (string.IsNullOrEmpty(name))
                goto Failure;

            lock (((ICollection)s_container).SyncRoot)
            {
                foreach (var lz in s_container)
                {
                    if (string.Equals(lz.Metadata.Name, name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (force || (lz.Metadata is IAddonActivation activation && activation.Enabled))
                        {
                            return lz.Value;
                        }

                    }
                }
            }

            Failure:
            return NoAction.Singleton;
        }


        /// <summary>
        /// Executes the specified domains.
        /// </summary>
        /// <param name="domains">The domains.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public static ExecutedResult Execute(string[] domains, string[] args, out object callback)
        {
            var r = default(ExecutedResult);
            callback = null;


            lock (((ICollection)s_container).SyncRoot)
            {
                switch (s_container.Count)
                {
                    case 0:
                        r = ExecutedResult.NoAddon;
                        break;

                    case 1:
                        {
                            var m = s_container[0];
                            var diff = Diff.Compare(m.Metadata.Domains, domains);
                            if (diff != 0.0)
                            {
                                var result = m.Value.Execute(args, out callback);
                                r = result.HasValue ? (result.Value ? ExecutedResult.Success : ExecutedResult.Failure) : ExecutedResult.Disabled;
                            }
                            else
                                r = ExecutedResult.NoMatched;
                            break;
                        }

                    default:
                        {
                            var top_v = 0.0;
                            var a = default(Lazy<IAddonContract, IAddonDefinition>);
                            foreach (var m in s_container)
                            {
                                var diff = Diff.Compare(m.Metadata.Domains, domains);
                                // Debug.WriteLine("N: " + m.Metadata.Name + " | " + diff);
                                if (diff >= top_v)
                                {
                                    top_v = diff;
                                    a = m;
                                }
                            }
                            if (top_v == 0.0)
                                r = ExecutedResult.NoMatched;
                            else
                            {
                                //Found the highest similar object
                                var result = a.Value.Execute(args, out callback);
                                r = result.HasValue ? (result.Value ? ExecutedResult.Success : ExecutedResult.Failure) : ExecutedResult.Disabled;
                            }
                            break;
                        }
                }
            }
            return r;
        }
    }

    
}