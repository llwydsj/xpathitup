using System.Collections.Generic;

namespace XPathItUp
{
    internal class AttributeIncludesElement : Base, IAttributeContains
    {
        internal static IAttributeContains Create(List<string> expressionParts, string value, int currentAttributeIndex, bool appliesToParent)
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

        public ILogicElement And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex + 1, this.AppliesToParent);
            }
        }

        public ILogicElement Or
        {
            get
            {
                return OrElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex + 1, this.AppliesToParent);
            }
        }
    }
}