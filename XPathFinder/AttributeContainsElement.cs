using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class AttributeContainsElement : Base, IAttributeContains
    {
        internal static IAttributeContains Create(List<string> expressionParts, string value, int currentAttributeIndex,bool appliesToParent)
        {
            return new AttributeContainsElement(expressionParts, value, currentAttributeIndex,appliesToParent);
        }

        private AttributeContainsElement(List<string> expressionParts, string value, int currentAttributeIndex,bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;
            this.attributeIndex = currentAttributeIndex;
            string attributeString = this.ExpressionParts[this.attributeIndex];
            this.ExpressionParts[this.attributeIndex] = string.Format(attributeString, "contains(", "'" + value + "')");
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
