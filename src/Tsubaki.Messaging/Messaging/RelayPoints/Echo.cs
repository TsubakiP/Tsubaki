// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging.RelayPoints
{
    public sealed class Echo : Lighthouse
    {

        protected override void OnReceived(object sender, SentMessageEventArgs e)
            => this.Send(sender, new ReceivedMessageEventArgs(e.Message));
    }
}