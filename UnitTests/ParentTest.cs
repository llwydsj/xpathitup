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
using NUnit.Framework;
using XPathItUp;

namespace UnitTests
{
    [TestFixture]
    public class ParentTest
    {
        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Anded_To_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("key", "val").And.Parent("span").ToXPathExpression();
            Assert.AreEqual("//span/div[@key='val']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Anded_To_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("key").Containing("val").And.Parent("span").ToXPathExpression();
            Assert.AreEqual("//span/div[contains(@key,'val')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Anded_To_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("someText").And.Parent("span").ToXPathExpression();
            Assert.AreEqual("//span/div[text()='someText']", xpath);

        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Anded_To_Contained_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").Containing("someText").And.Parent("span").ToXPathExpression();
            Assert.AreEqual("//span/div[contains(.,'someText')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Anded_To_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Position(1).And.Parent("span").ToXPathExpression();
            Assert.AreEqual("//span/div[position()=1]", xpath);
        }

        
    }
}
