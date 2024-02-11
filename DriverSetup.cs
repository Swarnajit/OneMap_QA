using OpenQA.Selenium;

namespace OneMap_QA
{
    public class DriverSetup
    {
        private readonly IWebDriver _driver;

        public DriverSetup(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}