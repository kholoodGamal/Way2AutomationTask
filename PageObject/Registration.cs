using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace way2automation.PageObject
{
    public class Registration
    {
        IWebDriver driver;

        public Registration(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Registration Page
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Registration')]")]
        public IWebElement RegistrationLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#formly_1_input_username_0")]
        public IWebElement UserNameDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        public IWebElement LoginButton { get; set; }


        // Home Page after Log in
        [FindsBy(How = How.CssSelector, Using = "div.jumbotron:nth-child(3) div.container div.col-xs-offset-2.col-xs-8 div.ng-scope > p.ng-scope:nth-child(2)")]
        public IWebElement LoggedinText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        public IWebElement LogoutButton { get; set; }


        // Registration Methods
        public void OpenRegistrationPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", RegistrationLink);
            RegistrationLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void PerformLogin(string UserNameInput, string PasswordInput, string UserNameDescInput)
        {
            UserName.SendKeys(UserNameInput);
            Password.SendKeys(PasswordInput);
            UserNameDescription.SendKeys(UserNameDescInput);
            LoginButton.Click();
        }

        // Home page methods
        public string CheckLoggedin()
        {
            string HomeText = LoggedinText.Text;
            return HomeText;
        }

        public void LogOut()
        {
            LogoutButton.Click();
        }

        public Boolean CheckLoggedout()
        {
            Boolean IsLoggedOut = UserName.Displayed;
            return IsLoggedOut;
        }
    }
}
