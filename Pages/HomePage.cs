using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));
    }
}
