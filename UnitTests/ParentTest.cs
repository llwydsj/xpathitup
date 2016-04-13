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
