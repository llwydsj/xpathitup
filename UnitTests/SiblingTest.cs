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
    public class SiblingTest
    {
        [Test]
        public void Will_Create_Xpath_Query_For_Parent_With_Sibling1()
        {
            string xpath =
                XPathFinder.Find.Tag("span").With.Attribute("class", "incomplete").And.FollowingSibling("span").With.Text("test").
                    And.Parent("div").With.FollowingSibling("div").With.Attribute("class", "checklistResponse").And.
                    Descendant("input").With.Attribute("value", "true").ToXPathExpression();

         
            Assert.AreEqual("//div/span[@class='incomplete']/following-sibling::span[text()='test']/ancestor::div[1]/following-sibling::div[@class='checklistResponse']//input[@value='true']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Parent_With_Sibling2()
        {
            string xpath = XPathFinder.Find.Tag("span").With.Text("Immediate Notifications").And.Parent("div").With.
                FollowingSibling("ul").With.Child("li").With.Descendant("span").With.Text("Applicant Signs Up").
                ToXPathExpression();

            Assert.AreEqual("//div/span[text()='Immediate Notifications']/ancestor::div[1]/following-sibling::ul/li//span[text()='Applicant Signs Up']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Parent_With_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("select").With.Parent("div").With.Parent("div").With.Parent("div").With.Parent
                        ("td").With.PrecedingSibling("td").With.Child("span").With.Attribute("class", "myClass").
                        ToXPathExpression();

            Assert.AreEqual("//td/div/div/div/select/ancestor::td[1]/preceding-sibling::td/span[@class='myClass']", xpath);

        }

        [Test]
        public void Will_Create_Xpath_Query_For_Series_Of_Parents_Where_One_Has_A_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("select").With.Parent("div").With.Parent("div").With.Parent("div").With.Parent
                        ("div").With.FollowingSibling("td").With.Child("span").With.Attribute("class", "myClass").
                        ToXPathExpression();

            Assert.AreEqual("//div/div/div/div/select/ancestor::div[4]/following-sibling::td/span[@class='myClass']", xpath);

        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Parent("tr1").With.FollowingSibling("tr2").ToXPathExpression();
            Assert.AreEqual("//tr1/td/ancestor::tr1[1]/following-sibling::tr2", xpath);
        }
    }
}
