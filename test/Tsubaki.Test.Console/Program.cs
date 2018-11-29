// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.Console
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Hosting.Extensions;
    using Tsubaki.Messaging;
    using Tsubaki.Messaging.EndPoints;
    using Tsubaki.Messaging.RelayPoints;
    using Tsubaki.Test.MockAddon;
    using WebSocketSharp;
    using WebSocketSharp.Server;

    partial class Program
    {


        public class Wss
        {
            private class Callback : WebSocketBehavior
            {
                protected override void OnMessage(MessageEventArgs e)
                {
                    /*
                    var utf8 = Encoding.Unicode.GetBytes(e.Data);
                    var utf8str = Encoding.UTF8.GetString(utf8);
                    Console.OutputEncoding = Encoding.UTF8;*/
                    Console.WriteLine("Server received: " + e.Data);
                    this.Send(e.Data);
                }
            }
            


            private readonly WebSocketServer _server;

            public Wss(int port)
            {
                this._server = new WebSocketServer(port);
                this._server.AddWebSocketService<Callback>("/");
                this._server.Start();
                
            }           
        }

        /*
        public class Wsc : IAddonInteractive
        {
            private readonly WebSocket _client;
            public Wsc(int port)
            {
                this._client = new WebSocket($"ws://localhost:{port}");
                this._client.Connect();
            }

            public void Text(string message)
            {
                this._client.Send(message);
            }
        }
        */



        private static void main()
        {

            var uia = new WsLocalhost();
            var df = new Dialogflow();
            df.Register(uia);
            uia.CreateDebugClient();
            uia.CreateDebugClient();


            /*
            var ia = new InteractiveBag();
            if( Addons.Execute(new[] { "mock" }, new string[0], ia) == ExecutedResult.Success)
            {
            }*/

        }

        public  sealed class WsLocalhost : MessengerBase
        {

#if DEBUG
            /// <summary>
            /// [Debug Only] Creates the new chrome client for debug. 
            /// </summary>
            /// <returns></returns>
            public Process CreateDebugClient(string contentPath = "./test.html")
            {
                try
                {
                    var fi = new FileInfo(contentPath);
                    
                    return Process.Start("chrome.exe", $@"file://{fi.FullName}" + " --incognito");
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Debug.WriteLine("Unable to find Google Chrome, chrome.exe not found!");
                }
                return default(Process);
            }
#endif
            private readonly WebSocketServer _wss;
            private readonly WebSocket _ws;
            public WsLocalhost(ushort userInterfacePort = 8888)
            {
                this._wss = new WebSocketServer(userInterfacePort);
                this._wss.AddWebSocketService<Broadcast>("/");
                this._wss.Start();

                this._ws = this.CreateClient(this.OnSend);
            }
            private WebSocket CreateClient(EventHandler<MessageEventArgs> onMessage)
            {
                var ws = new WebSocket($"ws://localhost:{this._wss.Port}");
                ws.OnMessage += onMessage;
                ws.Connect();
                return ws;
            }


            private void OnSend(object sender, MessageEventArgs e)
            {
             //   if (string.IsNullOrWhiteSpace(e.Data))
              //      return;
                Console.WriteLine("OnSend: " + e.Data + "<");
                this.Send(new MessageBody(e.Data));
            }

            protected override void OnReceived(object sender, ReceivedMessageEventArgs e)
            {
                var msg = e.Message.ToString();
              //  if (string.IsNullOrWhiteSpace(msg))
               //     return;
                Console.WriteLine("OnRecv: "+e.Message + "<");
                this._ws.Send(msg);
            }

            private sealed class Broadcast : WebSocketBehavior
            {
                protected override void OnMessage(MessageEventArgs e)
                {
                    Console.WriteLine(e.Data);
                    this.Send(">>"+e.Data);
                }
            }
        }

        public class Dialogflow : Lighthouse
        {
            protected override void OnReceived(object sender, SentMessageEventArgs e)
            {
                /*
                 * todo: 實作上傳 e.Message 到 dialogflow.com 後取得的
                 * API資料，並用 Send 函式發送給 UI 
                 */

                if (!string.IsNullOrWhiteSpace(e.Message.ToString()))
                    this.Send(sender, new ReceivedMessageEventArgs(new MessageBody("DF: " + e.Message)));
            }
        }
    }
}