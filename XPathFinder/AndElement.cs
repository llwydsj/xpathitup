using System.Collections.Generic;

namespace XPathItUp
{
    internal class AndElement : LogicElementBase
    {
        internal static ILogicElement Create(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
        {
            return new AndElement(expressionParts, currentTagIndex, currentAttributeIndex, appliesToParent);
        }

        private AndElement(
            List<string> expressionParts,
            int currentTagIndex,
            int currentAttributeIndex,
            bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.tagIndex = currentTagIndex;
            this.attributeIndex = currentAttributeIndex;
            this.ExpressionParts = expressionParts;
            // remove closing ] bracket to allow for and
            this.ExpressionParts[this.attributeIndex - 1] = this.ExpressionParts[this.attributeIndex - 1].TrimEnd(']');

            this.ExpressionParts.Insert(this.attributeIndex, " and ");

            this.attributeIndex++;
        }
    }
}