using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    [TestFixture]
    public class chrome
    {
        //[Test]
        //public void should_open_chrome()
        //{
        //    //arrange
        //    var chrome = new ChromeDriver();
        //    //act
        //    chrome.Navigate().GoToUrl("http://google.com.ua");
        //    var wait = new WebDriverWait(chrome, new TimeSpan(0,0,10));
        //    wait.Until(x => x.FindElement(By.Id("lst-ib")).Displayed);

        //    var searchChild = chrome.FindElement(By.Id("lst-ib"));
        //    searchChild.SendKeys("WebDriver");
        //    searchChild.SendKeys(Keys.Enter);
        //    wait.Until(x => x.FindElement(By.LinkText("Selenium WebDriver")).Displayed);
        //    //assert
        //    //var element = chrome.FindElement(By.ClassName("")).Text;
        //    //Assert.IsFalse(element.
        //}

        [Test]
        public void should_send_message_through_gmail()
        {
            //arrange
            var chrome = new ChromeDriver();
            //act
            chrome.Navigate().GoToUrl("https://google.com.ua");
            var wait = new WebDriverWait(chrome, new TimeSpan(0, 0, 10));
            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"gbwa\"]/div[1]/a")).Displayed);

            var startButton = chrome.FindElement(By.XPath("//*[@id=\"gbwa\"]/div[1]/a"));
            startButton.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"gb23\"]/span[1]")).Displayed);

            var menu = chrome.FindElement(By.XPath("//*[@id=\"gb23\"]/span[1]"));
            menu.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"gmail-sign-in\"]")).Displayed);

            var signIn = chrome.FindElement(By.XPath("//*[@id=\"gmail-sign-in\"]"));
            signIn.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"Email\"]")).Displayed);

            var userNameField = chrome.FindElement(By.XPath("//*[@id=\"Email\"]"));
            userNameField.SendKeys("твій логін на gmail");

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"next\"]")).Displayed);

            var buttonNextToPassword = chrome.FindElement(By.XPath("//*[@id=\"next\"]"));
            buttonNextToPassword.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"Passwd\"]")).Displayed);

            var userPassword = chrome.FindElement(By.XPath("//*[@id=\"Passwd\"]"));
            userPassword.SendKeys("твій пароль на gmail");

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"signIn\"]")).Displayed);

            var btSignIn = chrome.FindElement(By.XPath("//*[@id=\"signIn\"]"));
            btSignIn.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\":ik\"]/div/div")).Displayed);

            var compose = chrome.FindElement(By.XPath("//*[@id=\":ik\"]/div/div"));
            compose.Click();

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\":nq\"]")).Displayed);

            var to = chrome.FindElement(By.XPath("//*[@id=\":nq\"]"));
            to.SendKeys("vadimvoyevoda@gmail.com");

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\":od\"]")).Displayed);

            var text = chrome.FindElement(By.XPath("//*[@id=\":od\"]"));
            text.SendKeys("Hello Vadim!!!");

            wait.Until(x => x.FindElement(By.XPath("//*[@id=\":n1\"]")).Displayed);

            var send = chrome.FindElement(By.XPath("//*[@id=\":n1\"]"));
            send.Click();
            
            //userNameField.SendKeys("admin");
            //userPasswordField.SendKeys("12345");

            //searchChild.SendKeys(Keys.Enter);
            //wait.Until(x => x.FindElement(By.LinkText("Selenium WebDriver")).Displayed);
            
        }
    }
}
