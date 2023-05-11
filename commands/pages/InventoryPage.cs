using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pages
{
    public class InventoryPage : SharedComponentsBetweenPages
    {
        internal override string Url { get { return "inventory.html"; } }


        internal IWebElement lblItemName(string productName) => Commands.findElement(By.XPath($"//*[text()='{productName}']"));
        internal IWebElement btnAddToCart(string productName) => Commands.findElement(By.XPath($"//*[text()='{productName}']/../../..//button"));
        internal IWebElement dropSort => Commands.findElement(By.CssSelector(".product_sort_container"));
        internal IWebElement btnCart => Commands.findElement(By.Id("shopping_cart_container"));
        private IWebElement waitForBtnCart() => Commands.findElementWaitingtUntilVisible(By.Id("shopping_cart_container"), 8);


        public void waitForPageLoad() => waitForBtnCart();

        public InventoryPage sortProductsBy(string criteria)
        {
            dropSort.dropDownSelectByText(criteria);
            return this;
        }

        public InventoryPage clickProduct(string productName) 
        {
            lblItemName(productName).click();
            return this;
        }

        public InventoryPage addToCart(string productName)
        {
            btnAddToCart(productName).click();
            return this;
        }

        public CartPage goToCart()
        {
            btnCart.click();
            return new CartPage();
        }
    }
}
