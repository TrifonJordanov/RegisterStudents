using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentsRegistrySeleniumAndPOM.Pages;

namespace StudentsRegistrySeleniumAndPOM
{
    public class TestsForHomePage
    {
        protected IWebDriver driver = new ChromeDriver();
        private HomePage page;
        [SetUp]
        public void Setup()
        {
            var page = new HomePage(driver);
            page.Open();
        }

        [TearDown]
        public void ShutDownPage()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateHomePage_TitleContent()
        {
            var expected = page.GetPageTitle();
            Assert.AreEqual(expected, "MVC Example");
        }

        //[Test]
        //public void ValidateHomePage_
    }
}