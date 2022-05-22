using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentsRegistrySeleniumAndPOM.Pages;

namespace StudentsRegistrySeleniumAndPOM.Tests
{
    public class TestsForAddStudent
    {
        private IWebDriver driver;
        private AddStudentPage page;
        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.page = new AddStudentPage(driver);
            page.Open();
        }

        [TearDown]
        public void ShutDownPage()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateAddStudentPage_TitleContent()
        {
            Assert.AreEqual("Add Student", page.GetPageTitle());
        }

        [Test]
        public void ValidateAddStudentPage_HeadingContent()
        {
            Assert.AreEqual("Register New Student", page.GetPageHeading());
        }

        [Test]
        public void ValidateAddStudentPage_LinkRedirectWorkProperly()
        {
            page.LinkHomePage.Click();
            Assert.That("Students Registry" == page.GetPageHeading());
            page.LinkAddStudentPage.Click();
            Assert.IsTrue(page.IsOpen());
            Assert.That("Register New Student" == page.GetPageHeading());
        }

        [Test]
        public void ValidateAddStudentPage_AddingProperlyStudent()
        {
            var data = page.GenerateStudentData();
            page.RegisterStudent(data[0], data[1]);
            var driverToViewStudents = new ChromeDriver();
            var pageToGetStudents = new ViewStudentsPage(driverToViewStudents);
            pageToGetStudents.Open();
            Assert.IsTrue(pageToGetStudents.IsOpen());
            var listOfStudents = pageToGetStudents.GetStudents();
            driverToViewStudents.Quit();
            var expectedName = data[0];
            var expectedEmail = $"({data[1]})";
            var lastStudent = listOfStudents[^1].Split();
            Assert.AreEqual(expectedName, lastStudent[0]);
            Assert.AreEqual(expectedEmail, lastStudent[1]);
        }

        [Test]
        public void ValidateAddStudentPage_ThrowExceptionWithEmptyFields()
        {

            page.RegisterStudent("", "");
            Assert.IsTrue(page.ErrorMsg.Displayed);
        }

        [Test]
        public void ValidateAddStudentPage_ThrowExceptionWithEmptyUserName()
        {

            page.RegisterStudent("", "asd@asd.dsa");
            Assert.IsTrue(page.ErrorMsg.Displayed);
        }

        [Test]
        public void ValidateAddStudentPage_ThrowExceptionWithEmptyEmail()
        {

            page.RegisterStudent("Testera", "");
            Assert.IsTrue(page.ErrorMsg.Displayed);
        }
    }
}
