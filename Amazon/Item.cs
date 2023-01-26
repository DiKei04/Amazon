using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    internal class Item
    {
        public string link { get; set; }
        public string title { get; set; }
        public string price { get; set; }

        public Item(string link, string title,string price)
        {
            this.link = link;
            this.title = title;
            this.price = price;

        }


        public override string ToString()
        {
            return "Title is: "+this.title+"\nLink is: "+this.link + "\nPrice is: $"+this.price;

        }
    }
}
