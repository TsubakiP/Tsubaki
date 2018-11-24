// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.Console
{
    using System;

    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Hosting.Extensions;
    using Tsubaki.Test.MockAddon;
    using WebSocketSharp;
    using WebSocketSharp.Server;

    partial class Program
    {
        public class Interactive : IAddonInteractive
        {
            public void Text(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class Wss
        {
            private class Callback : WebSocketBehavior
            {
                protected override void OnMessage(MessageEventArgs e)
                {
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


        private static void main()
        {





            var wss = new Wss(8888);

            // try {
            var ia = new Wsc(8888);

            var addon = Addons.Get(Mock.MOCK_ADDON);
            var dec = addon.Control();
            
            if (dec.IsEnabled)
            {
                Console.WriteLine("Enable");
                addon.Execute(new string[0], ia);
                dec.Disable();
            }
            else
            {
                Console.WriteLine("Disable");
                dec.Enable();
            }

            /*
            Console.WriteLine("---");
            foreach (var item in Addons.Names)
            {
                Console.WriteLine(item);
            }
            */

            /*
        }
        catch (TypeInitializationException e) when (e.InnerException is ReflectionTypeLoadException te)
        {
            var le = te.LoaderExceptions[0];
            Console.WriteLine(le.Message);
        }*/
        }
    }
}