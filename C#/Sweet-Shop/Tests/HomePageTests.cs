using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Sweet_Shop
{
    [TestClass]
    public class HomePageTests : Pages
    {
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
    }
}