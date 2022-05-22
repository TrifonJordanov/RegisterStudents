using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));
    }
}
