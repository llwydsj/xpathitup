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
    public class DescendantTest
    {
        [Test]
        public void Will_Create_Xpath_Query_With_Descendant_Containing_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("span").Containing("subString").ToXPathExpression();
            Assert.AreEqual("//div//span[contains(.,'subString')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Descendant_Containing_Text_Anded_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("span").Containing("subString").And.Attribute("id","myId").ToXPathExpression();
            Assert.AreEqual("//div//span[contains(.,'subString') and @id='myId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Descendant()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("a").ToXPathExpression();
            Assert.AreEqual("//div//a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Text_And_Descendant()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("ttt").And.Descendant("a").ToXPathExpression();
            Assert.AreEqual("//div[text()='ttt']//a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Descendant_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("a").With.Text("ttt").ToXPathExpression();
            Assert.AreEqual("//div//a[text()='ttt']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Attribute_And_Descendant()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id", "myId").And.Descendant("span").ToXPathExpression();
            Assert.AreEqual("//div[@id='myId']//span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Descendant_With_Text_And_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("a").With.Text("ttt").And.Position(2).ToXPathExpression();
            Assert.AreEqual("//div//a[text()='ttt' and position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Descendant_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("a").With.Attribute("id","myId").ToXPathExpression();
            Assert.AreEqual("//div//a[@id='myId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Text_And_Position_And_Descendent()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("qwer").And.Attribute("id", "myId").And.Position(2).And.Descendant("a").ToXPathExpression();
            Assert.AreEqual("//div[text()='qwer' and @id='myId' and position()=2]//a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Sibling_With_Position_And_Attribute_And_Position()
        {
            string xpath = XPathFinder.Find.Tag("span").With.FollowingSibling("div").With.Attribute("id", "MyId").And.Position(1).And.Descendant("a").ToXPathExpression();
            Assert.AreEqual("//span/following-sibling::div[@id='MyId' and position()=1]//a",xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_Descendent_With_Position_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Descendant("a").With.Attribute("id", "myId").And.Position(1).ToXPathExpression();
            Assert.AreEqual("//div//a[@id='myId' and position()=1]", xpath);
        }
    }
}
