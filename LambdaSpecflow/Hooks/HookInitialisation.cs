using LambdaSpecflow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace LambdaSpecflow.Hooks
{
    [Binding]
    public sealed class HookInitialisation
    {
        private readonly ScenarioContext _scenarioContext;

        public HookInitialisation(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quite");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}
