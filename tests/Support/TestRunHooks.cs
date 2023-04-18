using commands.selenium;
using commands.pageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace tests.Support
{
    [Binding]
    internal static class TestRunHooks
    {
        [BeforeTestRun]
        public static void BeforeFeature()
        {
            SeleniumWebDriver.start(
                TestContext.Parameters.Get("browser", "chrome")
                );
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            SeleniumWebDriver.stop();
        }
    }
}
