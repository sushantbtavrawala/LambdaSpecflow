using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace LambdaSpecflow.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup(string browserName)
        {
            dynamic capability = GetBrowserOptions(browserName);
            driver = new RemoteWebDriver(new Uri("http://localhost:4545/grid/console"), capability.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();

            return driver;
        }
        
        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName.ToLower() == "chrome")
                return new ChromeOptions();
            if (browserName.ToLower() == "firefox")
                return new FirefoxOptions();

            return new ChromeOptions();
        }
    }
}
