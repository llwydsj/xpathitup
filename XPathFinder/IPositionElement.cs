using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IPositionElement : IBase
    {
        ILimitedAnd And { get; }
    }
}
