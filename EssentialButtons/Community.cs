using OneMap_QA;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiAutomation.Setup.EssentialButtons
{
    public class Community : DriverSetup
    {
        public IWebDriver _driver;
        public Community(IWebDriver driver) : base(driver)
        {
            DriverSetup webDriverManager = new DriverSetup(driver);
            _driver = webDriverManager.GetDriver(); // Get the WebDriver instance
        }

        public IWebElement RouteIcon => _driver.FindElement(By.Id("route-icon"));
        public IWebElement OriginLocation => _driver.FindElement(By.Id("originInput"));
        public IWebElement DestinationLocation => _driver.FindElement(By.Id("destinationInput"));

        public IWebElement CommunityButton => _driver.FindElement(By.Id("Community"));
        public IWebElement SearchLocation => _driver.FindElement(By.Id("search_property"));
        public List<IWebElement> SearchResult => new List<IWebElement>
            (_driver.FindElements(By.ClassName("searchresult_address")));
        public IWebElement LocationInfoBox => _driver.FindElement(By.Id("markerInfoContent")); 
        public IWebElement SchoolQueryButton { get; set; }
        public IWebElement MedicalButton { get; set; }
        public IWebElement HawkersCenterButton { get; set; }
    }
}
