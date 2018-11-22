
namespace Tsubaki.Test.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tsubaki.Messaging.Diagnostics;
    using Tsubaki.Messaging.RelayPoints;
    using Tsubaki.Messaging;
    using Tsubaki.Addons;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Configuration.Attributes;
    using Tsubaki.Configuration;
    using Tsubaki.Test.MockAddon;
    using System.Reflection;
    using Tsubaki.Addons.Hosting.Extensions;

    partial class Program
    {

        static void main()
        {
            try
            {
                var addon = Addons.Get(Mock.MOCK_ADDON);
                var dec = addon.Control();
                if (dec.IsEnabled) 
                {
                    Console.WriteLine("Enable");
                    addon.Execute(new string[0], out var s);
                    Console.WriteLine(s);
                    dec.Disable();
                }
                else
                {
                    Console.WriteLine("Disable");
                    dec.Enable();
                }
                Console.WriteLine("---");
                foreach (var item in Addons.Names)
                {
                    Console.WriteLine(item);
                }
            }
            catch (TypeInitializationException e) when (e.InnerException is ReflectionTypeLoadException te)
            {
                var le = te.LoaderExceptions[0];
                Console.WriteLine(le.Message);
            }
        }
    }


}
