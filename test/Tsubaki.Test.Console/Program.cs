// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.Console
{
    using System;

    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Hosting.Extensions;
    using Tsubaki.Test.MockAddon;

    partial class Program
    {
        public class Interactive : IAddonInteractive
        {
            public void Text(string message)
            {
                Console.WriteLine(message);
            }
        }

        private static void main()
        {
            // try {
            var ia = new Interactive();

            var addon = Addons.Get(Mock.MOCK_ADDON);
            var dec = addon.Control();
            if (dec.IsEnabled)
            {
                Console.WriteLine("Enable");
                addon.Execute(new string[0], ia);
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
            /*
        }
        catch (TypeInitializationException e) when (e.InnerException is ReflectionTypeLoadException te)
        {
            var le = te.LoaderExceptions[0];
            Console.WriteLine(le.Message);
        }*/
        }
    }
}