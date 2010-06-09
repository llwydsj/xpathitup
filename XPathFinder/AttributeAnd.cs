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
    internal class AttributeAnd : Base, IAttributeAnd
    {
        private int tagIndex = 0;
        private int attributeIndex = 0;

        internal static IAttributeAnd Create(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex)
        {
            return new AttributeAnd(expressionParts, currentTagIndex, currentAttributeIndex);
        }

        private AttributeAnd(List<string> expressionParts, int currentTagIndex,int currentAttributeIndex)
        {
            this.tagIndex = currentTagIndex;
            this.attributeIndex = currentAttributeIndex;
            this.ExpressionParts = expressionParts;
            // remove closing ] bracket to allow for and 
            this.ExpressionParts[this.attributeIndex - 1] = this.ExpressionParts[this.attributeIndex - 1].TrimEnd(']');
            
            this.ExpressionParts.Insert(this.attributeIndex, " and ");
            
            this.attributeIndex++;
        }

        public IAttribute Attribute(string name, string value)
        {
            return AttributeElement.Create(this.ExpressionParts, name, value,this.tagIndex,this.attributeIndex);
        }

        public IExtendedAttribute Attribute(string name)
        {
            return ExtendedAttributeElement.Create(this.ExpressionParts, name, this.attributeIndex);
        }

        //public IHtmlElement Parent(string tag)
        //{
        //    return HtmlElement.Create(tag, this.ExpressionParts);
        //}

    }
}
