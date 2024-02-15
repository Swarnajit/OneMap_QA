using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace UiAutomation.Tests
{
    public class Tests
    {
        public static IWebDriver driver = null;
        private static Dictionary<string, string> driverPaths =
            new Dictionary<string, string>()
            {
                {"chromeDriverPath", "path to chromedriver"},
                {"mozillaDriverPath", "path to geckodriver" },
            };

        [SetUp]
        public static IWebDriver ChromeSetUp(string chromeDriverPath)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-notifications");
            // Initialize ChromeDriver with options

            driver = new ChromeDriver(chromeDriverPath, options);

            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("https://www.onemap.gov.sg/");

            return driver;
        }
        public static IWebDriver FirefoxSetUp(string mozillaDriverPath)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-notifications");
            options.SetPreference("geo.prompt.testing", true);
            options.SetPreference("geo.prompt.testing.allow", false);
            // Initialize Firefoxdriver with options

            driver = new FirefoxDriver(mozillaDriverPath, options);

            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("https://www.onemap.gov.sg/");

            return driver;
        }
        public static IWebDriver SetUp()
        {
            IWebDriver setUpdriver = null;
            foreach (KeyValuePair<string, string> driverPath in driverPaths)
            {
                switch (driverPath.Key)
                {
                    case "chromeDriverPath":
                        setUpdriver = ChromeSetUp(driverPath.Value);
                        break;

                    case "mozillaDriverPath":
                        setUpdriver = FirefoxSetUp(driverPath.Value);
                        break;

                    case "ieDriverPath":
                        setUpdriver = ChromeSetUp(driverPath.Value);
                        break;
                }
            }
            return setUpdriver;
        }

        [TearDown]
        public static void CloseBrowser()
        {
            foreach (KeyValuePair<string, string> driverPath in driverPaths)
            {
                switch (driverPath.Key)
                {
                    case "chromeDriverPath":
                        driver.Close();
                        driver.Quit();
                        break;

                    case "mozillaDriverPath":
                        driver.Close();
                        driver.Quit();
                        break;

                    case "ieDriverPath":
                        driver.Close();
                        driver.Quit();
                        break;
                }
            }
        }
    }
}