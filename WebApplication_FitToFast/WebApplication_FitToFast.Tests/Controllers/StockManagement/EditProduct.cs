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
    public class EditProduct
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
        public void TheEditProductTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Products");
            driver.FindElement(By.XPath("(//a[contains(text(),'Edit')])[4]")).Click();
            driver.FindElement(By.Id("pName")).Clear();
            driver.FindElement(By.Id("pName")).SendKeys("Blue Shirt");
            driver.FindElement(By.Id("pDetail")).Clear();
            driver.FindElement(By.Id("pDetail")).SendKeys("the shirt is from cotton 100%");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheEditProductTestFail1()
        {
            driver.Navigate().GoToUrl(baseURL + "/Products");
            driver.FindElement(By.XPath("(//a[contains(text(),'Edit')])[4]")).Click();
            driver.FindElement(By.Id("pName")).Clear();
            driver.FindElement(By.Id("pName")).SendKeys("");
            driver.FindElement(By.Id("pDetail")).Clear();
            driver.FindElement(By.Id("pDetail")).SendKeys("the shirt is from cotton 100%");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheEditProductTestFail2()
        {
            driver.Navigate().GoToUrl(baseURL + "/Products");
            driver.FindElement(By.XPath("(//a[contains(text(),'Edit')])[4]")).Click();
            driver.FindElement(By.Id("pName")).Clear();
            driver.FindElement(By.Id("pName")).SendKeys("Blue Shirt");
            driver.FindElement(By.Id("pDetail")).Clear();
            driver.FindElement(By.Id("pDetail")).SendKeys("");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheEditProductTestFail3()
        {
            driver.Navigate().GoToUrl(baseURL + "/Products");
            driver.FindElement(By.XPath("(//a[contains(text(),'Edit')])[4]")).Click();
            driver.FindElement(By.Id("pName")).Clear();
            driver.FindElement(By.Id("pName")).SendKeys("");
            driver.FindElement(By.Id("pDetail")).Clear();
            driver.FindElement(By.Id("pDetail")).SendKeys("");
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
