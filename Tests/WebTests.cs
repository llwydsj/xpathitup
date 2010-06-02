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
using Selenium;
using XPathItUp;

namespace Tests
{
    [Ignore]
    [TestClass]
    public class WebTests
    {
        private static ISelenium selenium;


        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            selenium = new DefaultSelenium("localhost", 4444, "*firefox", "http://localhost:4444");
            selenium.Start();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            selenium.Stop();
        }

        [TestMethod]
        public void WebTest_Will_Not_Find_Non_Exisitng_Link_On_Page()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("a").Containing("Link to Page 3")));
        }

        [TestMethod]
        public void WebTest_Will_Not_Find_Div_With_Non_Existing_Attribute()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("div").With.Attribute("class","NotValidClass")));
        }

        [TestMethod]
        public void WebTest_Will_Not_Find_Div_With_Undefined_Content()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("a").Containing("Written by Someone famous")));
        }

        [TestMethod]
        public void WebTest_Will_Do_Case_Sensitive_Content_Search()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            string xpath = XPathFinder.Find.HtmlTag("div").Containing("written by Torgeir Helgevold").ToXPathExpression();
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + xpath));
        }


        [TestMethod]
        public void WebTest_Will_Do_Case_Sensitive_Attribute_Value_Search()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("div").With.Attribute("class", "MenuItem menuItemSelected").ToXPathExpression()));
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("div").With.Attribute("class", "menuItem MenuItemSelected").ToXPathExpression()));
        }

        [TestMethod]
        public void WebTest_Will_Not_Do_Case_Sensitive_Attribute_Name_Search()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsTrue(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("div").With.Attribute("CLASS", "menuItem menuItemSelected").ToXPathExpression()));
        }

        [TestMethod]
        public void WebTest_Will_Find_Div_Based_On_Contained_Text_Tag()
        {
            selenium.Open("http://www.unit-testing.net/Articles");
            selenium.WaitForPageToLoad("30000");
            string xpath = XPathFinder.Find.HtmlTag("div").Containing("Written by Torgeir Helgevold").ToXPathExpression();
            Assert.IsTrue(selenium.IsElementPresent("xpath=" + xpath));
        }

        [TestMethod]
        public void WebTest_Will_Not_Find_Text_Inside_Span_Test()
        {
            selenium.Open("http://www.unit-testing.net/Articles");
            selenium.WaitForPageToLoad("30000");

            string xpath = XPathFinder.Find.HtmlTag("p").Containing("Written by Torgeir Helgevold").ToXPathExpression();
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + xpath));
        }

        [TestMethod]
        public void WebTest_Will_Find_Div_Based_On_Specified_Class_Attribute_Test()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            Assert.IsTrue(selenium.IsElementPresent("xpath=" + XPathFinder.Find.HtmlTag("div").With.Attribute("class", "menuItem menuItemSelected").ToXPathExpression()));
        }

        [TestMethod]
        public void WebTest_Will_Find_H2_With_Div_As_Parent_And_Div_As_Grand_Parent()
        {
            LoadPage("http://www.unit-testing.net/Articles");

            string xpath = XPathFinder.Find.HtmlTag("h2").With.Parent("div").Parent("div").ToXPathExpression();
            Assert.IsTrue(selenium.IsElementPresent("xpath=" + xpath));
        }

        private void LoadPage(string page)
        {
            selenium.Open(page);
            selenium.WaitForPageToLoad("30000");

        }

        [TestMethod]
        public void WebTest_Will_Find_Div_By_Attribute()
        {
            LoadPage("http://www.unit-testing.net/Articles");
            string xpath = XPathFinder.Find.HtmlTag("div").With.Attribute("class", "articleDetailsInner").ToXPathExpression();
            Assert.IsTrue(selenium.IsElementPresent("xpath=" + xpath));
        }

        

        [TestMethod]
        public void WebTest_Will_Not_Find_H2_With_Div_As_Parent_And_Span_As_Grand_Parent()
        {
            LoadPage("http://www.unit-testing.net/Articles");

            string xpath = XPathFinder.Find.HtmlTag("h2").With.Parent("div").Parent("span").ToXPathExpression();
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + xpath));
        }

        [TestMethod]
        public void WebTest_Will_Not_Find_Li()
        {
            LoadPage("http://www.unit-testing.net/Articles");

            string xpath = XPathFinder.Find.HtmlTag("li").ToXPathExpression();
            Assert.IsFalse(selenium.IsElementPresent("xpath=" + xpath));
        }

        
    }
}
