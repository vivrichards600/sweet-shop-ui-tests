using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Sweet_Shop
{
    [TestClass]
    public class DashboardTests : Pages
    {
        [TestMethod]
        public void DashboardTableSortTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.Submit(email: validEmail, password: validPassword);

            DashboardPage dashboard = new DashboardPage(driver);
            Assert.AreEqual(dashboard.expectedTableRowOneAmount, dashboard.tableRowOneAmount.Text);
            Assert.AreEqual(dashboard.expectedTableRowTwoAmount, dashboard.tableRowTwoAmount.Text);
            Assert.AreEqual(dashboard.expectedTableRowThreeAmount, dashboard.tableRowThreeAmount.Text);

            dashboard.sortTableByAmount();

            Assert.AreEqual(dashboard.expectedSortedTableRowOneAmount, dashboard.tableRowOneAmount.Text);
            Assert.AreEqual(dashboard.expectedSortedTableRowTwoAmount, dashboard.tableRowTwoAmount.Text);
            Assert.AreEqual(dashboard.expectedSortedTableRowThreeAmount, dashboard.tableRowThreeAmount.Text);
        }

        private string validEmail = "test@user.com";
        private string validPassword = "Password1";
    }
}