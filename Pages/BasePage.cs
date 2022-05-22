using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public virtual string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement LinkHomePage =>
        driver.FindElement(By.XPath("/html/body/a[1]"));
        public IWebElement LinkStudentsPage =>
        driver.FindElement(By.XPath("/html/body/a[2]"));
        public IWebElement LinkAddStudentPage =>
        driver.FindElement(By.XPath("/html/body/a[3]"));

        public IWebElement ElementPageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
            => this.driver.Navigate().GoToUrl(this.PageUrl);


        public bool IsOpen() => driver.Url == this.PageUrl;

        public string GetPageTitle() => driver.Title;

        public string GetPageHeading() => ElementPageHeading.Text;

        public string[] GenerateStudentData()
        {
            Random rdm = new Random();
            var generatedData = new string[2];
            var studentName = "";
            var studentEmail = "";
            var generator = rdm.Next(int.MaxValue);
            studentName = $"Name{generator}";
            studentEmail = $"{studentName}@mail.ccc";
            generatedData[0] = studentName;
            generatedData[1] = studentEmail;
            return generatedData;
        }

        public void RegisterStudent(string nameToAdd, string emailToAdd)
        {
            var username = driver.FindElement(By.Id("name"));
            var email = driver.FindElement(By.Id("email"));
            var addBtn = driver.FindElement(By.CssSelector("body > form > button"));
            username.Click();
            username.SendKeys(nameToAdd);
            email.Click();
            email.SendKeys(emailToAdd);
            addBtn.Click();
        }
    }
}
