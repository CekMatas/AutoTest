using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintarineBAIGIAMASIS.POM
{
    internal class ProductList
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        By countInBasket = By.XPath("(//div/div[@class='cart-qty'])[2]");
        public ProductList(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void SelectProduct(int x)
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();",
            driver.FindElement(By.XPath("(//div/a[contains(@class,'product__img-url')])[" + x + "]")));
        }
        public int BasketCount()
        {
            string count = driver.FindElement(countInBasket).Text;
            return int.Parse(count);
        }
    }
}
