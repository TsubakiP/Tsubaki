
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
