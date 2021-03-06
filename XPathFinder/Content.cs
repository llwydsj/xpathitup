﻿using System.Collections.Generic;

namespace XPathItUp
{
    internal class Content : Base, IContent
    {
        internal static IContent Create(string text, List<string> expressionParts, bool appliesToParent)
        {
            return new Content(text, expressionParts, appliesToParent);
        }

        private Content(string text, List<string> expressionParts, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            string exp = string.Format("[contains(.,'{0}')]", text);
            this.ExpressionParts = expressionParts;
            this.tagIndex = this.ExpressionParts.Count - 1;
            this.attributeIndex = this.tagIndex;

            if (this.AppliesToParent == false)
            {
                this.ExpressionParts.Add(exp);
                this.attributeIndex++;
            }
            else
            {
                this.ExpressionParts.Insert(this.tagIndex, exp);
            }
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