using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Sweet_Shop
{
    class DashboardPage
    {
        private IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/header/p/a")]
        public IWebElement loggedInEmail;

        public string expectedLoggedInEmail = "test@user.com";

        public void sortTableByAmount()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            _ = (string)js.ExecuteScript("SortTable(0,'N');");
        }
               
        [FindsBy(How = How.XPath, Using = "//*[@id='transactions']/tbody/tr[1]/td[3]")]
        public IWebElement tableRowOneAmount;

        [FindsBy(How = How.XPath, Using = "//*[@id='transactions']/tbody/tr[2]/td[3]")]
        public IWebElement tableRowTwoAmount;

        [FindsBy(How = How.XPath, Using = "//*[@id='transactions']/tbody/tr[3]/td[3]")]
        public IWebElement tableRowThreeAmount;

        public string expectedTableRowOneAmount = "1.50";
        public string expectedTableRowTwoAmount = "0.75";
        public string expectedTableRowThreeAmount = "8.00";

        public string expectedSortedTableRowOneAmount = "8.00";
        public string expectedSortedTableRowTwoAmount = "1.50";
        public string expectedSortedTableRowThreeAmount = "0.75";

        [FindsBy(How = How.Id, Using = "transactionChart")]
        public IWebElement transactionChart;
    }
}