using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaSpecflow.Pages
{
    class LoginPage
    {

        public IWebDriver WebDriver { get; private set; }
        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //UI Elements
        private IWebElement lnkLogin => WebDriver.FindElement(By.LinkText("Login"));
        private IWebElement txtUserName => WebDriver.FindElement(By.Name("UserName"));
        private IWebElement txtPassword => WebDriver.FindElement(By.Name("Password"));
        private IWebElement btnLogin => WebDriver.FindElement(By.CssSelector(".btn-default"));
        private IWebElement lnkEmployeeDetails => WebDriver.FindElement(By.LinkText("Employee Details"));
        private IWebElement lnkLogOff => WebDriver.FindElement(By.LinkText("Log off"));


        public void click_Login_Link() => lnkLogin.Click();
        public void enter_Username_Password(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void click_Login_Button() => btnLogin.Submit();

        public bool is_Employee_Details_Exist() => lnkEmployeeDetails.Displayed;

        public void click_Logoff_Link() => lnkLogOff.Click();

    }
}

