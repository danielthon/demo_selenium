using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pageObjects
{
    public class SharedComponentsBetweenPages
    {
        internal string RootUrl { get { return @"https://www.saucedemo.com/"; } }
        internal virtual string Url { get { return ""; } }

        public SharedComponentsBetweenPages(bool verifyUrl = true) 
        {
            if(verifyUrl)
            {
                var expected = RootUrl + Url;
                var current = SeleniumWebDriver.CurrentURL;

                if (current.Contains("?"))
                    current = current.Remove(current.IndexOf("?"));

                Commands.assert(expected, current);
            }
        }

        internal IWebElement btnOpenSideMenu => Commands.findElement(By.Id("react-burger-menu-btn"));
        internal IWebElement btnResetAppState => Commands.findElementWaitingtUntilVisible(By.Id("reset_sidebar_link"));

        public SharedComponentsBetweenPages resetAppState()
        {
            btnOpenSideMenu.click();
            btnResetAppState.click();
            return this;
        }
    }
}
