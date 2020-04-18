using OpenQA.Selenium;

namespace Sweet_Shop
{
    public class DashboardPage
    {
        private IWebDriver driver;
        public DashboardPage(IWebDriver _driver) => driver = _driver;

        public IWebElement LoggedInEmail => driver.FindElement(By.XPath("/html/body/div/header/p/a"));
        public IWebElement TableRowOneAmount => driver.FindElement(By.XPath("//*[@id='transactions']/tbody/tr[1]/td[3]"));
        public IWebElement TableRowTwoAmount => driver.FindElement(By.XPath("//*[@id='transactions']/tbody/tr[2]/td[3]"));
        public IWebElement TableRowThreeAmount => driver.FindElement(By.XPath("//*[@id='transactions']/tbody/tr[3]/td[3]"));
        public IWebElement TransactionChart => driver.FindElement(By.Id("transactionChart"));

        public void SortTableByAmount() => _ = (string)((IJavaScriptExecutor)driver).ExecuteScript("SortTable(0,'N');");

        public string expectedLoggedInEmail = "test@user.com";
        public string expectedTableRowOneAmount = "1.50";
        public string expectedTableRowTwoAmount = "0.75";
        public string expectedTableRowThreeAmount = "8.00";
        public string expectedSortedTableRowOneAmount = "8.00";
        public string expectedSortedTableRowTwoAmount = "1.50";
        public string expectedSortedTableRowThreeAmount = "0.75";
    }
}