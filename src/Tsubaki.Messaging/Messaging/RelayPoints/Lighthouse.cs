// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging.RelayPoints
{
    using System;

    public abstract class Lighthouse
    {
        private sealed class Disposer : IDisposable
        {
            private readonly Lighthouse _lighthouse;
            private readonly IMessenger _messenger;

            internal Disposer(IMessenger messenger, Lighthouse lighthouse)
            {
                this._messenger = messenger;
                this._lighthouse = lighthouse;
            }

            void IDisposable.Dispose()
            {
                this._messenger.Send -= this._lighthouse.OnReceived;
                this._lighthouse._send -= this._messenger.OnReceived;
            }
        }

        private event EventHandler<ReceivedMessageEventArgs> _send;

        public IDisposable Register(IMessenger messenger)
        {
            messenger.Send += this.OnReceived;
            this._send += messenger.OnReceived;
            return new Disposer(messenger, this);
        }

        protected abstract void OnReceived(object sender, SentMessageEventArgs e);

        protected void Send(object sender, ReceivedMessageEventArgs e)
        {
            this._send?.Invoke(sender, e);
        }
    }
}