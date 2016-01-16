using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.VisualStudio;
using OpenQA.Selenium.Support.UI;


namespace CL_Test
{

  [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        private IWebElement element;
        
        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            element = null;
        }

        [Test]
        public void FindLogo()
        {          
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");
            try
            {
                element = driver.FindElement(By.XPath("//*[@id='header_logo']/a/img"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Test fails, element can't be found ");
            }
            Assert.IsNotNull(element, "Element is exist!!!");
        }

        [Test]
        public void CountOfProduct()
        {
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");
            int res = 0;
            try
            {
                res = driver.FindElements(By.XPath("//*[@id='homefeatured']/li")).Count;
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Test fails, element can't be found ");
            }
            Assert.AreEqual(8, res);
        }//CountOfProduct

        [Test]
        public void AddToCart()
        {
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/uk/");
            
            //open product page
            //IWebElement element = null;  
            try
            {
                element = driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]"));
            }
            catch (NoSuchElementException)
            {
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
                Assert.Fail("Test fails, element can't be found ");
            }
            StringAssert.Contains("13", element4.Text);


        }//AddToCart





        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
