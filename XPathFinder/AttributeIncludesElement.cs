using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class AttributeIncludesElement: Base, IAttributeContains
    {
        internal static IAttributeContains Create(List<string> expressionParts, string value, int currentAttributeIndex,bool appliesToParent)
        {
            return new AttributeIncludesElement(expressionParts, value, currentAttributeIndex, appliesToParent);
        }

        private AttributeIncludesElement(List<string> expressionParts, string value, int currentAttributeIndex, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;
            this.attributeIndex = currentAttributeIndex;
            string attributeString = this.ExpressionParts[this.attributeIndex];
            this.ExpressionParts[this.attributeIndex] = string.Format(attributeString, "contains(concat(' ', normalize-space(", "), ' '), ' " + value + " ')");
        }

        public IAndElement And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex + 1,this.AppliesToParent);
            }
        }
    }
}
