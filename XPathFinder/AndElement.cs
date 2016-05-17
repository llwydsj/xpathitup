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

    //internal class AndElement : Base, IAndElement
    //{
    //    internal static IAndElement Create(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
    //    {
    //        return new AndElement(expressionParts, currentTagIndex, currentAttributeIndex, appliesToParent);
    //    }

    //    private AndElement(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent)
    //    {
    //        this.AppliesToParent = appliesToParent;
    //        this.tagIndex = currentTagIndex;
    //        this.attributeIndex = currentAttributeIndex;
    //        this.ExpressionParts = expressionParts;
    //        // remove closing ] bracket to allow for and
    //        this.ExpressionParts[this.attributeIndex - 1] = this.ExpressionParts[this.attributeIndex - 1].TrimEnd(']');

    //        this.ExpressionParts.Insert(this.attributeIndex, " and ");

    //        this.attributeIndex++;
    //    }

    //    public IAttribute Attribute(string name, string value)
    //    {
    //        return AttributeElement.Create(this.ExpressionParts, name, value, this.tagIndex, this.attributeIndex, this.AppliesToParent);
    //    }

    //    public IExtendedAttribute Attribute(string name)
    //    {
    //        return ExtendedAttributeElement.Create(this.ExpressionParts, name, this.attributeIndex, this.AppliesToParent);
    //    }

    //    public IDescendantElement Descendant(string tag)
    //    {
    //        this.tagIndex = this.ExpressionParts.Count;

    //        if (this.AppliesToParent)
    //        {
    //            CloseAndTerm();

    //            this.tagIndex++;
    //        }
    //        else
    //        {
    //            this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
    //        }

    //        return DescendantElement.Create(this.ExpressionParts, tag);
    //    }

    //    public IPositionElement Position(int position)
    //    {
    //        return PositionElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent, position);
    //    }

    //    public ITagElement Child(string tag)
    //    {
    //        // replace " and " with closing bracket
    //        this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
    //        return TagElement.Create(tag, this.ExpressionParts, -1, false);
    //    }

    //    public ITagElement Parent(string tag)
    //    {
    //        this.ExpressionParts[this.attributeIndex - 1] = "]";
    //        return TagElement.Create(tag, this.ExpressionParts, 0, true);
    //    }

    //    public ISibling PrecedingSibling(string tag)
    //    {
    //        return CreateSibling(tag, "preceding-sibling");
    //    }

    //    public ISibling FollowingSibling(string tag)
    //    {
    //        return CreateSibling(tag, "following-sibling");
    //    }

    //    private ISibling CreateSibling(string tag, string type)
    //    {
    //        this.tagIndex = this.ExpressionParts.Count;

    //        if (this.AppliesToParent)
    //        {
    //            string parent = this.ExpressionParts.Where(s => s[0] == '/').Reverse().Skip(1).First();
    //            this.ExpressionParts.Add(string.Format("/ancestor::{0}{1}", parent.TrimStart('/'), "[1]"));

    //            CloseAndTerm();

    //            this.tagIndex++;
    //        }
    //        else
    //        {
    //            this.ExpressionParts[this.ExpressionParts.Count - 1] = "]";
    //        }

    //        return SiblingElement.Create(tag, this.ExpressionParts, type, this.tagIndex);
    //    }

    //    private void CloseAndTerm()
    //    {
    //        for (int i = this.ExpressionParts.Count - 1; i > 0; i--)
    //        {
    //            if (this.ExpressionParts[i] == " and ")
    //            {
    //                this.ExpressionParts[i] = "]";
    //                break;
    //            }
    //        }
    //    }
    //}
}