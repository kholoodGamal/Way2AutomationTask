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
    public class MultiForm
    {
        IWebDriver driver;

        public MultiForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Multi Form')]")]
        public IWebElement MultiFormsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/input[1]")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[2]/input[1]")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[3]/div[1]/a[1]")]
        public IWebElement NextSectionButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//body[1]/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/label[1]")]
        public IWebElement XboxOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//body[1]/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[2]/label[1]")]
        public IWebElement PS4Opion { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[2]/div[1]/a[1]")]
        public IWebElement NextSectionButton2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Submit')]")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.TagName, Using = "pre")]
        public IWebElement SubmissionText { get; set; }

        public void OpenMultiFormPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", MultiFormsLink);
            MultiFormsLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        
        public void FillPage1(string NameInput, String EmailInput)
        {
            Name.SendKeys(NameInput);
            Email.SendKeys(EmailInput);
            NextSectionButton.Click();
        }

        public string MarkXboxOption()
        {
            XboxOption.Click();
            string XboxOptionText = XboxOption.Text;
            NextSectionButton2.Click();
            return XboxOptionText;
        }

        public string MarkPS4()
        {
            PS4Opion.Click();
            string PS4OptionText = PS4Opion.Text;
            NextSectionButton2.Click();
            return PS4OptionText;
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

   
        public void CancelAlert()
        {
            var JsAlert = driver.SwitchTo().Alert();
            JsAlert.Accept();
        }

        public String TextValidation()
        {
            String Text = SubmissionText.Text;
            return Text;
        }


    }
}
