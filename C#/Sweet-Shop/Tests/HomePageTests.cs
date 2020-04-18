using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweet_Shop
{
    [TestClass]
    public class HomePageTests : Pages
    {
        [TestMethod]
        public void HomePageUIDynamicTest()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();

            Assert.AreEqual(home.expectedPageTitle, driver.Title);

            Assert.IsTrue(home.NavbarIcon.Displayed);
            Assert.AreEqual(home.expectedNavbarIconSrc, home.NavbarIconSrc);
            Assert.AreEqual(home.expectedNavbarTitle, home.NavbarTitle.Text);
            Assert.IsTrue(home.Navbar.Displayed);
            Assert.AreEqual(home.expectedNavItemOneText, home.NavItemOneText);
            Assert.AreEqual(home.expectedNavItemTwoText, home.NavItemTwoText);
            Assert.AreEqual(home.expectedNavItemThreeText, home.NavItemThreeText);
            Assert.IsTrue(home.NavItemFourText.Contains(home.expectedNavItemFourText));

            Assert.IsTrue(home.Advert.Displayed);
            Assert.AreEqual(home.expectedAdvertSrc, home.AdvertSrc);

            Assert.AreEqual(home.expectedHeadingText, home.Heading.Text);
            Assert.AreEqual(home.expectedLeadText, home.Lead.Text);
            Assert.AreEqual(home.expectedBrowseSweetsButtonText, home.BrowseSweets.Text);

            Assert.AreEqual(home.expectedNumberOfDisplayedSweets, home.DisplayedSweets.Count);

            Assert.AreEqual(home.expectedFooterCopyrightText, home.FooterCopyright.Text);
        }
    }
}