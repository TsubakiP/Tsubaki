﻿// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Messaging
{
    using System;

    public sealed class SentMessageEventArgs : EventArgs
    {
        public MessageBody Message { get; }

        public SentMessageEventArgs(MessageBody message)
        {
            this.Message = message;
        }
    }
}