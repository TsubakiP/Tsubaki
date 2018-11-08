// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RouteAttribute : Attribute
    {
        internal string File { get; }

        public RouteAttribute(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                file = null;

            this.File = file;
        }
    }
}