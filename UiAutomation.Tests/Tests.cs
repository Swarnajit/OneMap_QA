using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace UiAutomation.Tests
{
    public class Tests
    {
        [SetUp]
        public static IWebDriver SetUp(IWebDriver driver)
        {
            string path = "C:\\Games\\CsharpActivity\\OneMap_QA\\bin\\drivers\\chromedriver.exe";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            // Initialize ChromeDriver with options

            driver = new ChromeDriver(path, options);

            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("https://www.onemap.gov.sg/");

            return driver;
        }
        [TearDown]
        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
    }
}