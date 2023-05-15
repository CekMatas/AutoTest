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
        // generalMethods kintamasis nepanaudotas gali buti ismestas
        GeneralMethods generalMethods;
        // Čia kaip ir minėjau reiktų gal vienodinti stilių
        // nes šitas XPath'as yra globaliai aprašytas
        // o paskui select product ne. Taip ten reikia įterpti skaičių
        // bet ten galima sužaisti su stringais:
        private string ProductPath = "(//div/a[contains(@class,'product__img-url')])[{0}]";
        // Tokiu atveju visi path'ai yra vienoje vietoje.
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
            //driver.FindElement(By.XPath("(//div/a[contains(@class,'product__img-url')])[" + x + "]")));
            driver.FindElement(By.XPath(string.Format(ProductPath, x))));
        }
        public int BasketCount()
        {
            string count = driver.FindElement(countInBasket).Text;
            return int.Parse(count);
        }
    }
}
