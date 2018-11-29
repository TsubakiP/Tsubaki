// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging.EndPoints
{
    using System;

    public abstract class MessengerBase : IMessenger
    {
        event EventHandler<SentMessageEventArgs> IMessenger.Send
        {
            add => this._send += value;
            remove => this._send -= value;
        }

        private event EventHandler<SentMessageEventArgs> _send;

        protected virtual void Send(MessageBody message)
        {
            if (this._send is EventHandler<SentMessageEventArgs> @event)
                @event.Invoke(this, new SentMessageEventArgs(message));
            else
            {
                //Unmounted
            }
        }

        void IMessenger.OnReceived(object sender, ReceivedMessageEventArgs e)
        {
            this.OnReceived(sender, e);
        }

        /// <summary>
        /// this method will not do anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnReceived(object sender, ReceivedMessageEventArgs e)
        {
        }
    }
}