
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class ExtendedAttributeElement :Base, IExtendedAttribute
    {
        private ExtendedAttributeElement(List<string> expressionParts, string name, int currentAttributeIndex,bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;

            this.attributeIndex = currentAttributeIndex;

            if (this.ExpressionParts[this.attributeIndex - 1] == " and ")
            {
                this.ExpressionParts.Insert(this.attributeIndex,"{0}@" + name + ",{1}]");
            }
            else
            {
                this.ExpressionParts.Insert(this.attributeIndex,"[{0}@" + name + ",{1}]");
            }

        }

        public static IExtendedAttribute Create(List<string> expressionParts, string name, int currentAttributeIndex, bool appliesToParent)
        {
            return new ExtendedAttributeElement(expressionParts, name, currentAttributeIndex,appliesToParent);
        }

        public IAttributeContains Containing(string value)
        {
            return AttributeContainsElement.Create(this.ExpressionParts, value,this.attributeIndex,this.AppliesToParent);
        }
   
    }
}
