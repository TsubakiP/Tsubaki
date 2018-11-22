
namespace Tsubaki.Messaging.EndPoints
{
    using System;

    public abstract class MessengerBase : IMessenger
    {
        protected virtual void OnReceived(object sender, ReceivedMessageEventArgs e)
        {
        }

        void IMessenger.OnReceived(object sender, ReceivedMessageEventArgs e)
        {
            this.OnReceived(sender, e);
        }

        public virtual void Send(MessageBody message)
        {
            if( this._send is EventHandler<SentMessageEventArgs> @event)
                @event.Invoke(this, new SentMessageEventArgs(message));
            else
            {
                //Unmounted
            }
        }

        private event EventHandler<SentMessageEventArgs> _send;
        event EventHandler<SentMessageEventArgs> IMessenger.Send
        {
            add => this._send += value;
            remove => this._send -= value;
        }
    }
}
