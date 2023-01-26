using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class BrowserFactory
    {
        private Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();

        public Dictionary<string, IWebDriver> Driver
        {
            get
            {
                return this.drivers;
            }
            private set
            {
                this.drivers= value;
            }
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    if (!this.drivers.ContainsKey("FIREFOX"))
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArgument("start-maximized");

                        IWebDriver driver = new FirefoxDriver("C:\\Driver", options);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        this.drivers.Add("FIREFOX", driver);

                    }
                    break;

                case "IE":
                    if (!this.drivers.ContainsKey("IE"))
                    {
                        InternetExplorerOptions options = new InternetExplorerOptions();

                        IWebDriver driver = new InternetExplorerDriver("C:\\Driver", options);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        this.drivers.Add("IE", driver);
                    }
                    break;

                case "CHROME":
                    if (!this.drivers.ContainsKey("CHROME"))
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("start-maximized");

                        IWebDriver driver = new ChromeDriver("C:\\Driver", options);
                        driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);

                        this.drivers.Add("CHROME", driver);
                    }
                    break;
            }
        }

        public void LoadApplication(string browserName, string url)
        {
            this.drivers[browserName].Url= url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in this.drivers.Keys)
            {
                this.drivers[key].Close();
                this.drivers[key].Quit();

            }
        }
    }
}

