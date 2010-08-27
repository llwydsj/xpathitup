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
    internal class AttributeContainsElement : Base, IAttributeContains
    {
        internal static IAttributeContains Create(List<string> expressionParts, string value, int currentAttributeIndex,bool appliesToParent)
        {
            return new AttributeContainsElement(expressionParts, value, currentAttributeIndex,appliesToParent);
        }

        private AttributeContainsElement(List<string> expressionParts, string value, int currentAttributeIndex,bool appliesToParent)
        {
            this.AppliesToParent = appliesToParent;
            this.ExpressionParts = expressionParts;
            this.attributeIndex = currentAttributeIndex;
            string attributeString = this.ExpressionParts[this.attributeIndex];
            this.ExpressionParts[this.attributeIndex] = string.Format(attributeString, "contains(", "'" + value + "')");
        }

        public IAndElement And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex + 1,this.AppliesToParent);
            }
        }
    }
}
