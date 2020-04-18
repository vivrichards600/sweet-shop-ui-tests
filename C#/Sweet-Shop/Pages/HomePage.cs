using OpenQA.Selenium;
using System.Collections.Generic;

namespace Sweet_Shop
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver _driver) => driver = _driver;

        public IWebElement NavbarIcon => driver.FindElement(By.CssSelector(".align-top"));
        public IWebElement NavbarTitle => driver.FindElement(By.CssSelector(".navbar-brand"));
        public IWebElement Navbar => driver.FindElement(By.CssSelector(".navbar-collapse"));
        public IWebElement Advert => driver.FindElement(By.XPath( "/html/body/div/header/div/img"));
        public IWebElement Heading => driver.FindElement(By.TagName("h1"));
        public IWebElement Lead => driver.FindElement(By.CssSelector(".lead"));
        public IWebElement BrowseSweets => driver.FindElement(By.CssSelector(".btn-primary"));
        public IList<IWebElement> DisplayedSweets => driver.FindElements(By.CssSelector(".cards"));
        public IWebElement FooterCopyright => driver.FindElement(By.XPath("/html/body/footer/div/p"));

        public void GoToPage() => driver.Navigate().GoToUrl("https://sweetshop.netlify.app/");

        public string NavbarIconSrc => NavbarIcon.GetAttribute("src");
        public string NavItemOneText =>  driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/a")).Text;
        public string NavItemTwoText => driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[1]/a")).Text;
        public string NavItemThreeText => driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[2]/a")).Text;
        public string NavItemFourText => driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[3]/a")).Text;

        public string AdvertSrc => Advert.GetAttribute("src");
        public string expectedPageTitle = "Sweet Shop";
        public string expectedNavbarIconSrc = "https://sweetshop.netlify.app/favicon.png";
        public string expectedNavbarTitle = "Sweet Shop";
        public string expectedNavItemOneText = "Sweets";
        public string expectedNavItemTwoText = "About";
        public string expectedNavItemThreeText = "Login";
        public string expectedNavItemFourText = "Basket";
        public string expectedAdvertSrc = "https://sweetshop.netlify.app/img/sale.gif";
        public string expectedHeadingText = "Welcome to the sweet shop!";
        public string expectedLeadText = "The sweetest online shop out there.";
        public string expectedBrowseSweetsButtonText = "Browse Sweets";
        public int expectedNumberOfDisplayedSweets = 4;
        public string expectedFooterCopyrightText = "Sweet Shop Project 2018";
    }
}