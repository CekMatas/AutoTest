using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
    }
}
