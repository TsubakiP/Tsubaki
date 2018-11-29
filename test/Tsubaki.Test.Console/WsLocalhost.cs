// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.Console
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Tsubaki.Messaging;
    using Tsubaki.Messaging.EndPoints;
    using WebSocketSharp;
    using WebSocketSharp.Server;

    partial class Program
    {
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
}