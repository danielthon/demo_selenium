﻿using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pages
{
    public class CartPage : SharedComponentsBetweenPages
    {
        internal override string Url { get { return "cart.html"; } }

        internal IWebElement btnCheckout => Commands.findElement(By.Id("checkout"));

        public CheckoutYourInformationPage goToCheckout()
        {
            btnCheckout.click();
            return new CheckoutYourInformationPage();
        }
    }
}
