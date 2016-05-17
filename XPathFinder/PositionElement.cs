using System.Collections.Generic;

namespace XPathItUp
{
    internal class PositionElement : Base, IPositionElement
    {
        public static IPositionElement Create(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent, int position)
        {
            return new PositionElement(expressionParts, currentTagIndex, currentAttributeIndex, appliesToParent, position);
        }

        private PositionElement(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent, int position)
        {
            this.AppliesToParent = appliesToParent;
            this.tagIndex = currentTagIndex;
            this.attributeIndex = currentAttributeIndex;
            this.ExpressionParts = expressionParts;

            string positionStr = string.Format("position()={0}", position);

            //Adding position element to an exisiting [
            if (this.ExpressionParts[this.attributeIndex - 1] == " and ")
            {
                this.ExpressionParts.Insert(this.attributeIndex, string.Format("{0}]", positionStr));
            }
            else
            {
                string exp = string.Format("[{0}]", positionStr);
                this.ExpressionParts.Insert(this.attributeIndex, exp);
            }

            this.attributeIndex++;
        }

        public ILimitedLogic And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent);
            }
        }

        public ILimitedLogic Or
        {
            get
            {
                return OrElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent);
            }
        }
    }
}