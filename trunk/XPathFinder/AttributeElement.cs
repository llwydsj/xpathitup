﻿/*
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
        public static IAttribute Create(List<string> expressionParts, string name, string value)
        {
            return new AttributeElement(expressionParts, name, value);
        }
        
        private AttributeElement(List<string> expressionParts, string name, string value)
        {
            this.ExpressionParts = expressionParts;
            if (this.ExpressionParts[this.ExpressionParts.Count - 1] != " and ")
            {
                this.ExpressionParts.Add(string.Format("[@{0}='{1}']", name, value));
            }
            else
            {
                this.ExpressionParts.Add(string.Format("@{0}='{1}']", name, value));
            }
        }

        public IAttributeAnd And
        {
            get
            {
                return AttributeAnd.Create(this.ExpressionParts);
            }
        }

    }
}
