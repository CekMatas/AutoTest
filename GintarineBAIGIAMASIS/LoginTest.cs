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
using SeleniumExtras.WaitHelpers;

namespace GintarineBAIGIAMASIS
{
    public class LoginTest
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
        public static void UnSuccessfulTestLogin()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);

            Thread.Sleep(2000);

            generalMethods.ClickElement("//header//div//nav/a[@class='user-controls__link user-controls__login']");

            Thread.Sleep(2000);

            generalMethods.EnterText("(//form//div//input[@id='Email'])[1]", "random@text02.com");

            generalMethods.EnterText("(//form//div//input[@id='Password'])[1]", "random@text02.com");

            generalMethods.ClickElement("//button[@class='account-controls__btn btn btn__primary btn--large account-controls__bottom-url-login']");

            Thread.Sleep(2000);

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
        public static void SuccessfulTestLogin()
        {
            GeneralMethods generalMethods = new GeneralMethods(driver);

            Thread.Sleep(2000);

            generalMethods.ClickElement("//header//div//nav/a[@class='user-controls__link user-controls__login']");

            Thread.Sleep(2000);

            generalMethods.EnterText("(//form//div//input[@id='Email'])[1]", "Autotestmatasc@gmail.com");

            generalMethods.EnterText("(//form//div//input[@id='Password'])[1]", "Matasc2023");

            generalMethods.ClickElement("//button[@class='account-controls__btn btn btn__primary btn--large account-controls__bottom-url-login']");

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
    }
}
