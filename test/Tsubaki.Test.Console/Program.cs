
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

    partial class Program
    {

        static void main()
        {
            try
            {

                if (Addons.Toggle[Mock.MOCK_ADDON])
                {
                    Addons.Get(Mock.MOCK_ADDON).Execute(new string[0], out var s);
                    Console.WriteLine(s);
                    Addons.Toggle[Mock.MOCK_ADDON] = false;
                }
                else
                {
                    Addons.Toggle[Mock.MOCK_ADDON] = true;
                }
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
