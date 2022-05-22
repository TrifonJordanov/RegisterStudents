using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentsRegistrySeleniumAndPOM.Pages;

namespace StudentsRegistrySeleniumAndPOM
{
    public class TestsForHomePage
    {
        private IWebDriver driver;
        private HomePage page;
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.page = new HomePage(driver);
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
            Assert.AreEqual("MVC Example", page.GetPageTitle());
        }

        [Test]
        public void ValidateHomePage_HeadingContent()
        {
            var expectedHeading = page.GetPageHeading();
            Assert.AreEqual(expectedHeading, "Students Registry");
        }

        [Test]
        public void ValidateHomePage_LinkWorkProperly()
        {
            page.LinkStudentsPage.Click();
            Assert.That("Registered Students" == page.GetPageHeading());
            page.LinkHomePage.Click();
            Assert.IsTrue(page.IsOpen());
            Assert.AreEqual("Students Registry", page.GetPageHeading());
        }

        [Test]
        public void ValidateHomePage_StudentCountPresent()
        {
            var element = page.ElementStudentsCount.Displayed;
            Assert.IsTrue(element);
        }

        [Test]
        public void ValidateHomePage_StudentCountIsCorrect()
        {
            var driverViewStudent = new ChromeDriver();
            var studentPage = new ViewStudentsPage(driverViewStudent);
            studentPage.Open();
            Assert.IsTrue(studentPage.IsOpen());
            var listOfStudents = studentPage.GetStudents();
            driverViewStudent.Quit();
            var expected = int.Parse(page.ElementStudentsCount.Text);
            Assert.AreEqual(expected, listOfStudents.Count);
        }

    }
}