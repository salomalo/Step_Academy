using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
//using NUnit.Framework;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void FindLogo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");

            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath("//*[@id='header_logo']/a/img"));


                // driver.GetScreenshot().SaveAsFile("c:\\1.png", ImageFormat.Png);
                //element = driver.FindElement(By.Name("search_query"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }
            Assert.IsNotNull(element, "Element is exist!!!");
        }//FindLogo

        [TestMethod]
        public void CountOfProduct()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");

            int res = 0;

            try
            {
                res = driver.FindElements(By.XPath("//*[@id='homefeatured']/li")).Count;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }

            Assert.AreEqual(8, res);
        }//CountOfProduct

        [TestMethod]
        public void AddToCart()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");

            //open product page
            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]"));

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }
            element.Click();




            // add quentity
            IWebElement element2 = null;
            try
            {
                element2 = driver.FindElement(By.XPath("//*[@id='quantity_wanted']"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }
            element2.SendKeys("3");


            // click add to cart
            IWebElement element3 = null;
            try
            {
                element3 = driver.FindElement(By.XPath("//*[@id='add_to_cart']/button"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }
            element3.Click();


            //chack count

            IWebElement element4 = null;
            try
            {
                element4 = driver.FindElement(By.XPath("//*[@id='header']/div[3]/div/div/div[3]/div/a/span[5]"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found ");
                Assert.Fail("Test fails, element can't be found ");
            }
            StringAssert.Contains("13", element4.Text);


        }//AddToCart



    }
}
