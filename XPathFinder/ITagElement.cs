using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface ITagElement : IBase
    {
        IWith With { get; }
        IContent Containing(string text);
        bool IsParent { get; set; }
    }
}
