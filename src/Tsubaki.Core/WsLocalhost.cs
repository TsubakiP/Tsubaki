
namespace Tsubaki.Core
{
    using WebSocketSharp.Server;
    using Tsubaki.Core.Conversions;
    using Tsubaki.Addons.Contracts;
    using WebSocketSharp;
    using System.Linq;

    public sealed class WsLocalhost
    {

        private readonly WebSocketServer _wss;
        public WsLocalhost(IQueryClient client, ushort userInterfacePort = 8888)
        {
            this._wss = new WebSocketServer(userInterfacePort);
            this._wss.AddWebSocketService<DialogflowCallback>("/", x => x.Init(client));
            this._wss.Start();

        }
        

        private sealed class DialogflowCallback : WebSocketBehavior, IAddonInteractive
        {
            public void Init(IQueryClient client)
            {
                this._client = client;
            }

            private IQueryClient _client;

            protected override void OnMessage(MessageEventArgs e)
            {
                if (e.IsText)
                {
                    var q = this._client.Query(e.Data);
                    var result = Addons.Hosting.Addons.Execute(q.Parameters.Keys.ToArray(), q.Parameters.Values.ToArray(), this);
                    if (result != Addons.Hosting.ExecutedResult.Success)
                    {
                        this.WriteText("Module not found");
                    }
                }
            }


            public void WriteText(string message) => this.Send(message);

            public bool IsFixed => true;
        }

    }


}
