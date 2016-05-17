namespace XPathItUp
{
    public interface ILimitedLogic
    {
        IDescendantElement Descendant(string tag);

        ITagElement Child(string tag);

        ITagElement Parent(string tag);
    }

    public interface ILogicElement : ILimitedLogic
    {
        IAttribute Attribute(string name, string value);

        IExtendedAttribute Attribute(string name);

        ISibling PrecedingSibling(string tag);

        ISibling FollowingSibling(string tag);

        IPositionElement Position(int position);
    }
}