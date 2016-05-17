using System.Collections.Generic;

namespace XPathItUp
{
    internal class AttributeContainsElement : Base, IAttributeContains
    {
        internal static IAttributeContains Create(List<string> expressionParts, string value, int currentAttributeIndex, bool appliesToParent)
        {
            return new AttributeContainsElement(expressionParts, value, currentAttributeIndex, appliesToParent);
        }

        private AttributeContainsElement(List<string> expressionParts, string value, int currentAttributeIndex, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;
            this.attributeIndex = currentAttributeIndex;
            string attributeString = this.ExpressionParts[this.attributeIndex];
            this.ExpressionParts[this.attributeIndex] = string.Format(attributeString, "contains(", ",'" + value + "')");
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