
namespace Tsubaki.Addons.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Composition.Hosting;
    using System.Diagnostics;
    using System.Linq;
    using Tsubaki.Addons.Hosting.Internal;
    using Tsubaki.Addons.Contracts;
    using System.Collections;
    using System.Composition;
    using System.Composition.Convention;
    using System.IO;
    using System.Reflection;
    using Tsubaki.Configuration;
    using System.ComponentModel;
    using Tsubaki.Configuration.Attributes;
   
    /// <summary>
    /// The addons container.
    /// </summary>
    public  static partial class Addons
    {
        private sealed class AddonDefinition : IAddonDefinition
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AddonDefinition(IDictionary<string, object> properties)
            {
                this.Name = properties[nameof(this.Name)] as string;
                this.Domains = properties[nameof(this.Domains)] as string[];
            }
            public string Name { get; }
            public string[] Domains { get; }
        }
        


        private const string PATH = "./" + nameof(Addons);

        private readonly static List<ExportFactory<IAddonContract, AddonDefinition>> s_container;



        static Addons()
        {
            var convention = new ConventionBuilder();
            convention.ForTypesDerivedFrom<Addon>().Export<IAddonContract>();

            var container = new ContainerConfiguration();
            var assemblies = new HashSet<Assembly>();

#if DEBUG
            var inModules = AppDomain.CurrentDomain.GetAssemblies();            
            foreach (var a in inModules)
            {
                assemblies.Add(a);
            }
#endif


            var dir = new DirectoryInfo(PATH);
            if (!dir.Exists)
            {
                dir.Create();
            }
            else
            {
                var directories = dir.GetDirectories("*", SearchOption.AllDirectories);
                foreach (var folder in directories)
                {
                    var dlls = folder.GetFiles("*.dll");
                    foreach (var dll in dlls)
                    {
                        try
                        {
                            var assembly = Assembly.LoadFile(dll.FullName);
                            assemblies.Add(assembly);
                        }
                        catch
                        {
                        }

                    }

                }

            }
#if DEBUG
            foreach (var a in assemblies)
            {
                Debug.WriteLine($"Assembly: {a}");
                assemblies.Add(a);
            }
#endif

            try
            {
                container.WithAssemblies(assemblies, convention);
                var host =  container.CreateContainer();

                s_container =  host.GetExports<ExportFactory<IAddonContract, AddonDefinition>>().ToList();
                                
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (var le in e.LoaderExceptions)
                {
                    Debug.WriteLine(le.Message);
                }
            }
                    
            
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

        /*
        public static IAddonActivation GetActivation(string name)
        {
            lock (((ICollection)s_container).SyncRoot)
            {
                foreach (var export in s_container)
                {
                    if (string.Equals(export.Metadata.Name, name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return export.Metadata;
                    }
                }
            }
            return NoAction.Singleton;
        }*/


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
                        if (force || Toggle[lz.Metadata.Name])
                        //    if (force || (lz.Metadata is IAddonActivation activation && activation.Enabled))
                        {
                            return lz.CreateExport().Value;
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
        public static ExecutedResult Execute(string[] domains, string[] args, IAddonInteractive interactive)
        {
            var r = default(ExecutedResult);

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
                            if (diff != 0.0 && Toggle[m.Metadata.Name])
                            {
                                var result = m.CreateExport().Value.Execute(args, interactive);
                                r = result.HasValue ? (result.Value ? ExecutedResult.Success : ExecutedResult.Failure) : ExecutedResult.Disabled;
                            }
                            else
                                r = ExecutedResult.NoMatched;
                            break;
                        }

                    default:
                        {
                            var top_v = 0.0;
                            var a = default(ExportFactory<IAddonContract, AddonDefinition>);
                            foreach (var m in s_container)
                            {
                                var diff = Diff.Compare(m.Metadata.Domains, domains);
                                // Debug.WriteLine("N: " + m.Metadata.Name + " | " + diff);
                                if (diff >= top_v && Toggle[m.Metadata.Name])
                                {
                                    top_v = diff;
                                    a = m;
                                }
                            }
                            if (top_v == 0.0)
                                r = ExecutedResult.NoMatched;
                            else if(Toggle[a.Metadata.Name])
                            {
                                //Found the highest similar object
                                var result = a.CreateExport().Value.Execute(args, interactive);
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
