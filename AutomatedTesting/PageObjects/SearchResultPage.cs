using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomatedTesting.PageObjects
{
    public class SearchResultPage
    {
        private WebDriverWait _wait;
        public SearchResultPage(WebDriverWait wait)
        {
            _wait = wait;
        }

        public IWebElement FirstSearchResult => _wait.Until(
            ExpectedConditions.ElementExists(By.CssSelector("a.goods-tile__heading")));
    }
}