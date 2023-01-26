using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace Amazon
{
    public class Tests
    {
        
        IWebDriver chrome;
       // IWebDriver ie;


        [SetUp]
        public void Setup()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            browserFactory.InitBrowser("chrome");
         //   browserFactory.InitBrowser("ie");

            chrome = browserFactory.Driver["CHROME"];
         //   ie = browserFactory.Driver["IE"];

            
        }

        [Test]
        public void Test1()
        {
            Amazon amazon = new Amazon(chrome);
            chrome.Navigate().GoToUrl("https://www.amazon.com/");
            amazon.Pages.Home.Searchbar.Text = "mouse";
            amazon.Pages.Home.Searchbar.Click();
            amazon.Pages.Results.GetResultsBy(new Dictionary<string, string>
            {
                {"price_lower_then" , "11" },
                {"price_higher_or_equal_then" , "5" },
                {"free_shipping" , "true" }
            });
        }
    }
}