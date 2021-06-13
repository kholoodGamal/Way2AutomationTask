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
    public class RegistrationTest : BaseTest
    {
        [Test]
        public void RegisterUser()
        {
            string UserName = "angular";
            string Password = "password";
            string Description = "Registration link login";
            string ExpectedHomeText = "You're logged in!!";

            //Login
            var RegObject = new Registration(driver);
            RegObject.OpenRegistrationPage();
            RegObject.PerformLogin(UserName, Password, Description);
            string IsLoggedin = RegObject.CheckLoggedin();
            
            //Logout
            RegObject.LogOut();
            Boolean IsLoggedout = RegObject.CheckLoggedout();

            Assert.IsTrue(IsLoggedin.Equals(ExpectedHomeText), "Failed to log in");
            Assert.IsTrue(IsLoggedout.Equals(true), "Failed to log out");

        }
    }
}
