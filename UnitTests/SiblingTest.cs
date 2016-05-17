using NUnit.Framework;
using XPathItUp;

namespace UnitTests
{
    [TestFixture]
    public class SiblingTest
    {
        [Test]
        public void Will_Create_Xpath_Query_For_Parent_With_Sibling3()
        {
            string xpath = XPathFinder.Find.Tag("span").With.FollowingSibling("div").With.Text("tt").And.Parent("div").With.Parent("div").With.FollowingSibling("span").ToXPathExpression();

            Assert.AreEqual("//div/div/span/following-sibling::div[text()='tt']/ancestor::div[2]/following-sibling::span",xpath);
        }

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
