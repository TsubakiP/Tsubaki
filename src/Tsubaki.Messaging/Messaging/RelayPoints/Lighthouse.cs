
namespace Tsubaki.Messaging.RelayPoints
{
    using System;

    public abstract class Lighthouse
    {
        private sealed class Disposer : IDisposable
        {
            private readonly IMessenger _messenger;
            private readonly Lighthouse _lighthouse;

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

        public IDisposable Register(IMessenger messenger)
        {
            messenger.Send += this.OnReceived;
            this._send += messenger.OnReceived;
            return new Disposer(messenger, this);
        }        

        private event EventHandler<ReceivedMessageEventArgs> _send;

        protected void Send(object sender, ReceivedMessageEventArgs e)
        {
            this._send?.Invoke(sender, e);
        }

        protected abstract void OnReceived(object sender, SentMessageEventArgs e);
    } 

}
