using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomatedTesting.PageObjects
{
    public class HomePage
    {
        private const string Url = "https://www.rozetka.com.ua/";
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = Url;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a.header__logo")]
        public IWebElement Logo { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="input.search-form__input")]
        public IWebElement SearchInput { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="ul.lang-header")]
        public IWebElement ChangeLanguage { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="button.search-form__submit")]
        public IWebElement FindButton { get; set; }
      
    }
}