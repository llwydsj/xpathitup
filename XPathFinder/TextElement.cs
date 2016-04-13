using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class TextElement: Base, ITextElement
    {
        internal static ITextElement Create(string text, List<string> expressionParts, int currentTagIndex,bool appliesToParent)
        {
            return new TextElement(text, expressionParts,currentTagIndex,appliesToParent);
        }

        private TextElement(string text, List<string> expressionParts, int currentTagIndex, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.tagIndex = currentTagIndex;
            string exp = string.Format("[text()='{0}']", text);
            this.ExpressionParts = expressionParts;
            
            this.ExpressionParts.Insert(this.tagIndex + 1,exp);
        }

        public IAndElement And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.tagIndex + 2,this.AppliesToParent);
            }
        }
    }
}
