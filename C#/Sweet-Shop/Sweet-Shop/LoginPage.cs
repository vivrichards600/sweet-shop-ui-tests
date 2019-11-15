
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Sweet_Shop
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        public void goToPage(string version = "")
        {
            driver.Navigate().GoToUrl($"https://sweetshop.netlify.com/login.html");
        }

        public string expectedPageTitle = "Sweet Shop";

        [FindsBy(How = How.CssSelector, Using = ".align-top")]
        public IWebElement navbarIcon;
        public string navbarIconSrc()
        {
            return navbarIcon.GetAttribute("src");
        }
        
        public string expectedNavbarIconSrc = "https://sweetshop.netlify.com/favicon.png";

        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement heading;

        public string expectedHeadingText = "Login";

        [FindsBy(How = How.CssSelector, Using = ".lead")]
        public IWebElement lead;

        public string expectedLeadText = "Please enter your email address and password in order to login to your account.";

        [FindsBy(How = How.CssSelector, Using = ".invalid-email")]
        public IWebElement invalidEmail;

        public string expectedInvalidEmail = "Please enter a valid email address.";

        [FindsBy(How = How.CssSelector, Using = ".invalid-password")]
        public IWebElement invalidPassword;

        public string expectedInvalidPassword = "Please enter a valid password.";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/form/div[1]/label")]
        public IWebElement emailLabel;

        public string expectedEmailLabelText = "Email address";

        [FindsBy(How = How.Id, Using = "exampleInputEmail")]
        public IWebElement emailInput;

        public string emailInputPlaceholderText()
        {
            return emailInput.GetAttribute("placeholder");
        }

        public string expectedEmailInputPlaceholderText = "you@example.com";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/form/div[2]/label")]
        public IWebElement passwordLabel;

        public string expectedPasswordLabelText = "Password";

        [FindsBy(How = How.Id, Using = "exampleInputPassword")]
        public IWebElement passwordInput;

        public string passwordInputPlaceholderText()
        {
            return passwordInput.GetAttribute("placeholder");
        }

        public string expectedPasswordInputPlaceholderText = "Password";

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement loginButton;

        public string expectedLoginButtonText = "Login";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/a[1]/img")]
        public IWebElement twitterIcon;

        public string twitterIconSrc()
        {
            return twitterIcon.GetAttribute("src");
        }

        public string expectedTwitterIconSrc = "https://sweetshop.netlify.com/img/twitter.png";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/a[2]/img")]
        public IWebElement facebookIcon;

        public string facebookIconSrc()
        {
            return facebookIcon.GetAttribute("src");
        }

        public string expectedFacebookIconSrc = "https://sweetshop.netlify.com/img/facebook.png";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/a[3]/img")]
        public IWebElement linkedInIcon;

        public string linkedInIconSrc()
        {
            return linkedInIcon.GetAttribute("src");
        }

        public string expectedLinkedInIconSrc = "https://sweetshop.netlify.com/img/linkedin.png";

        public void Submit(string email = "", string password = "")
        {
          emailInput.Clear();
            emailInput.SendKeys(email);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            loginButton.Click();
        }
    }
}