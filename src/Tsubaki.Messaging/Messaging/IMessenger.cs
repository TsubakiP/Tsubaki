// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging
{
    using System;

    public interface IMessenger
    {
        event EventHandler<SentMessageEventArgs> Send;

        void OnReceived(object sender, ReceivedMessageEventArgs e);
    }
}