using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pages
{
    public class CheckoutYourInformationPage : SharedComponentsBetweenPages
    {
        internal override string Url { get { return "checkout-step-one.html"; } }

        internal IWebElement txtFirstName => Commands.findElement(By.Id("first-name"));
        internal IWebElement txtLastName => Commands.findElement(By.Id("last-name"));
        internal IWebElement txtZipPostalCode => Commands.findElement(By.Id("postal-code"));
        internal IWebElement btnContinue => Commands.findElement(By.Id("continue"));

        public CheckoutYourInformationPage fillYourInformation(string firstName, string lastName, string zipPostalCode)
        {
            txtFirstName.typeText(firstName);
            txtLastName.typeText(lastName);
            txtZipPostalCode.typeText(zipPostalCode);

            return this;
        }

        public CheckoutOverviewPage continueToOverview()
        {
            btnContinue.click();
            return new CheckoutOverviewPage();
        }
    }
}
