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
    internal class HtmlElement : Base, IHtmlElement
    {
        private int tagIndex = 0;
        public static HtmlElement Create(string tag)
        {
            return new HtmlElement(tag);
        }

        public static HtmlElement Create(string tag, List<string> expressionParts)
        {
            return new HtmlElement(tag, expressionParts);
        }

        private HtmlElement(string tag)
        {
            this.ExpressionParts.Add("/" + tag);
            tagIndex = this.ExpressionParts.Count - 1;
        }

        private HtmlElement(string tag, List<string> expressionParts)
        {
            this.ExpressionParts = expressionParts;
            this.ExpressionParts.Insert(0, "/" + tag);
            tagIndex = 0;
        }

        public IQuery With
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
