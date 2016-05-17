using System.Linq;

namespace XPathItUp
{
    internal abstract class LogicElementBase : Base, ILogicElement
    {
        public virtual IDescendantElement Descendant(string tag)
        {
            this.tagIndex = this.ExpressionParts.Count;

            if (this.AppliesToParent)
            {
                CloseAndTerm();
                this.tagIndex++;
            }
            else
            {
                this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
            }

            return DescendantElement.Create(this.ExpressionParts, tag);
        }

        public virtual ITagElement Child(string tag)
        {
            // replace " and " with closing bracket
            this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
            return TagElement.Create(tag, this.ExpressionParts, -1, false);
        }

        public virtual ITagElement Parent(string tag)
        {
            // replace " and " with closing bracket
            this.ExpressionParts[this.attributeIndex - 1] = "]";
            return TagElement.Create(tag, this.ExpressionParts, 0, true);
        }

        public virtual IAttribute Attribute(string name, string value)
        {
            return AttributeElement.Create(this.ExpressionParts, name, value, this.tagIndex, this.attributeIndex, this.AppliesToParent);
        }

        public virtual IExtendedAttribute Attribute(string name)
        {
            return ExtendedAttributeElement.Create(this.ExpressionParts, name, this.attributeIndex, this.AppliesToParent);
        }

        public virtual ISibling PrecedingSibling(string tag)
        {
            return CreateSibling(tag, "preceding-sibling");
        }

        public virtual ISibling FollowingSibling(string tag)
        {
            return CreateSibling(tag, "following-sibling");
        }

        public virtual IPositionElement Position(int position)
        {
            return PositionElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent, position);
        }

        protected virtual ISibling CreateSibling(string tag, string type)
        {
            this.tagIndex = this.ExpressionParts.Count;

            if (this.AppliesToParent)
            {
                string parent = this.ExpressionParts.Where(s => s[0] == '/').Reverse().Skip(1).First();
                this.ExpressionParts.Add(string.Format("/ancestor::{0}{1}", parent.TrimStart('/'), "[1]"));

                CloseAndTerm();

                this.tagIndex++;
            }
            else
            {
                this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
            }

            return SiblingElement.Create(tag, this.ExpressionParts, type, this.tagIndex);
        }

        protected virtual void CloseAndTerm()
        {
            for (int i = this.ExpressionParts.Count - 1; i > 0; i--)
            {
                if (this.ExpressionParts[i] == " and ")
                {
                    this.ExpressionParts[i] = "]";
                    break;
                }
            }
        }
    }
}