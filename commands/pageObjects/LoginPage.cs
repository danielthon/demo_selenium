using commands.selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.pageObjects
{
    public class LoginPage
    {
        internal static string Url { get { return ""; } }


        internal IWebElement txtUsername => Commands.findElement(By.Id("user-name"));
        internal IWebElement txtPassword => Commands.findElement(By.Id("password"));
        internal IWebElement btnLogin => Commands.findElement(By.CssSelector("[type=submit]"));


        public InventoryPage login(string username, string pwd)
        {
            txtUsername.typeText(username);
            txtPassword.typeText(pwd);

            btnLogin.Click();
            var inventory = new InventoryPage();

            return inventory;
        }
    }
}
