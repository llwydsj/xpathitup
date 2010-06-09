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
    internal class AttributeElement : Base, IAttribute
    {
        private int tagIndex = 0;
        private int attributeIndex = 0;

        public static IAttribute Create(List<string> expressionParts, string name, string value, int currentTagIndex,int currentAttributeIndex)
        {
            return new AttributeElement(expressionParts, name, value, currentTagIndex,currentAttributeIndex);
        }

        private AttributeElement(List<string> expressionParts, string name, string value, int currentTagIndex, int currentAttributeIndex)
        {
            this.attributeIndex = currentAttributeIndex;
            this.tagIndex = currentTagIndex;
            this.ExpressionParts = expressionParts;
            
            if (this.ExpressionParts[this.attributeIndex - 1] == " and ")
            {
                this.ExpressionParts.Insert(this.attributeIndex, string.Format("@{0}='{1}']", name, value));
            }
            else
            {
                this.ExpressionParts.Insert(this.attributeIndex, string.Format("[@{0}='{1}']", name, value));
            }

            this.attributeIndex++;
        }

        public IAttributeAnd And
        {
            get
            {
                return AttributeAnd.Create(this.ExpressionParts,this.tagIndex,this.attributeIndex);
            }
        }

    }
}
