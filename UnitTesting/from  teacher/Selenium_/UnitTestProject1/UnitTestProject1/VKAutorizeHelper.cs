using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    public class VKAutorizeHelper
    {
        private const string LOGIN_URL = "http://vk.com/";

        private const string EMAIL_FIELD_ID = "quick_email";
        private const string PASS_FIELD_ID = "quick_pass";
        private const string LOGIN_BTN_ID = "quick_login_button";

        private IWebDriver _webDriver;

        private IWebElement EMAIL_FIELD
        {
            get { return _webDriver.FindElement(By.Id(EMAIL_FIELD_ID)); }
        }

        public VKAutorizeHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void RedirectToAutorizePage()
        {
            _webDriver.Navigate().GoToUrl(LOGIN_URL);
        }

        public void Autorize(string login, string pass)
        {
            EMAIL_FIELD.SendKeys(login);
            _webDriver.FindElement(By.Id(PASS_FIELD_ID)).SendKeys(pass);
            _webDriver.FindElement(By.Id(LOGIN_BTN_ID)).Click();
        }

        public void ClearData(string login, string pass)
        {
            EMAIL_FIELD.Clear();
        }

        public string GetMsgTitle()
        {
            return _webDriver.FindElement(By.XPath("//*[@id=\"message\"]/b[1]")).Text;
        }
    }
}
