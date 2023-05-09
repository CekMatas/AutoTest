using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintarineBAIGIAMASIS.POM
{
    internal class LoginPage
    {
        IWebDriver driver;

        By useremail = By.XPath("(//form//div//input[@id='Email'])[1]");
        By userpassword = By.XPath("(//form//div//input[@id='Password'])[1]");
        By signInButton = By.XPath("//button[@class='account-controls__btn btn btn__primary btn--large account-controls__bottom-url-login']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterEmail(string email)
        {
            driver.FindElement(useremail).SendKeys(email);

        }
        public void EnterPassword(string password) 
        {
            driver.FindElement(userpassword).SendKeys(password);
        }
        public void ClickLoginButton()
        {
            driver.FindElement(signInButton).Click();
        }
    }
}
