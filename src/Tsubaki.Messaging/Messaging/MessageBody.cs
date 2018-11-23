// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging
{
    using System;

    public sealed class MessageBody
    {
        internal string Payload { get; }

        public MessageBody(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("message can't be null or empty", nameof(message));
            this.Payload = message;
        }

        public override string ToString() => this.Payload;
    }
}