using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace way2automation.PageObject
{
    public class Calculator
    {

        IWebDriver driver;

        public Calculator(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Calculator')]")]
        public IWebElement CalculatorLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/form[1]/input[1]")]
        public IWebElement FirstParameter { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[3]/div[1]/form[1]/input[2]")]
        public IWebElement SecondParameter { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'-')]")]
        public IWebElement MinusOption { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#gobutton")]
        public IWebElement GoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        public IWebElement CalculationResult { get; set; }


        public void OpenCalculatorPage()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", CalculatorLink);
            CalculatorLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void SetFirstParameter(String FirstParameterInput)
        {
            FirstParameter.SendKeys(FirstParameterInput);

        }

        public void SetSecondParameter(String SecondParameterInput)
        {
            SecondParameter.SendKeys(SecondParameterInput);
        }

        public string Add()
        {
            GoButton.Click();
            return CalculationResult.Text;
        }

        public string Subtract()
        {
            MinusOption.Click();
            GoButton.Click();
            return CalculationResult.Text;
        }


    }
}
