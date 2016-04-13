using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class WithExpression : Base, IWith
    {
        private WithExpression(List<string> expressionParts, int currentTagIndex, bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;
            this.tagIndex = currentTagIndex;
        }

        internal static IWith Create(List<string> expressionParts, int currentTagIndex,bool appliesToParent)
        {
            return new WithExpression(expressionParts,currentTagIndex,appliesToParent);
        }

        public ITagElement Parent(string tag)
        {
            return TagElement.Create(tag, this.ExpressionParts,0,true);
        }

        public ITagElement Child(string tag)
        {
            return TagElement.Create(tag, this.ExpressionParts, this.tagIndex + 1,false);
        }

        public IAttribute Attribute(string name, string value)
        {
            return AttributeElement.Create(this.ExpressionParts, name, value,this.tagIndex, this.tagIndex + 1,this.AppliesToParent);
        }

        public IExtendedAttribute Attribute(string name)
        {
            return ExtendedAttributeElement.Create(this.ExpressionParts, name, this.tagIndex + 1,this.AppliesToParent);
        }

        public ITextElement Text(string text)
        {
            return TextElement.Create(text, this.ExpressionParts, this.tagIndex,this.AppliesToParent);
        }

        public IDescendantElement Descendant(string tag)
        {
            return XPathItUp.DescendantElement.Create(this.ExpressionParts, tag);
        }

        public IAncestorElement Ancestor(string tag)
        {
            return XPathItUp.AncestorElement.Create(this.ExpressionParts, tag);
        }

        public IPositionElement Position(int position)
        {
            return PositionElement.Create(this.ExpressionParts, this.tagIndex,this.tagIndex + 1, this.AppliesToParent, position);
        }

        public ISibling PrecedingSibling(string tag)
        {
            return CreateSibling(tag, "preceding-sibling");
        }

        public ISibling FollowingSibling(string tag)
        {
            return CreateSibling(tag, "following-sibling");
        }

        private ISibling CreateSibling(string tag, string siblingType)
        {
            this.tagIndex = this.ExpressionParts.Count;

            if (this.AppliesToParent)
            {
                string parent = this.ExpressionParts[0];
                
                //find correct parent if there is more than one ancestor of same type
                int ancestorIndex = 1;
                for (int i = this.tagIndex-1; i > 0; i--)
                {
                    if (this.ExpressionParts[i] == parent)
                    {
                        //must increment to point to the next parent 
                        ancestorIndex++;
                    }
                }

                this.ExpressionParts.Add(string.Format("/ancestor::{0}[{1}]", parent.TrimStart('/'), ancestorIndex));
                this.tagIndex++;
            }

            return SiblingElement.Create(tag, this.ExpressionParts, siblingType, this.tagIndex);
        }
    }
}
