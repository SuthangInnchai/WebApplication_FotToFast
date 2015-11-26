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
    public class Xc
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
        public void TheXcTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Products/Create");
            driver.FindElement(By.Id("pName")).Clear();
            driver.FindElement(By.Id("pName")).SendKeys("Blue Shirt");
            driver.FindElement(By.Id("pDetail")).Clear();
            driver.FindElement(By.Id("pDetail")).SendKeys("the shirt is from cotton 100%");
            driver.FindElement(By.Id("pPrice")).Clear();
            driver.FindElement(By.Id("pPrice")).SendKeys("199");
            driver.FindElement(By.Name("productImg")).Clear();
            driver.FindElement(By.Name("productImg")).SendKeys("C:\\Users\\temp\\Desktop\\other\\poloLimited.jpg");
            driver.FindElement(By.Name("textureImg")).Clear();
            driver.FindElement(By.Name("textureImg")).SendKeys("C:\\Users\\temp\\Desktop\\other\\poloLimitedTexture.jpg");
            driver.FindElement(By.Id("XS")).Clear();
            driver.FindElement(By.Id("XS")).SendKeys("10");
            driver.FindElement(By.Id("S")).Clear();
            driver.FindElement(By.Id("S")).SendKeys("3");
            driver.FindElement(By.Id("M")).Clear();
            driver.FindElement(By.Id("M")).SendKeys("5");
            driver.FindElement(By.Id("L")).Clear();
            driver.FindElement(By.Id("L")).SendKeys("5");
            driver.FindElement(By.Id("XL")).Clear();
            driver.FindElement(By.Id("XL")).SendKeys("2");
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
