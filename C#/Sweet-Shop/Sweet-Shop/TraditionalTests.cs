using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Sweet_Shop
{
    [TestClass]
    public class TraditionalTests
    {
        #region "Setup and tear down"
        private ChromeDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
        #endregion

        [TestMethod]
        public void LoginPageUIElementsTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            Assert.AreEqual(login.expectedPageTitle, driver.Title);

            Assert.IsTrue(login.navbarIcon.Displayed);
            Assert.AreEqual(login.expectedNavbarIconSrc, login.navbarIconSrc());

            Assert.AreEqual(login.expectedHeadingText, login.heading.Text);
            Assert.AreEqual(login.expectedLeadText, login.lead.Text);

            Assert.AreEqual(login.expectedEmailLabelText, login.emailLabel.Text);
            Assert.IsTrue(login.emailInput.Displayed);
            Assert.AreEqual(login.expectedEmailInputPlaceholderText, login.emailInputPlaceholderText());

            Assert.AreEqual(login.expectedPasswordLabelText, login.passwordLabel.Text);
            Assert.IsTrue(login.passwordInput.Displayed);
            Assert.AreEqual(login.expectedPasswordInputPlaceholderText, login.passwordInputPlaceholderText());

            Assert.IsTrue(login.loginButton.Displayed);
            Assert.AreEqual(login.expectedLoginButtonText, login.loginButton.Text);

            Assert.IsTrue(login.twitterIcon.Displayed);
            Assert.AreEqual(login.expectedTwitterIconSrc, login.twitterIconSrc());

            Assert.IsTrue(login.facebookIcon.Displayed);
            Assert.AreEqual(login.expectedFacebookIconSrc, login.facebookIconSrc());

            Assert.IsTrue(login.linkedInIcon.Displayed);
            Assert.AreEqual(login.expectedLinkedInIconSrc, login.linkedInIconSrc());
        }

        [TestMethod]
        public void LoginDataDrivenTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            login.Submit();
            Assert.AreEqual(login.expectedInvalidEmail, login.invalidEmail.Text);
            Assert.AreEqual(login.expectedInvalidPassword, login.invalidPassword.Text);

            login.Submit(email: validEmail);
            Assert.AreEqual(login.expectedInvalidPassword, login.invalidPassword.Text);

            login.Submit(password: validPassword);
            Assert.AreEqual(login.expectedInvalidEmail, login.invalidEmail.Text);

            login.Submit(email: validEmail, password: validPassword);
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.AreEqual(dashboard.expectedLoggedInEmail, dashboard.loggedInEmail.Text);
        }

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

        [TestMethod]
        public void CanvasChartTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();
            login.Submit(email: validEmail, password: validPassword);

            DashboardPage dashboard = new DashboardPage(driver);
            Assert.IsTrue(dashboard.transactionChart.Displayed);

            // Cannot automate. Only one HTML element <canvas> and testing mouse movements 
            // or JavaScript will be complex to both implement and maintain
            Assert.Inconclusive("Could not test Chart data");
        }

        [TestMethod]
        public void HomePageUIDynamicTest()
        {
            HomePage home = new HomePage(driver);
            home.goToPage(showAds: true);

            Assert.AreEqual(home.expectedPageTitle, driver.Title);

            Assert.IsTrue(home.navbarIcon.Displayed);
            Assert.AreEqual(home.expectedNavbarIconSrc, home.navbarIconSrc());
            Assert.AreEqual(home.expectedNavbarTitle, home.navbarTitle.Text);
            Assert.IsTrue(home.navbar.Displayed);
            Assert.AreEqual(home.expectedNavItemOneText, home.navItemOneText());
            Assert.AreEqual(home.expectedNavItemTwoText, home.navItemTwoText());
            Assert.AreEqual(home.expectedNavItemThreeText, home.navItemThreeText());
            Assert.IsTrue(home.navItemFourText().Contains(home.expectedNavItemFourText));

            Assert.IsTrue(home.advert.Displayed);
            Assert.AreEqual(home.expectedAdvertSrc, home.advertSrc());

            Assert.AreEqual(home.expectedHeadingText, home.heading.Text);
            Assert.AreEqual(home.expectedLeadText, home.lead.Text);
            Assert.AreEqual(home.expectedBrowseSweetsButtonText, home.browseSweets.Text);

            Assert.AreEqual(home.expectedNumberOfDisplayedSweets, home.displayedSweets.Count);

            Assert.AreEqual(home.expectedFooterCopyrightText, home.footerCopyright.Text);
        }

        private string validEmail = "test@user.com";
        private string validPassword = "Password1";
    }
}