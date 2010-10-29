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
    internal class PositionElement : Base, IPositionElement
    {
        public static IPositionElement Create(List<string> expressionParts, int currentTagIndex,int currentAttributeIndex,bool appliesToParent,int position)
        {
            return new PositionElement(expressionParts,currentTagIndex,currentAttributeIndex,appliesToParent,position);
        }

        private PositionElement(List<string> expressionParts, int currentTagIndex, int currentAttributeIndex, bool appliesToParent, int position)
        {
            this.AppliesToParent = appliesToParent;
            this.tagIndex = currentTagIndex;
            this.attributeIndex = currentAttributeIndex;
            this.ExpressionParts = expressionParts;

            string positionStr = string.Format("position()={0}",position);

            //Adding position element to an exisiting [
            if(this.ExpressionParts[this.attributeIndex - 1] == " and ")
            {
                this.ExpressionParts[this.ExpressionParts.Count - 1] += string.Format("{0}]", positionStr);
            }
            else
            {
                string exp = string.Format("[{0}]",positionStr);
                this.ExpressionParts.Insert(this.attributeIndex, exp);
                this.attributeIndex++;
            }
        }

        public ILimitedAnd And
        {
            get
            {
                return AndElement.Create(this.ExpressionParts, this.tagIndex, this.attributeIndex, this.AppliesToParent);
            }

        }
    }
}
