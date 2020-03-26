using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace DR_Records_UI_TEST
{
    [TestClass]
    public class UITest
    {
        private static readonly string DriverDirectory = "C:\\seleniumDrivers";
        private static IWebDriver _driver;

        // https://www.automatetheplanet.com/mstest-cheat-sheet/
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            // if your Chrome browser was updated, you must update the driver as well ...
            //    https://chromedriver.chromium.org/downloads
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestTitleOfPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("DR", title);
        }

        [TestMethod]
        public void TestClickOnButtonAndGetData()
        {
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); // decorator pattern?
            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("MusicList")));
            //Assert.IsTrue(musicList.Text.Contains("1"));
            Assert.IsTrue(musicList.Text.Contains("Novembervej"));
        }
    }
}
