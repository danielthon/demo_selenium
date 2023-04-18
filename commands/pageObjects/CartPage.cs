using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pageObjects
{
    public class CartPage
    {
        internal static string Url { get { return "/cart"; } }

        internal IWebElement btnCheckout => Commands.findElement(By.Id("checkout"));

        public CheckoutYourInformationPage goToCheckout()
        {
            btnCheckout.click();
            return new CheckoutYourInformationPage();
        }
    }
}
