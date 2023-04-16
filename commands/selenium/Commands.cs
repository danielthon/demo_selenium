using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using commands.exceptions;
using System.Globalization;

namespace commands.selenium
{
    public static class Commands
    {
        internal static IWebElement findElement(By by)
        {
            try
            {
                return SeleniumWebDriver.Driver.FindElement(by).moveToElement();
            }
            catch (Exception e)
            {
                throw new NoSuchElementException($"It couldn't find an element {by?.ToString()}. | \"{e.Message}\"");
            }
        }
        internal static IWebElement findElement(this IWebElement element, By by)
        {
            try
            {
                return element.FindElement(by).moveToElement();
            }
            catch (Exception e)
            {
                throw new NoSuchElementException($"It couldn't find an element  {by?.ToString()}. | \"{e.Message}\"");
            }
        }
        internal static IWebElement moveToElement(this IWebElement element)
        {
            Actions actions = new Actions(SeleniumWebDriver.Driver);
            actions?.MoveToElement(element).Perform();
            return element;
        }


        internal static void typeText(this IWebElement element, string entrada)
        {
            if (!element.Displayed)
                throw new ElementNotVisibleException($"'{element.TagName}' (class={element?.GetCssValue("class")}) was found on the page, but it's not visible/accessible.");

            element.Clear();
            element?.SendKeys(entrada);
        }
        internal static void click(this IWebElement element)
        {
            try
            {
                element?.Click();
            }
            catch (Exception e)
            {
                if (e is ElementClickInterceptedException || e is ElementNotInteractableException)
                {
                    try
                    {
                        ((IJavaScriptExecutor)SeleniumWebDriver.Driver).ExecuteScript("arguments[0].click();", element);
                    }
                    catch
                    {
                        throw e;
                    }
                }
                else
                    throw;
            }
        }
        internal static void dropDownSelectByText(this IWebElement element, string option)
        {
            try
            {
                (new SelectElement(element)).SelectByText(option);
            }
            catch
            {
                throw new NoSuchElementException($"It couldn't find the option '{option}'");
            }
        }
        internal static void dropDownSelectByValue(this IWebElement element, string option)
        {
            try
            {
                (new SelectElement(element)).SelectByValue(option);
            }
            catch
            {
                throw new NoSuchElementException($"It couldn't find the option '{option}'");
            }
        }


        public static void assert(string expected, string current)
        {
            if (expected != current)
                throw new AssertionException(expected, current);
        }


        public static string saveScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)SeleniumWebDriver.Driver).GetScreenshot();

            string path = $@".\Screenshots";
            string imgPath = $@"{path}\{fileName}.png";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            screenshot?.SaveAsFile(imgPath, ScreenshotImageFormat.Png);

            return imgPath;
        }

        public static string toCamelCase(this string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(text.Replace(" ",""));
        }
    }
}
