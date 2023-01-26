using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Pages
    {
        private IWebDriver driver;
        private Home home;
        private Results results;

        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Home Home
        {
            get
            {
                if (this.home == null)
                {
                    this.home = new Home(this.driver);
                }
                return this.home;
            }
        }

        public Results Results
        {
            get
            {
                if (this.results == null)
                {
                    this.results = new Results(this.driver);
                }
                return this.results;
            }
        }

    }
}

