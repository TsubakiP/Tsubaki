
namespace Tsubaki.Messaging
{
    using System;

    public readonly struct MessageBody
    {
        public MessageBody(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("message can't be null or empty", nameof(message));
            this.Payload = message;
        }

        internal string Payload { get; } 
    }
}
