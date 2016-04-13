using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public interface IWith : ILimitedWith
    {
        ITagElement Parent(string tag);

        ISibling PrecedingSibling(string tag);
        ISibling FollowingSibling(string tag);

        IDescendantElement Descendant(string tag);

        IAncestorElement Ancestor(string tag);
    }
}
