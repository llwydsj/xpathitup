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

using XPathItUp;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class XPathFinderTest
    {
        
        [Test]
        public void Will_Create_Xpath_Query_Where_Both_Parent_And_Child_Has_Exact_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id", "divId").And.Child("span").With.Attribute("id", "spanId").ToXPathExpression();
            Assert.AreEqual("//div[@id='divId']/span[@id='spanId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_And_Child_With_Two_Exact_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id", "divId").And.Child("span").With.Attribute("id", "spanId").And.Attribute("class","myClass").ToXPathExpression();
            Assert.AreEqual("//div[@id='divId']/span[@id='spanId' and @class='myClass']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_And_Child_With_One_Exact_Attribute_And_One_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id", "divId").And.Child("span").With.Attribute("id", "spanId").And.Attribute("class").Containing("my").ToXPathExpression();
            Assert.AreEqual("//div[@id='divId']/span[@id='spanId' and contains(@class,'my')]", xpath);
        }


        [Test]
        public void Will_Create_Xpath_Query_Where_Partial_Attribute_Is_Anded_With_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class").Containing("my").And.Attribute("id", "myId").ToXPathExpression();
            Assert.AreEqual("//div[contains(@class,'my') and @id='myId']",xpath);
           
        }

        [Test]
        public void Will_Create_Xpath_Query_Where_Partial_Attributes_Are_Anded()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class").Containing("myClass").And.Attribute("id").Containing("_myID").ToXPathExpression();
            Assert.AreEqual("//div[contains(@class,'myClass') and contains(@id,'_myID')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Where_Parent_Has_Text_And_Child_Has_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("someText").And.Child("span").With.Attribute("id", "spanId").ToXPathExpression();
            Assert.AreEqual("//div[text()='someText']/span[@id='spanId']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Where_Parent_Has_Text_And_Child_Has_Exact_Attribute_And_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("someText").And.Child("span").With.Attribute("id", "spanId").And.Child("a").With.Attribute("href", "www.test.com").ToXPathExpression();
            Assert.AreEqual("//div[text()='someText']/span[@id='spanId']/a[@href='www.test.com']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("a").ToXPathExpression();
            Assert.AreEqual("//div/a",xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child_With_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.Child("a").ToXPathExpression();
            Assert.AreEqual("//div/span/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child_With_Contained_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("a").Containing("some text").ToXPathExpression();
            Assert.AreEqual("//div/a[contains(.,'some text')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child_With_Attribute_And_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("a").With.Text("Home").And.Attribute("id", "link").ToXPathExpression();
            Assert.AreEqual("//div/a[text()='Home' and @id='link']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("a").With.Attribute("id","link").ToXPathExpression();
            Assert.AreEqual("//div/a[@id='link']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Parent_And_Child_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("a").With.Text("Home").ToXPathExpression();
            Assert.AreEqual("//div/a[text()='Home']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Child_With_Contained_Text_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("tr").With.Child("td").Containing("test").And.Attribute("class", "tt").ToXPathExpression();
            Assert.AreEqual("//tr/td[contains(.,'test') and @class='tt']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Single_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Three_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").And.Attribute("class","myClass").And.Attribute("id","lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com' and @class='myClass' and @id='lnkHome']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Partial_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("id").Containing("_ctrlId").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and contains(@id,'_ctrlId')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Combination_Of_Text_And_Exact_Attribute_And_Partial_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Home Page").And.Attribute("href", "http://www.test.com").And.Attribute("id").Containing("_ctrlId").ToXPathExpression();
            Assert.AreEqual("//a[text()='Home Page' and @href='http://www.test.com' and contains(@id,'_ctrlId')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_And_One_Attribute_On_Parent()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class", "someClass").ToXPathExpression();
            Assert.AreEqual("//div[@class='someClass']/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_To_Search_For_Tag_With_Two_Attributes_And_Parent_With_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class", "someClass").And.Attribute("id", "someId").ToXPathExpression();
            Assert.AreEqual("//div[@class='someClass' and @id='someId']/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Attribute_Sub_String()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[contains(@id,'_txtUserName')]",xpath);
        }

        [Test]
        public void Will_Create_Xpath_To_Search_For_Tag_With_Parent_Containing_Attribute_Value()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[contains(@id,'_txtUserName')]/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_To_Search_For_Tag_With_Partial_Attribute_Anded_With_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id").Containing("_id").And.Attribute("class", "myClass").ToXPathExpression();
            Assert.AreEqual("//div[contains(@id,'_id') and @class='myClass']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.PrecedingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td/preceding-sibling::td",xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("td").With.FollowingSibling("td").With.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//td/following-sibling::td[@class='cell']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Text("Hello").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div[text()='Hello']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Child_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Child("a").With.Text("Hello").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div/a[text()='Hello']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Child_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Child("a").With.Attribute("href", "http://www.test.com").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div/a[@href='http://www.test.com']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("td").With.PrecedingSibling("td").With.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//td/preceding-sibling::td[@class='cell']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").And.Attribute("id","id1").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell' and @id='id1']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Preceding_Sibling_With_Text_And_One_Exact_Attribute_And_One_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.PrecedingSibling("div").With.Text("myText").And.Attribute("class", "cell").And.Attribute("id").Containing("_txtbox").ToXPathExpression();
            Assert.AreEqual("//div/preceding-sibling::div[text()='myText' and @class='cell' and contains(@id,'_txtbox')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Child_With_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.FollowingSibling("span").ToXPathExpression();
            Assert.AreEqual("//div/span/following-sibling::span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Contained_Text_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("tr").Containing("test").And.FollowingSibling("a").ToXPathExpression();
            Assert.AreEqual("//tr[contains(.,'test')]/following-sibling::a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Contained_Text_And_Preceding_Sibling_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("tr").Containing("test").And.PrecedingSibling("a").ToXPathExpression();
            Assert.AreEqual("//tr[contains(.,'test')]/preceding-sibling::a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Exact_Text_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Text("test").And.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td[text()='test']/following-sibling::td", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Attribute_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Attribute("class","myClass").And.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td[@class='myClass']/following-sibling::td", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Partial_Attribute_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Attribute("id").Containing("_txtBox").And.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td[contains(@id,'_txtBox')]/following-sibling::td", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Child_With_Partial_Attribute_And_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("tr").With.Child("td").With.Attribute("class").Containing("tdClass").And.PrecedingSibling("td").ToXPathExpression();
            Assert.AreEqual("//tr/td[contains(@class,'tdClass')]/preceding-sibling::td", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Child_And_Partial_Attribute_And_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("tr").With.Child("td").With.Attribute("class").Containing("tdClass").And.Attribute("id","_id").ToXPathExpression();
            Assert.AreEqual("//tr/td[contains(@class,'tdClass') and @id='_id']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Child_And_Exact_Attribute_And_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("tr").With.Child("td").With.Attribute("id", "_id").And.Attribute("class").Containing("tdClass").ToXPathExpression();
            Assert.AreEqual("//tr/td[@id='_id' and contains(@class,'tdClass')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Exact_Text_And_Following_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Text("test").And.FollowingSibling("td").With.Attribute("attr", "val").ToXPathExpression();
            Assert.AreEqual("//td[text()='test']/following-sibling::td[@attr='val']", xpath);
        }

        [Test]
        public void Will_Create_XPath_Query_With_Child_With_Contained_Text_And_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("tr").With.Child("td").Containing("test").And.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//tr/td[contains(.,'test')]/following-sibling::td", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Contained_Text_And_Preceding_Sibling_Sibling_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("tr").Containing("test").And.PrecedingSibling("a").With.Attribute("class","testClass").ToXPathExpression();
            Assert.AreEqual("//tr[contains(.,'test')]/preceding-sibling::a[@class='testClass']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Child_With_Sibling_With_Child_With_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.FollowingSibling("span").With.Child("p").With.Attribute("class","myPClass").ToXPathExpression();
            Assert.AreEqual("//div/span/following-sibling::span/p[@class='myPClass']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Parent_With_Exact_Attribute_And_Child_With_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("id", "divId").And.Child("span").With.FollowingSibling("span").ToXPathExpression();
            Assert.AreEqual("//div[@id='divId']/span/following-sibling::span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling_With_Text_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("div").With.Text("myText").And.Attribute("class", "cell").ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::div[text()='myText' and @class='cell']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("td").With.FollowingSibling("td").ToXPathExpression();
            Assert.AreEqual("//td/following-sibling::td", xpath);
        }

     

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Attribute_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").With.Attribute("name", "tigger").And.FollowingSibling("pet").ToXPathExpression();
            Assert.AreEqual("//pet[@name='tigger']/data/ancestor::pet[1]/following-sibling::pet", xpath);

            xpath = XPathFinder.Find.Tag("data").With.Parent("pet").With.Attribute("name", "tigger").And.FollowingSibling("pet").With.Attribute("t","val").ToXPathExpression();

            Assert.AreEqual("//pet[@name='tigger']/data/ancestor::pet[1]/following-sibling::pet[@t='val']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Exact_Text_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").With.Text("Some text").And.FollowingSibling("pet").ToXPathExpression();
            Assert.AreEqual("//pet[text()='Some text']/data/ancestor::pet[1]/following-sibling::pet", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Contained_Text_And_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").Containing("contained text").And.FollowingSibling("pet").ToXPathExpression();
            Assert.AreEqual("//pet[contains(.,'contained text')]/data/ancestor::pet[1]/following-sibling::pet", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Contained_Text()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").Containing("contained text").ToXPathExpression();
            Assert.AreEqual("//pet[contains(.,'contained text')]/data",xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Contained_Text_And_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").Containing("contained text").And.Attribute("attr","val").ToXPathExpression();
            Assert.AreEqual("//pet[contains(.,'contained text') and @attr='val']/data", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Contained_Text_And_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").Containing("contained text").And.Attribute("attr").Containing("_val").ToXPathExpression();
            Assert.AreEqual("//pet[contains(.,'contained text') and contains(@attr,'_val')]/data", xpath);
        }
        
        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Attribute_And_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").With.Attribute("name", "tigger").And.PrecedingSibling("pet").ToXPathExpression();
            Assert.AreEqual("//pet[@name='tigger']/data/ancestor::pet[1]/preceding-sibling::pet", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Partial_Attribute_And_Preceding_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("data").With.Parent("pet").With.Attribute("name").Containing("tigger").And.PrecedingSibling("pet").ToXPathExpression();
            Assert.AreEqual("//pet[contains(@name,'tigger')]/data/ancestor::pet[1]/preceding-sibling::pet", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_For_Tag_With_Parent_With_Exact_Match_On_Attribute_And_Contains_Search_On_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Attribute("class","myClass").And.Attribute("id").Containing("_txtUserName").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and contains(@id,'_txtUserName')]/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Both_Exact_Attribute_Match_And_Attribute_Sub_String_Match()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://www.test.com").And.Attribute("id").Containing("_lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://www.test.com' and contains(@id,'_lnkHome')]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Exact_Match_On_Two_Attributes_And_Attribute_Sub_String_Match_On_One_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://www.test.com").And.Attribute("attr1","val1").And.Attribute("id").Containing("_lnkHome").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://www.test.com' and @attr1='val1' and contains(@id,'_lnkHome')]", xpath);
        }

        [Test]
        public void Will_Find_Anchor_Tag_With_Href_Equal_To_Specified_Url()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://test.test.com").ToXPathExpression();
            Assert.AreEqual("//a[@href='http://test.test.com']", xpath);
        }

        [Test]
        public void Will_Find_XPath_Query_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Text("Test").ToXPathExpression();
            Assert.AreEqual("//a[text()='Test']", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_Based_On_Tag_With_Parent_With_Text()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Text("Hello").ToXPathExpression();

            Assert.AreEqual("//div[text()='Hello']/a",xpath);
        }

        [Test]
        public void Will_Create_XPath_Query_On_Three_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2","test2").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2']", xpath);
        }

        [Test]
        public void Will_Create_XPath_Query_On_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("attr1", "test1").And.Attribute("attr2", "test2").ToXPathExpression();
            Assert.AreEqual("//div[@attr1='test1' and @attr2='test2']", xpath);
        }

        [Test]
        public void Will_Create_XPath_Query_On_Four_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2", "test2").And.Attribute("attr3", "test3").ToXPathExpression();
            Assert.AreEqual("//div[@class='myClass' and @attr1='test1' and @attr2='test2' and @attr3='test3']", xpath);
        }

        [Test]
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

        [Test]
        public void Will_Create_XPath_With_Text_Contains_Anded_With_Exact_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").Containing("Home Page").And.Attribute("id", "myId").ToXPathExpression();
            Assert.AreEqual("//a[contains(.,'Home Page') and @id='myId']", xpath);
        }

        [Test]
        public void Will_Create_XPath_With_Text_Contains_Anded_With_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("a").Containing("Home Page").And.Attribute("id").Containing("_somId").ToXPathExpression();
            Assert.AreEqual("//a[contains(.,'Home Page') and contains(@id,'_somId')]", xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Containing_The_Text_Home_Page()
        {
            string xpath = XPathFinder.Find.Tag("a").Containing("Home Page").ToXPathExpression();
            Assert.AreEqual("//a[contains(.,'Home Page')]",xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Finding_Standalone_Anchor_Tag()
        {
            string xpath = XPathFinder.Find.Tag("a").ToXPathExpression();
            Assert.AreEqual("//a", xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/a", xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Div_Inside_Antoher_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("div").With.Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/div/a", xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Finding_Anchor_Tag_Inside_Span_Inside_Div_Inside_Another_Div()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("span").With.Parent("div").With.Parent("div").ToXPathExpression();
            Assert.AreEqual("//div/div/span/a", xpath);
        }

        [Test]
        public void Will_Create_XPath_For_Div_With_Specified_Class()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Attribute("class", "someclass").ToXPathExpression();
            Assert.AreEqual("//div[@class='someclass']", xpath);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void Find_Will_Throw_ArgumentNullException_If_Tag_Is_Null_Test()
        {
            XPathFinder.Find.Tag(null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void Find_Will_Throw_ArgumentNullException_If_Tag_Is_String_Empty_Test()
        {
            XPathFinder.Find.Tag(string.Empty);
        }
    }
}
