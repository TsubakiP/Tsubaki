
namespace Tsubaki.Messaging.Endpoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tsubaki.Messaging.Dialogflow;
    using Tsubaki.Addons.Hosting;
    using System.Diagnostics;
    partial class Lighthouse
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
                this._lighthouse.Send -= this._messenger.OnReceived;
                Debug.WriteLine("disposed");
            }
        }

    }




    public partial class Lighthouse
    { 


        public IDisposable Register(IMessenger messenger)
        {
            messenger.Send += this.OnReceived;
            this.Send += messenger.OnReceived;
            return new Disposer(messenger, this);
        }

        private readonly Agent _agent;
        public Lighthouse(bool dev)
        {
            this._agent = new Agent(dev);
        }

        internal event EventHandler<ReceivedMessageEventArgs> Send;
        internal async void OnReceived(object sender, SentMessageEventArgs e)
        {
            var result = await this._agent.QueryAsync(e.Message);
            var parameters = result.Parameters;
            foreach (var item in parameters.Keys)
            {
                Debug.WriteLine("Key: "+ item); 
            }
            Debug.WriteLine("");
            var executed = Addons.Execute(parameters.Keys.ToArray(), parameters.Values.ToArray(), out var callback);
            if (executed == ExecutedResult.Success)
            {
                var msg = callback as string;
                Console.WriteLine(msg);
                this.Send?.Invoke(this, new ReceivedMessageEventArgs(new MessageBody(msg)));
                Console.WriteLine(this.Send == null);

            }
            else
            {
                Debug.WriteLine("Failure: "+executed);
            }

            /*
            bool TryRandomTaker(IEnumerable<string> messages, out string once)
            {
                once = "";
                if (messages is null)
                    return false;
                var array = messages.ToArray();
                switch (array.Length)
                {
                    case 0: return false;
                    case 1:
                        once = array[0];
                        return true;
                    default:
                        var random_index = new Random(Guid.NewGuid().GetHashCode()).Next(0, array.Length);
                        once = array[random_index];
                        return true;
                }

            }
            */
        }
        
    }

}
