﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GintarineBAIGIAMASIS.POM
{
    internal class ProductCard
    {
        IWebDriver driver;
        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
        }
        // assertai man čia nelabai patinka
        // mano nuomone galėtų būti tiesiog visų šitų sąlygų suma
        // bet iš kitos pusės čia galima praplėsti kas negerai.
        // nežinau net kaip čia pasakyti
        // Man nelabai patinbka bet kaip ir gerai
        // ar reikia POM'o vien tik checkui?
        // Čia geresnis filosofinis klausimas
        public void ValidateMainInfo()
        {
            IWebElement productName = driver.FindElement(By.XPath("(//div/h1[@class='single-product__title'])[2]"));
            IWebElement productImage = driver.FindElement(By.XPath("//div/img[contains(@id,'main-product-img')]"));
            IWebElement productPrice = driver.FindElement(By.XPath("//form/div[contains(@class,'single-product__price')]"));
            IWebElement addToCartButton = driver.FindElement(By.XPath("//div/button[@id='addToCart']"));
            IWebElement productDescription = driver.FindElement(By.XPath("(//div[@class='single-product__details'])[1]"));

            Assert.IsTrue(productName.Displayed);
            Assert.IsTrue(productImage.Displayed);
            Assert.IsTrue(productPrice.Displayed);
            Assert.IsTrue(addToCartButton.Displayed);
            Assert.IsTrue(productDescription.Displayed);
        }
    }
}
