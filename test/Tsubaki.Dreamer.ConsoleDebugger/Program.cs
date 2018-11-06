
namespace Tsubaki.Dreamer.ConsoleDebugger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using Tsubaki.Dreamer.Messaging;
    using Tsubaki.Dreamer.Messaging.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            var textM = new ConsoleDebugMessenger();
            var lighthouse = new Lighthouse();
            var m = new MessageBody("123");
            textM.Send(m);


            using (lighthouse.Register(textM))
            {
                textM.Send(m);
                lighthouse.Send(m);
            }
           

            lighthouse.Send(m);
            Console.ReadKey();
        }
    }
}
