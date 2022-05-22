using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace StudentsRegistrySeleniumAndPOM.Pages
{
    public class ViewStudentsPage : BasePage
    {

        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> Students =>
            driver.FindElements(By.CssSelector("body > ul > li"));
        public List<string> GetStudents()
        {
            var students = Students.Select(x => x.Text).ToList();
            return students;
        }
    }
}
