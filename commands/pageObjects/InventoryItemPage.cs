using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pageObjects
{
    public class InventoryItemPage
    {
        internal static string Url { get { return "/inventory-item"; } }


        internal IWebElement lblTitle => Commands.findElement(By.CssSelector($".inventory_details_name"));
        internal IWebElement lblDescription => Commands.findElement(By.CssSelector(".inventory_details_desc"));


        public InventoryItemPage assertProductTitle(string title)
        {
            Commands.assert(title, lblTitle.Text);

            return this;
        }

        public InventoryItemPage assertProductDescription(string description)
        {
            Commands.assert(description, lblDescription.Text);

            return this;
        }
    }
}
