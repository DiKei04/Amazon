using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    internal class Results
    {
        private IWebDriver driver;

        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<Item> GetResultsBy(Dictionary<string, string> filters)
        {
            List<Item> list = new List<Item>();

            string xPath = "//span[@class = 'a-price' ";

            foreach (var filter in filters)
            {
                switch (filter.Key)
                {
                    case "price_lower_then":
                        Console.WriteLine(xPath +=$" and concat(descendant::span[@class = 'a-price-whole']," +
                            $"descendant::span[@class ='a-price-fraction']) < {filter.Value}");
                        break;
                    case "price_higher_or_equal_then":
                        Console.WriteLine(xPath += $"and concat(descendant::span[@class = 'a-price-whole']," +
                            $"descendant::span[@class ='a-price-fraction']) >= {filter.Value} ");
                        break;
                    case "free_shipping":
                        if(filter.Value == "true")
                            Console.WriteLine(xPath += " and .//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small' and" +
                                " .//span[contains(text(), 'FREE Shipping')]]] ");
                        else
                            Console.WriteLine(xPath += " and .//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small' and" +
                                " .//span[not(contains(text(), 'FREE Shipping'))]]]");
                        break;
                }
                //for(int i = 1; i < items.Count; i++)
                //{
                //    list[i].title = items[i].Text;
                //    list[i].link = items[i].Text;
                //    list[i].price = items[i].Text;
                //    list[i].shipping = items[i].Text;
                //}
                

            }

            List<IWebElement> ListWebElements = this.driver.FindElements(By.XPath(xPath)).ToList();



            for (int i = 1; i < ListWebElements.Count; i++)
            {
                string link = ListWebElements[i].FindElement(By.XPath(".//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small']//a[@class = 'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']")).GetAttribute("href");
                string title = ListWebElements[i].FindElement(By.XPath(".//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small']//span[@class='a-size-medium a-color-base a-text-normal']")).Text;
                string priceWhole = ListWebElements[i].FindElement(By.XPath(".//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small']//span[@class='a-price-whole']")).Text;
                string priceFraction = ListWebElements[i].FindElement(By.XPath(".//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small']//span[@class='a-price-fraction']")).Text;
                string price = priceWhole +"."+ priceFraction;
                list.Add(new Item(link, title,price));

            }

            for (int i = 0; i<list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }

            return list;
        }
    }
}
