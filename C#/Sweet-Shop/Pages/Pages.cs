using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace Sweet_Shop
{
    public class Pages
    {
        #region "Setup and tear down"
        public FirefoxDriver driver;

        [TestInitialize]
        public void Setup() => driver = new FirefoxDriver();

        [TestCleanup]
        public void Cleanup() => driver.Quit();
        #endregion
    }
}