using GintarineBAIGIAMASIS.POM;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace GintarineBAIGIAMASIS
{
    internal class AutoTest
    {
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.gintarine.lt/";
            By acceptCookies = By.XPath("//div//a[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']");
            driver.FindElement(acceptCookies).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [TearDown]
        public static void TearDown()
        {
            var countToLeave = 10;
            var faylai = Directory.GetFiles("Screenshots").ToList();
            faylai.Sort();

            if (faylai.Count > countToLeave)
            {
                for (int i = 0; i < faylai.Count - countToLeave; i++)
                {
                    File.Delete(faylai[i]);
                }

            }
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var name =
                    $"{TestContext.CurrentContext.Test.MethodName}" +
                    $" Error at " +
                    $"{DateTime.Now.ToString().Replace(":", "_")}";

                GeneralMethods.CaptureScrnsht(driver, name);

                File.WriteAllText
                    ($"Screenshots\\{name}.txt",
                    TestContext.CurrentContext.Result.Message);

            }
            driver.Close();
            driver.Quit();
        }

        [Test]
        public static void AscendingPriceSortingTest()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);

            generalMethods.TestSortingAsc("https://www.gintarine.lt/kosmetika-vaikams"); // Input wanted Gintarine.lt product category

        }
        [Test]
        public void CheckIfProductInfoIsDisplayed()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);
            TopMenu topMenu = new TopMenu(driver);
            ProductList productList = new ProductList(driver);
            ProductCard productCard = new ProductCard(driver);

            topMenu.SearchByText("žuvų taukai");                // Input wanted text for the item you are searching
            productList.SelectProduct(5);                       // Input wanted product from the list by selecting a number
            productCard.ValidateMainInfo();

        }
        [Test]
        public static void CheckIfMyProfileIsShown()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);
            LoginPage login = new LoginPage(driver);

            Thread.Sleep(2000);

            generalMethods.ClickElement("//header//div//nav/a[@class='user-controls__link user-controls__login']");

            login.EnterEmail("Autotestmatasc@gmail.com");
            login.EnterPassword("Matasc2023");
            login.ClickLoginButton();
            Thread.Sleep(2000);

            generalMethods.ClickElement("(//div//a[@href='/customer/info'])[2]");

            Thread.Sleep(2000);

            By errorMessage03 = By.XPath("//div/h1");

            string errorText03 = driver.FindElement(errorMessage03).Text;

            if (!errorText03.Contains("Mano paskyra"))
            {
                Assert.Fail("Wrong Text" + " " + "incorrect MyProfile text");
            }

        }
        [Test]
        public static void CheckWrongLoginAlertInfo()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);
            LoginPage login = new LoginPage(driver);

            Thread.Sleep(2000);

            generalMethods.ClickElement("//header//div//nav/a[@class='user-controls__link user-controls__login']");

            Thread.Sleep(2000);

            login.EnterEmail("wrongemailtest00000@gmail.com");
            login.EnterPassword("wrongpswrd00000");
            login.ClickLoginButton();
            Thread.Sleep(5000);

            By errorMessage01 = By.XPath("(//div/form/div[@class='message-error validation-summary-errors'])[1]");

            string errorText01 = driver.FindElement(errorMessage01).Text;

            if (!errorText01.Contains("Prisijungti nepavyko. Ištaisykite klaidas ir bandykite dar kartą."))
            {
                Assert.Fail("Wrong Text" + " " + "Error01 message was incorrect");
            }            

            Thread.Sleep(2000);

            By errorMessage02 = By.XPath("(//ul//li[text()='Pateikti prisijungimo duomenys neteisingi'])[1]");

            string errorText02 = driver.FindElement(errorMessage02).Text;

            if (!errorText02.Contains("Pateikti prisijungimo duomenys neteisingi"))
            {
                Assert.Fail("Wrong Text" + " " + "Error02 message was incorrect");
            }

        }
        [Test]
        public static void CheckIfProductOpens()
        {
            TopMenu topMenu = new TopMenu(driver);
            ProductList productList = new ProductList(driver);            
            ProductCard productCard = new ProductCard(driver);

            topMenu.SearchByText("akiu lasai");

            productList.SelectProduct(1);                  //Select which product from the shown products you want to select
            

        }
        [Test]
        public static void LoginTest()
        {
            LoginPage login = new LoginPage(driver);
            GeneralMethods generalMethods = new GeneralMethods(driver);

            Thread.Sleep(2000);

            generalMethods.ClickElement("//header//div//nav/a[@class='user-controls__link user-controls__login']");
            login.EnterEmail("Autotestmatasc@gmail.com");
            login.EnterPassword("Matasc2023");
            login.ClickLoginButton();
            Thread.Sleep(5000);


        }
        [Test]
        public static void CheckTitle()
        {
            CheckTitle checkTitle = new CheckTitle(driver);

            checkTitle.CheckTitl("Vaistai internete | Gintarinė vaistinė");  //Input wanted Title for checking if it's correct
        }
        [Test]
        public static void CheckIfSelectedItemsAreInYourCart()
        {
            TopMenu topMenu = new TopMenu(driver);
            ProductList productsList = new ProductList(driver);
            GeneralMethods generalMethods = new GeneralMethods(driver);

            topMenu.SearchByText("SPF");
            productsList.SelectProduct(10);
            Thread.Sleep(1500);
            generalMethods.AddToCart();
            driver.Navigate().Back();
            productsList.SelectProduct(5);
            Thread.Sleep(1500);
            generalMethods.AddToCart();
            driver.Navigate().Back();
            productsList.SelectProduct(1);
            Thread.Sleep(1500);
            generalMethods.AddToCart();
            driver.Navigate().Back();

            int itemsInCart = 3;                     // Skaičiu reiktų, norint pridėti daugiau prekių.
            int actualItemsInCart = productsList.BasketCount();

            Assert.AreEqual(itemsInCart, actualItemsInCart);

        }

    }
}
