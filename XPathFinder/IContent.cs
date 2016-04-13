using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace XPathItUp
{
    public interface IContent : IBase
    {
        IAndElement And { get; }
    }
}
