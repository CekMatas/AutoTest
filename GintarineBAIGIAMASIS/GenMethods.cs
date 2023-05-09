using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintarineBAIGIAMASIS
{

    internal class GeneralMethods
    {

        IWebDriver driver;
        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickElement(string xpath)
        {
            IWebElement el = driver.FindElement(By.XPath(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
        public void EnterTextAndPressENTER(string xpath, string text)
        {
            By searchField = By.XPath(xpath);
            driver.FindElement(searchField).SendKeys(text);
            driver.FindElement(searchField).SendKeys(Keys.Enter);

        }
        public void EnterText(string xpath, string text)
        {
            By searchField = By.XPath(xpath);
            driver.FindElement(searchField).SendKeys(text);
        }
        public void TestSortingAsc(string categoryURL)
        {

            driver.Url = categoryURL + "?orderby=10";
            By pricesBy = By.XPath("//span[@class='product_price-regular']");
            List<double> prices = new List<double>();
            foreach (IWebElement el in driver.FindElements(pricesBy))
            {
                string onePrice = el.Text.Substring(0, el.Text.Length - 2);
                double onePriceDouble = double.Parse(onePrice);
                prices.Add(onePriceDouble);
            }
            for (int i = 0; i < prices.Count - 1; i++)
            {
                Console.WriteLine(prices[i]);
                if (prices[i] > prices[i + 1])
                {
                    Assert.Fail("Failed in " + categoryURL + " " + prices[i] + " " + prices[i + 1]);
                }
     
            }   
        }
        public IWebElement WaitElement(string xpath, IWebDriver driver) 
        {
            return WaitElement(By.XPath(xpath), driver);
        }
        public IWebElement WaitElement(By by, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromSeconds(0.5);
            return wait.Until(d => d.FindElement(by));
        }
        public static void CaptureScrnsht(IWebDriver driver, string fileName)
        {
            var screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            if (!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }

            screenshot.SaveAsFile($"Screenshots\\{fileName}.png",
                ScreenshotImageFormat.Png);
        }

    }
}
