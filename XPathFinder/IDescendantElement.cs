
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IDescendantElement : IBase
    {
        ILimitedWith With { get; }
        IContent Containing(string text);
    }
}
