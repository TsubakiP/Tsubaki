using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tsubaki.Addons.Hosting;
using Tsubaki.Messaging;
using Tsubaki.Messaging.Endpoints;

namespace Tsubaki.ConsoleDebugger
{
    public partial class SampleForm : Form
    {
        private readonly List<IDisposable> disposables;



        public SampleForm()
        {
            this.disposables = new List<IDisposable>();

            InitializeComponent();


            var names = AddonProvider.Addons.GetAddonsNames();
            foreach (var name in names)
            {
                /*
                var str = $"{name} ({(AddonProvider.Addons[name].Metadata.Enabled ? "disable" : "enable")})";
                var btn = new ToolStripMenuItem(str);
                btn.Click += (s, _) =>
                {
                    var status = !AddonProvider.Addons[name].Metadata.Enabled;
                    btn.Text = $"{name} ({(status ? "disable" : "enable")})";
//                    AddonProvider.Addons[name].Metadata.Enabled = status;
                };
                this.addonsToolStripMenuItem.DropDownItems.Add(btn);
                */
            }


            var lighthouse = new Lighthouse(false);

            var mi = new MI(this.textBox1, this.richTextBox1);
            this.disposables.Add(lighthouse.Register(mi));
        }

        public class MI : MessengerBase
        {
            private readonly RichTextBox _receiver;
            private readonly TextBoxBase _textBox;

            public MI(TextBoxBase sender, RichTextBox receiver)
            {
                _textBox = sender ?? throw new ArgumentNullException(nameof(sender));
                _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));

                sender.KeyPress += (s, e) =>
                {                    
                    if (e.KeyChar == (char)13)
                    {
                        System.Diagnostics.Debug.WriteLine("clicked enter.");
                        this.Send(new MessageBody(this._textBox.Text));
                        this._textBox.Clear();
                    }
                };
            }

            protected override void OnReceived(object sender, ReceivedMessageEventArgs e)
            {
                this._receiver.AppendText(e.Message.ToString() + "\n");
            }
        }
    }
}
