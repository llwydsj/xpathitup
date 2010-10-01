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
    public class PositionTest
    {
        [Test]
        public void Will_Create_Xpath_Query_With_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Attribute("class").Containing("myClass").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and contains(@class,'myClass') and position()=3]", xpath);

            xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Attribute("class", "myClass").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and @class='myClass' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id").Containing("_id").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and contains(@id,'_id') and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("span").With.Position(3).ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::span[position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_And_Text_On_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("span").With.Text("myText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::span[text()='myText' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.Position(2).ToXPathExpression();
            Assert.AreEqual("//div/span[position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Parent()
        {
            string xpath = XPathFinder.Find.Tag("span").With.Parent("div").With.Position(2).ToXPathExpression();
            Assert.AreEqual("//div[position()=2]/span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Tag_With_Partial_Text()
        {
            string xpath = XPathFinder.Find.Tag("span").Containing("myText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//span[contains(.,'myText') and position()=3]", xpath);

            xpath = XPathFinder.Find.Tag("span").Containing("myText").And.Attribute("class","test").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//span[contains(.,'myText') and @class='test' and position()=3]", xpath);
        }

    }
}
