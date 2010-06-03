/*
Copyright (C) 2010  Torgeir Helgevold

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class WithExpression : Base, IQuery
    {
        private WithExpression(List<string> expressionParts)
        {
            this.ExpressionParts = expressionParts;
        }

        internal static IQuery Create(List<string> expressionParts)
        {
            return new WithExpression(expressionParts);
        }

        public IHtmlParent Parent(string tag)
        {
            return HtmlParentElement.Create(tag, this.ExpressionParts);
        }

        public IAttribute Attribute(string name, string value)
        {
            return AttributeElement.Create(this.ExpressionParts, name, value);
        }

        public IExtendedAttribute Attribute(string name)
        {
            return ExtendedAttributeElement.Create(this.ExpressionParts, name);
        }

        public ITextElement Text(string text)
        {
            return TextElement.Create(text, this.ExpressionParts);
        }

    }
}
