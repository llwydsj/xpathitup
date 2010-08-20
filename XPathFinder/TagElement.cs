using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text;

namespace XPathItUp
{
    internal class TagElement : Base, ITagElement
    {
        public static TagElement Create(string tag)
        {
            return new TagElement(tag);
        }

        public static TagElement Create(string tag, List<string> expressionParts,int tagIndex)
        {
            return new TagElement(tag, expressionParts,tagIndex);

        }

        private TagElement(string tag)
        {
            this.ExpressionParts.Add("/" + tag);
            tagIndex = this.ExpressionParts.Count - 1;
        }

        private TagElement(string tag, List<string> expressionParts,int tagIndex)
        {
            this.ExpressionParts = expressionParts;
            // parent
            if (tagIndex == 0)
            {
                this.ExpressionParts.Insert(tagIndex, "/" + tag);
                this.tagIndex = tagIndex;
            }
            // child
            else
            {
                this.ExpressionParts.Add("/" + tag);
                this.tagIndex = this.ExpressionParts.Count - 1;
            }
        }

        public IWith With
        {
            get
            {
                return WithExpression.Create(this.ExpressionParts,this.tagIndex);
            }
        }

        public IContent Containing(string text)
        {
            return Content.Create(text, this.ExpressionParts);
        }

    }
}
