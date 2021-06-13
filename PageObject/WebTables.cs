using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace way2automation.PageObject
{
    public class WebTables
    {
        IWebDriver driver;

        public WebTables(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'WebTables')]")]
        public IWebElement WebTablesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//thead/tr[2]/td[1]/button[1]")]
        public IWebElement AddUserButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[2]/input[1]")]
        public IWebElement FirstNAme { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[2]/td[2]/input[1]")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[3]/td[2]/input[1]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[4]/td[2]/input[1]")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[5]/td[2]/label[1]")]
        public IWebElement AAAOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[5]/td[2]/label[2]")]
        public IWebElement BBBOption { get; set; }

        [FindsBy(How = How.TagName, Using = "select")]
        public IWebElement Role { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[7]/td[2]/input[1]")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[8]/td[2]/input[1]")]
        public IWebElement CellPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save')]")]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        public IWebElement FirstRowUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//thead/tr[1]/td[1]/input[1]")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[10]/button[1]")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[9]/td[2]/label[1]/input[1]")]
        public IWebElement LockedCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[9]/input[1]")]
        public IWebElement LockedCheckBoxINTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[11]/button[1]/i[1]")]
        public IWebElement DeleteButtton { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'OK')]")]
        public IWebElement DeleteConfirmationButton { get; set; }

        [FindsBy(How = How.TagName, Using = "tr")]
        public IList<IWebElement> TableRecords { get; set; }


        public void OpenWebTablesPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", WebTablesLink);
            WebTablesLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void FillUserData(string FirstNameInput, string LastNameInput, 
            string UserNameInput, string PasswordInput, string CustomerInput, string RoleInput, string EmailInput, string CellPhoneInput)
        {
            AddUserButton.Click();
            FirstNAme.SendKeys(FirstNameInput);
            LastName.SendKeys(LastNameInput);
            UserName.SendKeys(UserNameInput);
            Password.SendKeys(PasswordInput);
           
            // Customer RadioButton Options
            if(CustomerInput == "AAA") {AAAOption.Click();}
            else if (CustomerInput == "BBB") {BBBOption.Click();}

            // DDL Options
            var RoleSelector = new SelectElement(Role);
            if (RoleInput == "Sales") { RoleSelector.SelectByIndex(1); }
            else if (RoleInput == "Customer") { RoleSelector.SelectByIndex(2); }
            else if (RoleInput == "Admin") { RoleSelector.SelectByIndex(3); }

            Email.SendKeys(EmailInput);
            CellPhone.SendKeys(CellPhoneInput);
            SaveButton.Click();
        }

        public string GetFirstRowUserName()
        {
            String UserName = FirstRowUserName.Text;
            return UserName;
        }

        public void Search4User(string SearchValue)
        {
            SearchField.SendKeys(SearchValue);
        }

        public Boolean LockUSer()
        {
            EditButton.Click();
            LockedCheckBox.Click();
            //Boolean IsChecked = LockedCheckBox.Selected;
            SaveButton.Click();
            Boolean IsChecked = LockedCheckBoxINTable.Selected;
            return IsChecked;
        }


        public void DeleteUser()
        {
            DeleteButtton.Click();
            DeleteConfirmationButton.Click();
        }

        public int NoOfRecords()
        {
            int NoRecords = TableRecords.Count;
            return NoRecords;
        }

    }
}
