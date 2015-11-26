using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class ChangePassword
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheChangePasswordTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin_shop");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.FindElement(By.LinkText("Hello Admin_Shop!")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            //--------------------------------------------------------------
            driver.FindElement(By.Id("OldPassword")).Clear();
            driver.FindElement(By.Id("OldPassword")).SendKeys("123456");
            driver.FindElement(By.Id("NewPassword")).Clear();
            driver.FindElement(By.Id("NewPassword")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheChangePasswordTestFail1()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin_shop");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.FindElement(By.LinkText("Hello Admin_Shop!")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            //--------------------------------------------------------------
            driver.FindElement(By.Id("OldPassword")).Clear();
            driver.FindElement(By.Id("OldPassword")).SendKeys("");
            driver.FindElement(By.Id("NewPassword")).Clear();
            driver.FindElement(By.Id("NewPassword")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheChangePasswordTestFail2()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin_shop");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.FindElement(By.LinkText("Hello Admin_Shop!")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            //--------------------------------------------------------------
            driver.FindElement(By.Id("OldPassword")).Clear();
            driver.FindElement(By.Id("OldPassword")).SendKeys("1234");
            driver.FindElement(By.Id("NewPassword")).Clear();
            driver.FindElement(By.Id("NewPassword")).SendKeys("");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheChangePasswordTestFail3()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin_shop");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.FindElement(By.LinkText("Hello Admin_Shop!")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            //--------------------------------------------------------------
            driver.FindElement(By.Id("OldPassword")).Clear();
            driver.FindElement(By.Id("OldPassword")).SendKeys("1234");
            driver.FindElement(By.Id("NewPassword")).Clear();
            driver.FindElement(By.Id("NewPassword")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheChangePasswordTestFail4()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("admin_shop");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            driver.FindElement(By.LinkText("Hello Admin_Shop!")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            //--------------------------------------------------------------
            driver.FindElement(By.Id("OldPassword")).Clear();
            driver.FindElement(By.Id("OldPassword")).SendKeys("");
            driver.FindElement(By.Id("NewPassword")).Clear();
            driver.FindElement(By.Id("NewPassword")).SendKeys("");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
