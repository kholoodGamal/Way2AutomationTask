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
    public class WebTablesTest : BaseTest
    {

        [Test]
        public void AddUserToTable()
        {
            string FirstName = "Kholood";
            string LastName = "Gamal";
            string UserName = "KhGamal";
            string Password = "ZXC";
            string CustomerOption = "BBB";
            string RoleOption = "Customer";
            string Email = "Kh@G.com";
            string Phone = "011003200980";
            var AddUSerObject = new WebTables(driver);

            AddUSerObject.OpenWebTablesPage();
            int BasicNoRecords = AddUSerObject.NoOfRecords();
            Console.WriteLine(BasicNoRecords);


            //AddUser
            AddUSerObject.FillUserData(FirstName, LastName, UserName, Password, CustomerOption,
                RoleOption, Email, Phone);
            int AddExpected = BasicNoRecords + 1;
            int AddActual = AddUSerObject.NoOfRecords();
            Assert.IsTrue(AddActual.Equals(AddExpected), "User isn't added");
            //string ActualResultUserName = AddUSerObject.GetFirstRowUserName();
            //Assert.IsTrue(ActualResultUserName.Equals(UserName), "User isn't added Successfully");

            //Search for the user
            AddUSerObject.Search4User(FirstName);
            int NoRecordsAfterSearch = AddUSerObject.NoOfRecords();
            //Assert.IsTrue(NoRecordsAfterSearch.Equals(AddExpected), "Search Doesn't Return One Record");
            Console.WriteLine(NoRecordsAfterSearch);
            Assert.IsTrue(NoRecordsAfterSearch.Equals(5), "Search Doesn't Return One Record");

            //LockUser
            Boolean IsLocked = AddUSerObject.LockUSer();
            Assert.IsTrue(IsLocked.Equals(true), "User isn't Locked Successfully");

            //DeleteUser
            AddUSerObject.DeleteUser();
            int NoRecordsAfterDelete = AddUSerObject.NoOfRecords();
            //Assert.IsTrue(NoRecordsAfterDelete.Equals(BasicNoRecords), "Search Doesn't Return One Record");
            Console.WriteLine(NoRecordsAfterDelete);
            Assert.IsTrue(NoRecordsAfterDelete.Equals(4), "Recored is not deleted");

        }

    }
}
