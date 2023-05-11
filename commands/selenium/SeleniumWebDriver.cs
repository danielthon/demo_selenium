using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.selenium
{
    public enum Browser
    {
        Chrome = 1,
        Firefox = 2
    }

    public static class SeleniumWebDriver
    {
        internal static IWebDriver Driver { get; private set; }

        private static string DriversPath => AppContext.BaseDirectory;
        public static string? RootURL { get; set; }
        public static string CurrentURL => Driver.Url;

        public static void start(string browser)
        {
            try
            {
                start((Browser)Enum.Parse(typeof(Browser), browser, true));
            }
            catch
            {
                start(Browser.Chrome);
            }
        }
        private static void start(Browser browser)
        {
            if (Driver != null)
                stop();

            DriverOptions? options;

            switch (browser)
            {
                case Browser.Chrome:
                    options = new ChromeOptions();
                    break;

                case Browser.Firefox:
                    options = new FirefoxOptions();
                    break;

                default:
                    throw new ArgumentException("This browser is not supported.");
            }

            switch (options)
            {
                case ChromeOptions chrome:
                    chrome.AddArguments("disable-extensions");
                    chrome.AddArguments("--headless=new");
                    Driver = new ChromeDriver(DriversPath, chrome);
                    break;

                case FirefoxOptions fox:
                    fox.AddArguments("disable-extensions");
                    Driver = new FirefoxDriver(DriversPath, fox);
                    break;

                default:
                    throw new ArgumentException("This browser is not supported.");
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public static void stop()
        {
            Driver?.Quit();
            Driver.Dispose();
            Driver = null;
        }

        /// <summary>
        /// Navigates to specified URL. If it's not setted, navigates to the root URL.
        /// </summary>
        /// <param name="url"></param>
        public static void goToURL(string? url = null)
        {
            if (url == null)
                Driver?.Navigate().GoToUrl(RootURL);
            else
                Driver?.Navigate().GoToUrl(url);
        }
        public static void goBack()
        {
            Driver?.Navigate().Back();
        }

        public static void pageReload()
        {
            Driver?.Navigate().Refresh();
        }
    }
}
