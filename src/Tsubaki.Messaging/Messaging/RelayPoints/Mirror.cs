
namespace Tsubaki.Messaging.RelayPoints
{
    public sealed class Echo : Lighthouse
    {
        protected override void OnReceived(object sender, SentMessageEventArgs e)
            => this.Send(sender, new ReceivedMessageEventArgs(e.Message));
        
    }

}
