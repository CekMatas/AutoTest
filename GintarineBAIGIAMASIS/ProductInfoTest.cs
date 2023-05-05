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
    internal class ProductInfoTest
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
        public void GetProductInfo()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);
            TopMenu topMenu = new TopMenu(driver);
            ProductList productList = new ProductList(driver);
            ProductCard productCard = new ProductCard(driver);

            topMenu.SearchByText("žuvų taukai");
            productList.SelectProduct(5);
            productCard.ValidateMainInfo();
        }
    }
}
