using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Sweet_Shop
{
    public class Pages
    {
        #region "Setup and tear down"
        public ChromeDriver driver;

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
    }
}