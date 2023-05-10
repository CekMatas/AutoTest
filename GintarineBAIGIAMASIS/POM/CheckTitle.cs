using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintarineBAIGIAMASIS.POM
{
    internal class CheckTitle
    {
        IWebDriver driver;
        public CheckTitle(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void CheckTitl(string ExpectedTitle)
        {
            string ActualTitle = driver.Title;

            if (!ActualTitle.Contains(ExpectedTitle))
            {
                Assert.Fail("-Wrong Title");
            }
            else
                Console.WriteLine(ActualTitle + "-Title is Correct");

        }

    }
}
