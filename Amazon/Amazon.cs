using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{

    internal class Amazon
    {
        private Pages pages;
        private IWebDriver driver;

        public Amazon (IWebDriver driver)
        {
        this.driver = driver;
        driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        public Pages Pages
        {
            get
            {
                if (this.pages == null)
                {
                    this.pages = new Pages(this.driver);
                }
                return this.pages;
            }
        }

    }
}
