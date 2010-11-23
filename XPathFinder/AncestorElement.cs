using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class AncestorElement : Base, IAncestorElement
    {
        public static AncestorElement Create(List<string> expressionParts,string tag)
        {
            return new AncestorElement(expressionParts,tag);
        }

        private AncestorElement(List<string> expressionParts, string tag)
        {
            this.ExpressionParts = expressionParts;
            this.ExpressionParts.Add(string.Format("/ancestor::{0}",tag));
            tagIndex = this.ExpressionParts.Count - 1;
        }

        public ILimitedWith With
        {
            get { return WithExpression.Create(this.ExpressionParts, this.tagIndex,false); }
        }

        public IContent Containing(string text)
        {
            return Content.Create(text, this.ExpressionParts, false);
        }
    }
}
