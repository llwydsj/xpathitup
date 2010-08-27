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
    internal class Base : IBase
    {
        protected bool AppliesToParent
        {
            get;
            set;
        }

        protected int tagIndex = 0;
        protected int attributeIndex = 0;
        private List<string> expressionParts = new List<string>();

        public string ToXPathExpression()
        {
            string expr = string.Empty;
            foreach (string str in ExpressionParts)
            {
                expr += str;
            }

            return "/" + expr;
        }

        protected List<string> ExpressionParts
        {
            get
            {
                return expressionParts;
            }
            set
            {
                expressionParts = value;
            }
        }

    }
}
