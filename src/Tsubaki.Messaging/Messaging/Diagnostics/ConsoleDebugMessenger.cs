// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging.Diagnostics
{
    using System;

    using Tsubaki.Messaging.EndPoints;

    public sealed class ConsoleMessenger : MessengerBase
    {
        public override void Send(MessageBody message)
        {
            base.Send(message);
        }

        protected override void OnReceived(object sender, ReceivedMessageEventArgs e)
        {
            Console.WriteLine($"{sender ?? "<null>"}: {e.Message.Payload}");
        }
    }
}