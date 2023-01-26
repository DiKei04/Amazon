using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Home
    {
        private IWebDriver driver;
        private Searchbar searchbar;

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Searchbar Searchbar
        {
            get
            {
                if (this.searchbar == null)
                {
                    this.searchbar = new Searchbar(this.driver);
                }
                return this.searchbar;
            }
        }
    }
}
