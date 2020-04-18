using OpenQA.Selenium;

namespace Sweet_Shop
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver _driver) => driver = _driver;

        public IWebElement NavbarIcon =>  driver.FindElement(By.CssSelector(".align-top"));
        public IWebElement Heading => driver.FindElement(By.TagName("h1"));
        public IWebElement Lead => driver.FindElement(By.CssSelector(".lead"));
        public IWebElement InvalidEmail => driver.FindElement(By.CssSelector(".invalid-email"));
        public IWebElement InvalidPassword => driver.FindElement(By.CssSelector(".invalid-password"));
        public IWebElement EmailLabel => driver.FindElement(By.XPath("/html/body/div/div/div/form/div[1]/label"));
        public IWebElement EmailInput => driver.FindElement(By.Id("exampleInputEmail"));
        public IWebElement PasswordLabel => driver.FindElement(By.XPath("/html/body/div/div/div/form/div[2]/label"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("exampleInputPassword"));
        public IWebElement LoginButton => driver.FindElement(By.CssSelector(".btn-primary"));
        public IWebElement TwitterIcon => driver.FindElement(By.XPath("/html/body/div/div/div/div/a[1]/img"));
        public IWebElement FacebookIcon => driver.FindElement(By.XPath("/html/body/div/div/div/div/a[2]/img"));
        public IWebElement LinkedInIcon => driver.FindElement(By.XPath("/html/body/div/div/div/div/a[3]/img"));

        public void GoToPage() => driver.Navigate().GoToUrl($"https://sweetshop.netlify.app/login.html");

        public void Submit(string email = "", string password = "")
        {
          EmailInput.Clear();
            EmailInput.SendKeys(email);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButton.Click();
        }

        public string expectedPageTitle = "Sweet Shop";
        public string NavbarIconSrc() => NavbarIcon.GetAttribute("src");
        public string expectedNavbarIconSrc = "https://sweetshop.netlify.app/favicon.png";
        public string expectedHeadingText = "Login";
        public string expectedLeadText = "Please enter your email address and password in order to login to your account.";
        public string expectedInvalidEmail = "Please enter a valid email address.";
        public string expectedInvalidPassword = "Please enter a valid password.";
        public string expectedEmailLabelText = "Email address";
        public string EmailInputPlaceholderText() => EmailInput.GetAttribute("placeholder");
        public string expectedEmailInputPlaceholderText = "you@example.com";
        public string expectedPasswordLabelText = "Password";
        public string PasswordInputPlaceholderText() => PasswordInput.GetAttribute("placeholder");
        public string expectedPasswordInputPlaceholderText = "Password";
        public string expectedLoginButtonText = "Login";
        public string TwitterIconSrc() => TwitterIcon.GetAttribute("src");
        public string expectedTwitterIconSrc = "https://sweetshop.netlify.app/img/twitter.png";
        public string FacebookIconSrc() => FacebookIcon.GetAttribute("src");
        public string expectedFacebookIconSrc = "https://sweetshop.netlify.app/img/facebook.png";
        public string LinkedInIconSrc() => LinkedInIcon.GetAttribute("src");
        public string expectedLinkedInIconSrc = "https://sweetshop.netlify.app/img/linkedin.png";
    }
}