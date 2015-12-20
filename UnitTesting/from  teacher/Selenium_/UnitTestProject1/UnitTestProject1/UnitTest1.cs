using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Drawing.Imaging;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Configuration;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private VKAutorizeHelper _vkAutorizeHelper;

        [TestInitialize]
        public void OnTestInitialize()
        {
            
        }

        [TestCleanup]
        public void OnTestCleanup()
        {
            _driver = null;
        }

        [TestMethod]
        public void TestMethod1_Chrome()
        {
            _vkAutorizeHelper = new VKAutorizeHelper(_driver);
            _vkAutorizeHelper.RedirectToAutorizePage();
            _vkAutorizeHelper.Autorize("dddd@gmail.com", "pass1234813274");

            ConfigurationManager.AppSettings["email"].ToString();

            var chromeDriver = (ChromeDriver)_driver;

            var text = _vkAutorizeHelper.GetMsgTitle();


            chromeDriver.GetScreenshot().SaveAsFile("c:\\1.png", ImageFormat.Png);

            Assert.AreEqual("Unable to log in.1", text);
            Assert.AreEqual("Unable to log in.", text);            
        }

        [TestMethod]
        public void TestMethod2_Firefox()
        {
            _driver = new FirefoxDriver();
            _vkAutorizeHelper = new VKAutorizeHelper(_driver);
            _vkAutorizeHelper.RedirectToAutorizePage();

            var firefoxDriver = (FirefoxDriver)_driver;
            firefoxDriver.GetScreenshot().SaveAsFile("c:\\2.png", ImageFormat.Png);

            _vkAutorizeHelper.Autorize("dddd@gmail.com", "pass1234813274");

            

            
            var text = _vkAutorizeHelper.GetMsgTitle();
            

            Assert.AreEqual("Unable to log in.", text);
            Assert.Ver
        }
    }
}
