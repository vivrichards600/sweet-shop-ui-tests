using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Sweet_Shop
{
    [TestClass]
    public class LoginPageTests : Pages
    {
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
        public void LoginFailedNoCredentialsProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            login.Submit();
            Assert.AreEqual(login.expectedInvalidEmail, login.invalidEmail.Text);
            Assert.AreEqual(login.expectedInvalidPassword, login.invalidPassword.Text);
        }

        [TestMethod]
        public void LoginFailedInvalidPasswordProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            login.Submit(email: validEmail);
            Assert.AreEqual(login.expectedInvalidPassword, login.invalidPassword.Text);
        }

        [TestMethod]
        public void LoginFailedInvalidEmailProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            login.Submit(password: validPassword);
            Assert.AreEqual(login.expectedInvalidEmail, login.invalidEmail.Text);
        }


        [TestMethod]
        public void LoginWithValidCredentialsTest()
        {
            LoginPage login = new LoginPage(driver);
            login.goToPage();

            login.Submit(email: validEmail, password: validPassword);
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.AreEqual(dashboard.expectedLoggedInEmail, dashboard.loggedInEmail.Text);
        }

        private string validEmail = "test@user.com";
        private string validPassword = "Password1";
    }
}