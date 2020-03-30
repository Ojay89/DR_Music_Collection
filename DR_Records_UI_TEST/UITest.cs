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
            _driver.Navigate().GoToUrl("http://localhost:3000/");
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
            string title = _driver.Title;
            Assert.AreEqual("DR", title);

            //Chrome, OK FAST
            //Firefox, OK SLOW
        }

        [TestMethod]
        public void TestClickOnButtonAndGetData()
        {
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("MusicList")));
            //Assert.IsTrue(musicList.Text.Contains("1"));
            Assert.IsTrue(musicList.Text.Contains("Novembervej"));

            //Chrome OK FAST
            //Firefox, OK FAST
        }

        [TestMethod]
        public void TestSearchFunction()
        {
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement input = _driver.FindElement(By.Id("myInput"));
            input.Click();

            input.SendKeys("Lukas");
            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("MusicList")));
            Assert.IsTrue(musicList.Text.Contains("You're Not There"));

            //Chrome OK FAST
            //Firefox OK SLOW
        }

        [TestMethod]
        public void TestAddFunction()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement clickHereAddButton = _driver.FindElement(By.Id("clickHereAddButton"));
            clickHereAddButton.Click();

            IWebElement addId = _driver.FindElement(By.Id("addId"));
            addId.Click();
            addId.SendKeys("100");

            IWebElement addTitle = _driver.FindElement(By.Id("addTitle"));
            addTitle.Click();
            addTitle.SendKeys("UItest");

            IWebElement addArtist = _driver.FindElement(By.Id("addArtist"));
            addArtist.Click();
            addArtist.SendKeys("UItest");

            IWebElement addAlbum = _driver.FindElement(By.Id("addAlbum"));
            addAlbum.Click();
            addAlbum.SendKeys("UItest");

            IWebElement addRecordLabel = _driver.FindElement(By.Id("addRecordLabel"));
            addRecordLabel.Click();
            addRecordLabel.SendKeys("UItest");

            IWebElement addDurationInSeconds = _driver.FindElement(By.Id("addDurationInSeconds"));
            addDurationInSeconds.Click();
            addDurationInSeconds.SendKeys("500");

            IWebElement addYearOfPublication = _driver.FindElement(By.Id("addYearOfPublication"));
            addYearOfPublication.Click();
            addYearOfPublication.SendKeys("3000");

            IWebElement addRecordButton = _driver.FindElement(By.Id("addButton"));
            addRecordButton.Click(); //Tilføjer sang til listen

            addRecordButton.SendKeys("{F5}");

            //Bliver nødt til at refreshe siden og gå igennem de første steps igen
            WebDriverWait waitAgainAfterRefresh = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement musicListwait = wait.Until(d => d.FindElement(By.Id("MusicList")));



            IWebElement buttonElementAgain = _driver.FindElement(By.Id("getAllButton"));
            buttonElementAgain.Click();
            WebDriverWait waitAgain = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));


            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("MusicList")));
            Assert.IsTrue(musicList.Text.Contains("UItest"));

            //Chrome OK FAST
            //Firefox OK SLOW
        }

        [TestMethod]
        public void TestDeleteFunction()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement clickHereDeleteButton = _driver.FindElement(By.Id("clickHereDeleteButton"));
            clickHereDeleteButton.Click();

            IWebElement inputDelete = _driver.FindElement(By.Id("deleteInput"));
            inputDelete.Click();
            inputDelete.SendKeys("6"); //Sletter sang med id #6
            IWebElement inputDeleteButton = _driver.FindElement(By.Id("deleteButton"));
            inputDeleteButton.Click();

            //Bliver nødt til at refreshe side for at få listen frem igen uden errors
            inputDeleteButton.SendKeys("{F5}");

            //Kører liste igennem igen for at lede efter sang med id #6 - den skal være slettet
            IWebElement buttonElementAgain = _driver.FindElement(By.Id("getAllButton"));
            buttonElementAgain.Click();
            WebDriverWait waitAgain = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement musicList = wait.Until(d => d.FindElement(By.Id("MusicList")));
            Assert.IsFalse(musicList.Text.Contains("Dance Monkey"));

            //Chrome OK FAST
            //Firefox OK SLOW

        }
    }
}
