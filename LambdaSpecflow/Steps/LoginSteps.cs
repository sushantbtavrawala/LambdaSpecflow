using LambdaSpecflow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LambdaSpecflow.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        Pages.LoginPage loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup((string)data.Browser);
            driver.Url = "http://eaapp.somee.com/";
        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink()
        {
            loginPage.click_Login_Link();
            
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.enter_Username_Password((string)data.UserName, (string)data.Password);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            loginPage.click_Login_Button();
        }

        [Then(@"I should see employee details link")]
        public void ThenIShouldSeeEmployeeDetailsLink()
        {
            Assert.That(loginPage.is_Employee_Details_Exist(), Is.True);
        }

        [Then(@"I logout from the application")]
        public void ThenILogoutFromTheApplication()
        {
            loginPage.click_Logoff_Link();
        }
    }
}
