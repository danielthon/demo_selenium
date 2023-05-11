using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pages
{
    public class CheckoutOverviewPage : SharedComponentsBetweenPages
    {
        internal override string Url { get { return "checkout-step-two.html"; } }

        internal IWebElement lblFirstCartItemName => Commands.findElement(By.CssSelector(".cart_list .inventory_item_name"));
        internal IWebElement btnCheckout => Commands.findElement(By.Id("checkout"));

        public CheckoutOverviewPage assertCheckoutProductTitle(string productTitle)
        {
            string currentText = lblFirstCartItemName.Text;
            Commands.assert(productTitle, currentText);
            return this;
        }
    }
}
