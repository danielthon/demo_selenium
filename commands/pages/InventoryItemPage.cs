using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pages
{
    public class InventoryItemPage : SharedComponentsBetweenPages
    {
        internal override string Url { get { return "inventory-item.html"; } }


        internal IWebElement lblTitle => Commands.findElement(By.CssSelector($".inventory_details_name"));
        internal IWebElement lblDescription => Commands.findElement(By.CssSelector(".inventory_details_desc"));


        public InventoryItemPage assertProductTitle(string title)
        {
            string currentText = lblTitle.Text;
            Commands.assert(title, currentText);

            return this;
        }

        public InventoryItemPage assertProductDescription(string description)
        {
            string currentText = lblDescription.Text;
            Commands.assert(description, currentText);

            return this;
        }
    }
}
