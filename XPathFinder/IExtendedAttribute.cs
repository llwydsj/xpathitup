
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IExtendedAttribute 
    {
        IAttributeContains Containing(string value);

        IAttributeContains Including(string value);
    }
}
