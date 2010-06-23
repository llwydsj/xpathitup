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
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Single_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Three_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").And.Attribute("class","myClass").And.Attribute("id","lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com' and @class='myClass' and @id='lnkHome']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Partial_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("id").Containing("_ctrlId").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and contains(@id,'_ctrlId')]", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Exact_Attribute_And_Partial_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").And.Attribute("id").Containing("_ctrlId").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com' and contains(@id,'_ctrlId')]", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_With_Parent_And_One_Attribute_On_Parent()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class", "someClass").ToXPathExpression();
            Assert.AreEqual("//div[@class='someClass']/a", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_To_Search_For_Tag_With_Two_Attributes_And_Parent_With_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class", "someClass").And.Attribute("id", "someId").ToXPathExpression();
            Assert.AreEqual("//div[@class='someClass' and @id='someId']/a", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Attribute_Sub_String()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[contains(@id,'_txtUserName')]",xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_To_Search_For_Tag_With_Parent_Containing_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[contains(@id,'_txtUserName')]/a", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.PrecedingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td/preceding-sibling::td",xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("td").With.FollowingSibling("td").With.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//td/following-sibling::td[@class='cell']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Text("Hello").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div[text()='Hello']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("td").With.PrecedingSibling("td").With.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//td/preceding-sibling::td[@class='cell']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").And.Attribute("id","id1").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell' and @id='id1']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_One_Exact_Attribute_And_One_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").And.Attribute("id").Containing("_txtbox").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell' and contains(@id,'_txtbox')]", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Text_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Text("myText").And.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div[text()='myText' and @class='cell']", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td/following-sibling::td", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Parent("tr1").With.FollowingSibling("tr2").ToXPathExpression();
            Assert.AreEqual("//tr1/following-sibling::tr2/td", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Exact_Match_On_Attribute_And_Contains_Search_On_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class","myClass").And.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and contains(@id,'_txtUserName')]/a", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Both_Exact_Attribute_Match_And_Attribute_Sub_String_Match()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://www.test.com").And.Attribute("id").Containing("_lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://www.test.com' and contains(@id,'_lnkHome')]", xpath);
        }

        [TestMethod]
        public void Will_Create_Xpath_Query_Based_On_Exact_Match_On_Two_Attributes_And_Attribute_Sub_String_Match_On_One_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://www.test.com").And.Attribute("attr1","val1").And.Attribute("id").Containing("_lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://www.test.com' and @attr1='val1' and contains(@id,'_lnkHome')]", xpath);
        }

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
        public void Will_Create_Xpath_Query_Based_On_Tag_With_Parent_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Text("Hello").ToXPathExpression();

            Assert.AreEqual("//div[text()='Hello']/a",xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_Three_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2","test2").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2']", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("attr1", "test1").And.Attribute("attr2", "test2").ToXPathExpression();
            Assert.AreEqual("//div[@attr1='test1' and @attr2='test2']", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_Four_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2", "test2").And.Attribute("attr3", "test3").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2' and @attr3='test3']", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_Query_On_12_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.
                                                            Attribute("attr0", "test0").And.
                                                            Attribute("attr1", "test1").And.
                                                            Attribute("attr2", "test2").And.
                                                            Attribute("attr3", "test3").And.
                                                            Attribute("attr4", "test4").And.
                                                            Attribute("attr5", "test5").And.
                                                            Attribute("attr6", "test6").And.
                                                            Attribute("attr7", "test7").And.
                                                            Attribute("attr8", "test8").And.
                                                            Attribute("attr9", "test9").And.
                                                            Attribute("attr10", "test10").And.
                                                            Attribute("attr11", "test11").ToXPathExpression();

            Assert.AreEqual("//div[@attr0='test0' and @attr1='test1' and @attr2='test2' and @attr3='test3' and @attr4='test4' and @attr5='test5' and @attr6='test6' and @attr7='test7' and @attr8='test8' and @attr9='test9' and @attr10='test10' and @attr11='test11']", xpath);
          
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
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/div/a", xpath);
        }

        [TestMethod]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Span_Inside_Div_Inside_Another_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("span").With.Parent("div").With.Parent("div").ToXPathExpression();
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
