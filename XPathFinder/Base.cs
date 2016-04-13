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
