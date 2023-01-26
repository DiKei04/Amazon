using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Searchbar
    {
        private IWebDriver driver;

        public Searchbar(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string Text
        {
            get
            {
                return this.Text;
               
            }
            set
            {
                driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(value);
            }
        }

        public void Click()
        {
            driver.FindElement(By.ClassName("nav-right")).Click();

        }
      }
}
