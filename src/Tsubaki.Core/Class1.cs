
namespace Tsubaki.Core
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Tsubaki.Messaging;
    using Tsubaki.Messaging.EndPoints;
    using Tsubaki.Messaging.RelayPoints;
    using WebSocketSharp;
    using WebSocketSharp.Server;

    public sealed class Dialogflow : Lighthouse
    {
        public Dialogflow()
        {

        }

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


    public sealed class WsLocalhost : MessengerBase
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
        public WsLocalhost(ushort userInterfacePort = 8888)
        {
            this._wss = new WebSocketServer(userInterfacePort);
            this._wss.AddWebSocketService<Broadcast>("/");
            this._wss.Start();

        }

        protected override void OnReceived(object sender, ReceivedMessageEventArgs e)
        {
            var msg = e.Message.ToString();
            this._wss.WebSocketServices.Broadcast(msg);
        }

        private sealed class Broadcast : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine(e.Data);
                this.Send(e.Data);
            }
        }
    }
}
