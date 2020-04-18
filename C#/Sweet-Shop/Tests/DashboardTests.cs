using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweet_Shop
{
    [TestClass]
    public class DashboardTests : Pages
    {
        [TestMethod]
        public void DashboardTableSortTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();
            login.Submit(email: validEmail, password: validPassword);

            DashboardPage dashboard = new DashboardPage(driver);
            Assert.AreEqual(dashboard.expectedTableRowOneAmount, dashboard.TableRowOneAmount.Text);
            Assert.AreEqual(dashboard.expectedTableRowTwoAmount, dashboard.TableRowTwoAmount.Text);
            Assert.AreEqual(dashboard.expectedTableRowThreeAmount, dashboard.TableRowThreeAmount.Text);

            dashboard.SortTableByAmount();

            Assert.AreEqual(dashboard.expectedSortedTableRowOneAmount, dashboard.TableRowOneAmount.Text);
            Assert.AreEqual(dashboard.expectedSortedTableRowTwoAmount, dashboard.TableRowTwoAmount.Text);
            Assert.AreEqual(dashboard.expectedSortedTableRowThreeAmount, dashboard.TableRowThreeAmount.Text);
        }

        private readonly string validEmail = "test@user.com";
        private readonly string validPassword = "Password1";
    }
}