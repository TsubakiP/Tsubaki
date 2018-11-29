// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Test.Console
{
    using System;
    using System.Text;
    using Tsubaki.Addons.Contracts;
    using Tsubaki.Addons.Hosting;
    using Tsubaki.Addons.Hosting.Extensions;
    using Tsubaki.Messaging;
    using Tsubaki.Messaging.RelayPoints;
    using Tsubaki.Test.MockAddon;
    using WebSocketSharp;
    using WebSocketSharp.Server;

    partial class Program
    {
        private static void main()
        {
            var uia = new WsLocalhost();
            var df = new Dialogflow();
            df.Register(uia);
            //uia.CreateDebugClient();
            //uia.CreateDebugClient();


            /*
            var ia = new InteractiveBag();
            if( Addons.Execute(new[] { "mock" }, new string[0], ia) == ExecutedResult.Success)
            {
            }*/

        }

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
    }
}