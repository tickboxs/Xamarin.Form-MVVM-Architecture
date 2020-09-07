using System;
using System.Linq;

namespace nibble.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RouterAttribute: Attribute
    {
        public string Path { set; get; }
    }
}

