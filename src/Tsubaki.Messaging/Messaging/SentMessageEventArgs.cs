
namespace Tsubaki.Messaging
{
    using System;

    public sealed class SentMessageEventArgs : EventArgs
    {
        public SentMessageEventArgs(MessageBody message)
        {
            this.Message = message;
        }

        public MessageBody Message { get; }
    }
}
