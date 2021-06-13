using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using way2automation.BaseClass;
using way2automation.PageObject;

namespace way2automation.TestScripts
{
    [TestFixture]
    public class CalculatorTest : BaseTest
    {
        [Test]
        public void Add()
        {
            var CalcObject = new Calculator(driver);
            CalcObject.OpenCalculatorPage();
            CalcObject.SetFirstParameter("20");
            CalcObject.SetSecondParameter("25");
            string AddingResult = CalcObject.Add();
            string ExpectedResult = "45";
            Assert.IsTrue(AddingResult.Equals(ExpectedResult), "The result is not correct");
        }

        [Test]
        public void Subtract()
        {
            var CalcObject = new Calculator(driver);
            CalcObject.OpenCalculatorPage();
            CalcObject.SetFirstParameter("25");
            CalcObject.SetSecondParameter("20");
            string SubtractResult =  CalcObject.Subtract();
            string ExpectedResult = "5";
            Assert.IsTrue(SubtractResult.Equals(ExpectedResult), "The result is not correct");

        }
    }
}
