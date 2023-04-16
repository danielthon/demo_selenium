using commands.selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace tests.Support
{
    public static class ReportCommands
    {
        public static void addScreenshot(this ISpecFlowOutputHelper specFlowOutputHelper)
        {
            string filePath = Commands.saveScreenshot($"{DateTime.Now:yyyyMMdd_HHmmss_f}");
            specFlowOutputHelper.AddAttachment(filePath);
        }

        public static void addErrorLog(this ISpecFlowOutputHelper specFlowOutputHelper, Exception e)
        {
            specFlowOutputHelper.WriteLine($"\"{e.Message}\" - Exception caught {e.StackTrace} - ({DateTime.Now:yyyy/MM/dd - HH:mm:ss})");
        }

        public static void addLog(this ISpecFlowOutputHelper specFlowOutputHelper, string message)
        {
            specFlowOutputHelper.WriteLine($"{message} ({DateTime.Now:yyyy/MM/dd - HH:mm:ss})");
        }
    }
}
