
namespace Tsubaki.Dreamer.Messaging
{
    using System;

    public sealed class ReceivedMessageEventArgs : EventArgs
    {
        public ReceivedMessageEventArgs(MessageBody message)
        {
            this.Message = message;
        }

        public MessageBody Message { get; }
    }
}
