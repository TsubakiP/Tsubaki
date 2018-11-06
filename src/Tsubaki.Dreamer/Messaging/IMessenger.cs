
namespace Tsubaki.Dreamer.Messaging
{
    using System;

    public interface IMessenger
    {
        event EventHandler<SentMessageEventArgs> Send;
        void OnReceived(object sender, ReceivedMessageEventArgs e);
    }
}
