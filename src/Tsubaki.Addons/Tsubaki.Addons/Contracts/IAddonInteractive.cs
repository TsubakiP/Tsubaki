// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Addons.Contracts
{
    public interface IAddonInteractive
    {
        void WriteText(string message);
        bool IsFixed { get; }
    }

    public sealed class InteractiveBag : IAddonInteractive
    {
        private string _text = "";

        public void WriteText(string message)
        {
            if (this.IsFixed)
                return;

            this._text = message;
            this.IsFixed = true;
        }

        public override string ToString() => this._text;
        public bool IsFixed { get; private set; }
    }
}
