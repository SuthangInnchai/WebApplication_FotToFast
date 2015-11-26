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
    public class Register
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
        public void TheRegisterTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Suthang");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("Innchai");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("suthangInn");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail1()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("Innchai");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("suthangInn");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail2()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Suthang");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("suthangInn");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail3()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Suthang");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("Innchai");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail4()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Suthang");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("Innchai");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("suthangInn");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail5()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Suthang");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("Innchai");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("suthangInn");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheRegisterTestFail6()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("");
            driver.FindElement(By.Id("LastNname")).Clear();
            driver.FindElement(By.Id("LastNname")).SendKeys("");
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("");
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
