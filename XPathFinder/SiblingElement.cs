using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class SiblingElement:Base, ISibling
    {
        public static SiblingElement Create(string tag, List<string> expressionParts, string siblingType,int tagIndex)
        {
            return new SiblingElement(tag,expressionParts,siblingType,tagIndex);
        }

        private SiblingElement(string tag, List<string> expressionParts, string siblingType, int tagIndex)
        {
            this.ExpressionParts = expressionParts;
            this.ExpressionParts.Insert(tagIndex,string.Format("/{0}::{1}", siblingType, tag));
            this.tagIndex = this.ExpressionParts.Count - 1;
        }

        public ILimitedWith With
        {
            get { return WithExpression.Create(this.ExpressionParts, this.tagIndex,false); }
        }
    }
}
