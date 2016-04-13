using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class DescendantElement : Base, IDescendantElement
    {
        public static IDescendantElement Create(List<string> expressionParts,string tag)
        {
            return new DescendantElement(expressionParts,tag);
        }

        private DescendantElement(List<string> expressionParts, string tag)
        {
            this.ExpressionParts = expressionParts;
            this.ExpressionParts.Add("//" + tag);
            tagIndex = this.ExpressionParts.Count - 1;
        }

        public ILimitedWith With
        {
            get { return WithExpression.Create(this.ExpressionParts, this.tagIndex, false); }
        }

        public IContent Containing(string text)
        {
            return Content.Create(text, this.ExpressionParts, false);
        }
    }
}
