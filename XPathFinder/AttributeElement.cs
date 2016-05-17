using System.Collections.Generic;

namespace XPathItUp
{
    internal class AttributeElement : Base, IAttribute
    {
        public static IAttribute Create(List<string> expressionParts, string name, string value, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
        {
            return new AttributeElement(expressionParts, name, value, currentTagIndex, currentAttributeIndex, appliesToParent);
        }

        private AttributeElement(List<string> expressionParts, string name, string value, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.attributeIndex = currentAttributeIndex;
            this.tagIndex = currentTagIndex;
            this.ExpressionParts = expressionParts;

            if (this.ExpressionParts[this.attributeIndex - 1] == " and " || this.ExpressionParts[this.attributeIndex - 1] == " or ")
            {
                this.ExpressionParts.Insert(this.attributeIndex, string.Format("@{0}='{1}']", name, value));
            }
            else
            {
                this.ExpressionParts.Insert(this.attributeIndex, string.Format("[@{0}='{1}']", name, value));
            }

            this.attributeIndex++;
        }

        public ILogicElement And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent);
            }
        }

        public ILogicElement Or
        {
            get
            {
                return OrElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent);
            }
        }
    }
}