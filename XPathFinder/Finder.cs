using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public class Finder
    {
        public ITagElement Tag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException("tag");
            }

            return TagElement.Create(tag,false);
        }
    }
}
