
namespace Tsubaki.Dreamer.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    

    public class Lighthouse
    { 
        public IDisposable Register(IMessenger messenger)
        {
            messenger.Send += this.OnReceived;
            this._send += messenger.OnReceived;
            return new Disposer(messenger, this);
        }
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



        private event EventHandler<ReceivedMessageEventArgs> _send;
        private void OnReceived(object sender, SentMessageEventArgs e)
        {
            Console.WriteLine("Lighthouse received: " + e.Message.Payload);
        }
        public void Send(MessageBody message)
        {
            this._send?.Invoke(this, new ReceivedMessageEventArgs( message));
        }
        
    }
}
