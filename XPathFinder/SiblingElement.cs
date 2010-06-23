using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class SiblingElement:Base, ISibling
    {
        private int tagIndex = 0;
       
        public static SiblingElement Create(string tag, List<string> expressionParts, string siblingType)
        {
            return new SiblingElement(tag,expressionParts,siblingType);
        }

        private SiblingElement(string tag, List<string> expressionParts, string siblingType)
        {
            this.ExpressionParts = expressionParts;
            tagIndex++;
            this.ExpressionParts.Insert(tagIndex,string.Format("/{0}::{1}", siblingType, tag));
        }

        public new ILimitedQuery With
        {
            get { return WithExpression.Create(this.ExpressionParts, this.tagIndex); }
        }
    }
}
