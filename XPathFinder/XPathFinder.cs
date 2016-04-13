using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    public class XPathFinder
    {
        public static Finder Find
        {
            get
            {
                Finder finder = new Finder();
                return finder;
            }
        }
    }
}
