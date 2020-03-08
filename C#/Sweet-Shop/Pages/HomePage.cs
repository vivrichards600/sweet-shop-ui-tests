
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Sweet_Shop
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        public void goToPage(string version = "", bool showAds = false)
        {
            driver.Navigate().GoToUrl("https://sweetshop.netlify.com/");
        }

        public string expectedPageTitle = "Sweet Shop";

        [FindsBy(How = How.CssSelector, Using = ".align-top")]
        public IWebElement navbarIcon;
        public string navbarIconSrc()
        {
            return navbarIcon.GetAttribute("src");
        }

        public string expectedNavbarIconSrc = "https://sweetshop.netlify.com/favicon.png";

        [FindsBy(How = How.CssSelector, Using = ".navbar-brand")]
        public IWebElement navbarTitle;

        public string expectedNavbarTitle = "Sweet Shop";

        [FindsBy(How = How.CssSelector, Using = ".navbar-collapse")]
        public IWebElement navbar;

        public string navItemOneText()
        {
            return driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/a")).Text;
        }
        public string navItemTwoText()
        {
            return driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[1]/a")).Text;
        }
        public string navItemThreeText()
        {
            return driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[2]/a")).Text;
        }
        public string navItemFourText()
        {
            return driver.FindElement(By.XPath("//*[@id='navbarColor01']/ul/li[3]/a")).Text;
        }

        public string expectedNavItemOneText = "Sweets";
        public string expectedNavItemTwoText = "About";
        public string expectedNavItemThreeText = "Login";
        public string expectedNavItemFourText = "Basket";

        [FindsBy(How = How.XPath, Using = "/html/body/div/header/div/img")]
        public IWebElement advert;
        public string advertSrc()
        {
            return advert.GetAttribute("src");
        }

        public string expectedAdvertSrc = "https://sweetshop.netlify.com/img/sale.gif";

        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement heading;

        public string expectedHeadingText = "Welcome to the sweet shop!";

        [FindsBy(How = How.CssSelector, Using = ".lead")]
        public IWebElement lead;

        public string expectedLeadText = "The sweetest online shop out there.";

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement browseSweets;

        public string expectedBrowseSweetsButtonText = "Browse Sweets";

        [FindsBy(How = How.CssSelector, Using = ".cards")]
        public IList<IWebElement> displayedSweets;

        public int expectedNumberOfDisplayedSweets = 4;
        
        [FindsBy(How = How.XPath, Using = "/html/body/footer/div/p")]
        public IWebElement footerCopyright;

        public string expectedFooterCopyrightText = "Sweet Shop Project 2018";
    }
}