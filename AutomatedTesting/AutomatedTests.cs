using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Allure.Commons;
using AutomatedTesting.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomatedTesting
{
    [AllureNUnit]
    [AllureSuite("Olx Tests")]
    public class Tests
    {
        private HomePage _homePage;
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver(@"/Users/misha/Projects/AutomatedTesting/AutomatedTesting/WebDrivers");
    
           
        }


        [Test(Description = "Test website logo to have correct title.")]
        [AllureTag("UI")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Logo")]
        public void TestLogoTitle()
        {
            _homePage = new HomePage(_driver);
            const string expectedTitle = "На головну OLX - безкоштовні оголошення/На главную OLX - бесплатные объявления";
            var actualTitle = _homePage.Logo.GetAttribute("title");
            
            Assert.IsTrue(expectedTitle.Contains(actualTitle));
        }

        [Test(Description = "Test search to return results that include text searched.")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSubSuite("Search")]
        public void TestSearch()
        {
            const string searchTitle = "Дюна";
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _homePage = new HomePage(_driver);
            
            _homePage.SearchInput.SendKeys(searchTitle);
            _homePage.SearchInput.SendKeys(Keys.Enter);

            var searchResult = new SearchResultPage(wait);

            var resultTitle = searchResult.FirstSearchResult.FindElement(By.TagName("strong")).Text;
            
            Assert.IsTrue(resultTitle.Contains(searchTitle));
        }

        [Test(Description = "Test that UI icons change name after language on site changes.")]
        [AllureTag("UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSubSuite("UI")]
        public void TestChangeLanguage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _homePage = new HomePage(_driver);
            
            _homePage.ChangeLanguage.Click();

            var messageIconText = _homePage.Messages.FindElement(By.TagName("span")).Text;

            Assert.AreEqual("Сообщения", messageIconText);
        }
        
        
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
