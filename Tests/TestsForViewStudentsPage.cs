using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentsRegistrySeleniumAndPOM.Pages;

namespace StudentsRegistrySeleniumAndPOM.Tests
{
    public class TestsForViewStudentsPage
    {
        private IWebDriver driver;
        private ViewStudentsPage page;
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.page = new ViewStudentsPage(driver);
            page.Open();
        }

        [TearDown]
        public void ShutDownPage()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateViewStudents_LinkWorkProperly()
        {
            page.LinkAddStudentPage.Click();
            page.LinkStudentsPage.Click();
            Assert.IsTrue(page.IsOpen());
        }

        [Test]
        public void ValidateViewStudents_TitleContent()
        {
            Assert.AreEqual("Students", page.GetPageTitle());
        }

        [Test]
        public void ValidateViewStudents_HeadingContent()
        {
            Assert.AreEqual("Registered Students", page.ElementPageHeading.Text);
        }

        [Test]
        public void ValidateViewStudentsPage_ContentRegisteredStudents()
        {
            var students = page.GetStudents();
            Assert.That(students.Count >= 0);
        }
    }
}
