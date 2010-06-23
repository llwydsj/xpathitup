using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface ILimitedQuery : IBase
    {
        IAttribute Attribute(string name, string value);
        IExtendedAttribute Attribute(string name);
        ITextElement Text(string text);
    }
}
