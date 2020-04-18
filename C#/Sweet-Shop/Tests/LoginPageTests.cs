using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweet_Shop
{
    [TestClass]
    public class LoginPageTests : Pages
    {
        [TestMethod]
        public void LoginPageUIElementsTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();

            Assert.AreEqual(login.expectedPageTitle, driver.Title);

            Assert.IsTrue(login.NavbarIcon.Displayed);
            Assert.AreEqual(login.expectedNavbarIconSrc, login.NavbarIconSrc());

            Assert.AreEqual(login.expectedHeadingText, login.Heading.Text);
            Assert.AreEqual(login.expectedLeadText, login.Lead.Text);

            Assert.AreEqual(login.expectedEmailLabelText, login.EmailLabel.Text);
            Assert.IsTrue(login.EmailInput.Displayed);
            Assert.AreEqual(login.expectedEmailInputPlaceholderText, login.EmailInputPlaceholderText());

            Assert.AreEqual(login.expectedPasswordLabelText, login.PasswordLabel.Text);
            Assert.IsTrue(login.PasswordInput.Displayed);
            Assert.AreEqual(login.expectedPasswordInputPlaceholderText, login.PasswordInputPlaceholderText());

            Assert.IsTrue(login.LoginButton.Displayed);
            Assert.AreEqual(login.expectedLoginButtonText, login.LoginButton.Text);

            Assert.IsTrue(login.TwitterIcon.Displayed);
            Assert.AreEqual(login.expectedTwitterIconSrc, login.TwitterIconSrc());

            Assert.IsTrue(login.FacebookIcon.Displayed);
            Assert.AreEqual(login.expectedFacebookIconSrc, login.FacebookIconSrc());

            Assert.IsTrue(login.LinkedInIcon.Displayed);
            Assert.AreEqual(login.expectedLinkedInIconSrc, login.LinkedInIconSrc());
        }

        [TestMethod]
        public void LoginFailedNoCredentialsProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();

            login.Submit();
            Assert.AreEqual(login.expectedInvalidEmail, login.InvalidEmail.Text);
            Assert.AreEqual(login.expectedInvalidPassword, login.InvalidPassword.Text);
        }

        [TestMethod]
        public void LoginFailedInvalidPasswordProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();

            login.Submit(email: validEmail);
            Assert.AreEqual(login.expectedInvalidPassword, login.InvalidPassword.Text);
        }

        [TestMethod]
        public void LoginFailedInvalidEmailProvidedTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();

            login.Submit(password: validPassword);
            Assert.AreEqual(login.expectedInvalidEmail, login.InvalidEmail.Text);
        }


        [TestMethod]
        public void LoginWithValidCredentialsTest()
        {
            LoginPage login = new LoginPage(driver);
            login.GoToPage();

            login.Submit(email: validEmail, password: validPassword);
            DashboardPage dashboard = new DashboardPage(driver);
            Assert.AreEqual(dashboard.expectedLoggedInEmail, dashboard.LoggedInEmail.Text);
        }

        private readonly string validEmail = "test@user.com";
        private readonly string validPassword = "Password1";
    }
}