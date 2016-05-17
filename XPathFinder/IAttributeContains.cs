using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IAttributeContains : IBase
    {
        ILogicElement And { get; }

        ILogicElement Or { get; }
    }
}
