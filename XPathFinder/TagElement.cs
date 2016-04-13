using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class TagElement : Base, ITagElement
    {
        public bool IsParent
        {
            get;
            set;
        }

        public static TagElement Create(string tag,bool isParent)
        {
            return new TagElement(tag,isParent);
        }

        public static TagElement Create(string tag, List<string> expressionParts,int tagIndex,bool isParent)
        {
            return new TagElement(tag, expressionParts,tagIndex,isParent);

        }

        private TagElement(string tag,bool isParent)
        {
            IsParent = isParent;
            this.ExpressionParts.Add("/" + tag);
            tagIndex = this.ExpressionParts.Count - 1;
        }

        private TagElement(string tag, List<string> expressionParts, int tagIndex, bool isParent)
        {
            IsParent = isParent;
            this.ExpressionParts = expressionParts;
            // parent
            if (tagIndex == 0)
            {
                this.ExpressionParts.Insert(tagIndex, "/" + tag);
                this.tagIndex = tagIndex;
            }
            // child
            else
            {
                this.ExpressionParts.Add("/" + tag);
                this.tagIndex = this.ExpressionParts.Count - 1;
            }
        }

        public IWith With
        {
            get
            {
                return WithExpression.Create(this.ExpressionParts,this.tagIndex,this.IsParent);
            }
        }

        public IContent Containing(string text)
        {
            return Content.Create(text, this.ExpressionParts,this.IsParent);
        }

    }
}
