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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPathItUp;

namespace Tests
{
    [TestClass]
    public class XPathFinderTest
    {
        [TestMethod]
        public void Will_Find_Anchor_Tag_With_Href_Equal_To_Specified_Url()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://test.test.com").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://test.test.com']", xpath);
        }

        [TestMethod]
        public void Will_Find_XPath_Query_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Test").ToXPathExpression();
            Assert.AreEqual("//a[text()='Test']", xpath);

        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_Three_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2","test2").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2']", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_Four_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2", "test2").And.Attribute("attr3", "test3").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2' and @attr3='test3']", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Containing_The_Text_Home_Page()
        {
            string xpath = XPathFinder.Find.Tag("a").Containing("Home Page").ToXPathExpression();
            Assert.AreEqual("//a[contains(.,'Home Page')]",xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Standalone_Anchor_Tag()
        {
            string xpath = XPathFinder.Find.Tag("a").ToXPathExpression();
            Assert.AreEqual("//a", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/a", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Div_Inside_Antoher_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/div/a", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Span_Inside_Div_Inside_Another_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("span").Parent("div").Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/div/span/a", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Div_With_Specified_Class()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "someclass").ToXPathExpression();
            Assert.AreEqual("//div[@class='someclass']", xpath);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Find_Will_Throw_ArgumentNullException_If_Tag_Is_Null_Test()
        {
            XPathFinder.Find.Tag(null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Find_Will_Throw_ArgumentNullException_If_Tag_Is_String_Empty_Test()
        {
            XPathFinder.Find.Tag(string.Empty);
        }
    }
}
