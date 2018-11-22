
namespace Tsubaki.Messaging
{
    using System;

    public sealed class MessageBody
    {
        public MessageBody(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("message can't be null or empty", nameof(message));
            this.Payload = message; 
        }

        internal string Payload { get; }
        public override string ToString() => this.Payload;
    }
}
