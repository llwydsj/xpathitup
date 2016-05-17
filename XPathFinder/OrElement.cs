using System.Collections.Generic;

namespace XPathItUp
{
    internal class OrElement : LogicElementBase
    {
        internal static ILogicElement Create(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
        {
            return new OrElement(expressionParts, currentTagIndex, currentAttributeIndex, appliesToParent);
        }

        private OrElement(
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

            this.ExpressionParts.Insert(this.attributeIndex, " or ");

            this.attributeIndex++;
        }
    }
}