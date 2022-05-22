using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement ErrorMsg =>
            driver.FindElement(By.XPath("/html/body/div"));
    }
}
