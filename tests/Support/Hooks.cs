using commands.selenium;
using commands.pageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow;

namespace tests.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ISpecFlowOutputHelper specFlowOutputHelper) { _specFlowOutputHelper = specFlowOutputHelper; }

        private static FeatureContext? _featureContext;
        private static ScenarioContext? _scenarioContext;

        public static string? featureTitle => _featureContext?.FeatureInfo.Title;
        public static string? featureDescription => _featureContext?.FeatureInfo.Description;
        public static string? scenarioTitle => _scenarioContext?.ScenarioInfo.Title;
        public static string? scenarioDescription => _scenarioContext?.ScenarioInfo.Description;
        public static string? stepText => _scenarioContext?.StepContext.StepInfo.Text;

        [BeforeFeature] public static void BeforeFeature(FeatureContext featureContext) { _featureContext = featureContext; }

        [BeforeScenario] public void BeforeScenario(ScenarioContext scenarioContext) { _scenarioContext = scenarioContext; }
        [AfterScenario] public void AfterScenario() { }

        [BeforeStep] public void BeforeStep() { _specFlowOutputHelper.addLog($"Started at {DateTime.Now:HH:mm:ss.f}"); }
        [AfterStep]  public void AfterStep() { _specFlowOutputHelper.addScreenshot(); }
    }
}
