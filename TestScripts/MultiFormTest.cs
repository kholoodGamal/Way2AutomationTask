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
    public class MultiFormTest : BaseTest
    {
        [Test]
        public void SubmitMultiFormsXBox()
        {
            string Name = "Kholood";
            string Email = "Kholood@yahoo.com";
            var MultiFormObject = new MultiForm(driver);
            MultiFormObject.OpenMultiFormPage();
            MultiFormObject.FillPage1(Name, Email);
            MultiFormObject.MarkXboxOption();
            MultiFormObject.Submit();
            MultiFormObject.CancelAlert();
            String ActualText = MultiFormObject.TextValidation();
            Assert.IsTrue(ActualText.Contains(Name), "System doesn't contain the added Name");
            Assert.IsTrue(ActualText.Contains(Email), "System doesn't contain the added Email");
            Assert.IsTrue(ActualText.Contains("xbox"), "System doesn't contain the selected Radio Button xbox");
        }

        [Test]
        public void SubmitMultiFormsPS4()
        {
            string Name = "Kholood";
            string Email = "Kholood@yahoo.com";

            var MultiFormObject = new MultiForm(driver);
            MultiFormObject.OpenMultiFormPage();
            MultiFormObject.FillPage1(Name, Email);
            MultiFormObject.MarkPS4();
            MultiFormObject.Submit();
            MultiFormObject.CancelAlert();
            String ActualText = MultiFormObject.TextValidation();
            Assert.IsTrue(ActualText.Contains(Name), "System doesn't contain the added Name");
            Assert.IsTrue(ActualText.Contains(Email), "System doesn't contain the added Email");
            Assert.IsTrue(ActualText.Contains("ps"), "System doesn't contain the selected Radio Button ps");
        }

    }
}
