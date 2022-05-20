using System;
using OpenQA.Selenium;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
    }
}
