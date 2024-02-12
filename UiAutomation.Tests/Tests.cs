using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UiAutomation.Tests
{
    public static class Tests
    {
        [SetUp]
        public static IWebDriver SetUp(IWebDriver driver)
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                //options.AddArgument("--disable-gpu");

                //options.AddArgument("--no-sandbox");
                //options.AddArgument("--disable-dev-shm-usage");
                // Initialize ChromeDriver with options

                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                driver = new ChromeDriver(path + @"\drivers\", options);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.onemap.gov.sg/");
                //driver = new ChromeDriver(options);


                return driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [TearDown]
        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
    }
}