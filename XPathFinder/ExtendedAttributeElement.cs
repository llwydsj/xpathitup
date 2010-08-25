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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class ExtendedAttributeElement :Base, IExtendedAttribute
    {
        private ExtendedAttributeElement(List<string> expressionParts, string name, int currentAttributeIndex)
        {
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

        public static IExtendedAttribute Create(List<string> expressionParts, string name, int currentAttributeIndex)
        {
            return new ExtendedAttributeElement(expressionParts, name, currentAttributeIndex);
        }

        public IAttributeContains Containing(string value)
        {
            return AttributeContainsElement.Create(this.ExpressionParts, value,this.attributeIndex);
        }
   
    }
}
