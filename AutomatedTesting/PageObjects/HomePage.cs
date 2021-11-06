using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomatedTesting.PageObjects
{
    public class HomePage
    {
        private const string Url = "https://www.olx.ua/uk/";
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = Url;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a#headerLogo.olx-website-rebranded")]
        public IWebElement Logo { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="input#headerSearch")]
        public IWebElement SearchInput { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="a#changeLang")]
        public IWebElement ChangeLanguage { get; set; }
        
        [FindsBy(How = How.CssSelector, Using="li#nav-conversations")]
        public IWebElement Messages { get; set; }
      
    }
}