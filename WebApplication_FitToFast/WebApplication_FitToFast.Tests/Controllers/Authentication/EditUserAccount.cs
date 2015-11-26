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
    public class EditUserAccount
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
        public void TheEditUserAccountTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Usermanage");
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("User_UserName")).Clear();
            driver.FindElement(By.Id("User_UserName")).SendKeys("suthang");
            new SelectElement(driver.FindElement(By.Id("Roles_Name"))).SelectByText("Admin");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }
        [Test]
        public void TheEditUserAccountTestFail1()
        {
            driver.Navigate().GoToUrl(baseURL + "/Usermanage");
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("User_UserName")).Clear();
            driver.FindElement(By.Id("User_UserName")).SendKeys("");
            new SelectElement(driver.FindElement(By.Id("Roles_Name"))).SelectByText("Admin");
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
