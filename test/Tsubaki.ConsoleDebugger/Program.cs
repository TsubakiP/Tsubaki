
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
    class Program
    {

        static void Main(string[] args)
        {
            /*
            var df = new Agent(false);
            var s = df.QueryAsync(new MessageBody("今天天氣如何"));
            var json = JsonConvert.SerializeObject(s, Formatting.Indented);
            Console.WriteLine(json);
            Console.ReadKey();
            return;*/

            var textM = new ConsoleDebugMessenger();
            var lighthouse = new Lighthouse(false);
            var m = new MessageBody("今天天氣如何");

            using (lighthouse.Register(textM))
            {
                textM.Send(m);
            }

            
            Console.ReadKey();
        }
    }
}
