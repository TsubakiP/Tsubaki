
namespace Tsubaki.ConsoleDebugger
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using Tsubaki.Messaging;
    using Tsubaki.Messaging.Diagnostics;
    using Tsubaki.Messaging.Dialogflow;
    using Tsubaki.Messaging.Endpoints;
    using Newtonsoft.Json;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons;

    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            var from = new SampleForm();
            from.ShowDialog();

        }

        [Addon("Fake", "fake")]
        public class Fake : Addon
        {
            protected override bool ExecuteImpl(string[] args, ref object callback)
            {
                Console.WriteLine("FAKE!!!");
                return true;
            }
        }
        
    }
}
