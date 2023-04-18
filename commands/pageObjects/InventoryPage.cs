using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pageObjects
{
    public class InventoryPage
    {
        internal static string Url { get { return "/inventory"; } }


        internal IWebElement lblItemName(string name) => Commands.findElement(By.XPath($"//*[text()='{name}']"));
        internal IWebElement dropSort => Commands.findElement(By.CssSelector(".product_sort_container"));


        public InventoryPage sortProductsBy(string criteria)
        {
            dropSort.dropDownSelectByText(criteria);

            return this;
        }

        public InventoryPage clickProduct(string name) 
        {
            lblItemName(name).click();

            return this;
        }
    }
}
