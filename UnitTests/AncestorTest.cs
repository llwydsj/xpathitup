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
    public class AncestorTest
    {
        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Position()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Position(2).ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Position_Anded_With_Descendent()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Position(2).And.Descendant("span").With.Attribute("id","myId").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[position()=2]//span[@id='myId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Text_Anded_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Text("ttt").And.Attribute("id", "myID").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[text()='ttt' and @id='myID']", xpath);
        }


        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Attribute("id", "myId").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[@id='myId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Attribute("id").Containing("_myId").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[contains(@id,'_myId')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Text("myText").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[text()='myText']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_With_Child()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").With.Child("a").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Ancestor_Containing_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Ancestor("div").Containing("subString").ToXPathExpression();
            Assert.AreEqual("//a/ancestor::div[contains(.,'subString')]", xpath);
        }
    }
}
