
namespace Tsubaki.Dreamer.Messaging.Diagnostics
{
    using System;

#if DEBUG
    public sealed class ConsoleDebugMessenger : MessengerBase
    {
        public override void Send(MessageBody message)
        {
            base.Send(message);
        }
        protected override void OnReceived(object sender, ReceivedMessageEventArgs e)
        {
            Console.WriteLine("Debug Messenger Received: "+e.Message.Payload);
        }
    }
#endif
}
