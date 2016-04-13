
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IAndElement : ILimitedAnd
    {
        IAttribute Attribute(string name, string value);
        IExtendedAttribute Attribute(string name);
        ISibling PrecedingSibling(string tag);
        ISibling FollowingSibling(string tag);
        IPositionElement Position(int position);
    }

    public interface ILimitedAnd
    {
        IDescendantElement Descendant(string tag);
        ITagElement Child(string tag);
        ITagElement Parent(string tag);
    }
}
