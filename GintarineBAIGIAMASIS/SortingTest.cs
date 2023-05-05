using GintarineBAIGIAMASIS.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GintarineBAIGIAMASIS
{
    internal class SortingTest
    {
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.gintarine.lt/";
            By acceptCookies = By.XPath("//div//a[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(acceptCookies).Click();
        }
        [TearDown]
        public static void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void AscendingPriceSortingTest()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);

            generalMethods.TestSortingAsc("https://www.gintarine.lt/kontaktiniu-lesiu-skysciai"); // Input wanted Gintarine.lt product Category

            

        }
    }
}
