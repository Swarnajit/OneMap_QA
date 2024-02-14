using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Metrics;
using UiAutomation.Setup.EssentialButtons;

namespace UiAutomation.Tests.EssentialButtonTests
{
    public class CommunityTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Community communityWebElements;

        private const string searchText = "Chinatown";
        private const string expectedAddress = "335 SMITH STREET CHINATOWN COMPLEX SINGAPORE 050335";

        [SetUp]
        public void SetUp()
        {
            driver = Tests.SetUp();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            communityWebElements = new Community(driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Tests.CloseBrowser();
        }

        //[Test]
        //public void Verify_Text()
        //{
        //    communityWebElements.CommunityButton.Click();

        //    Assert.That(communityWebElements.CommunityButton.GetAttribute("class"), Is.EqualTo("essentialTopBtn esOption btnactive"));
        //}

        //[Test]
        //public void Find_Location()
        //{
        //    driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);

        //    SharedMethods.typeInSearch(communityWebElements.SearchLocation, searchText);

        //    wait.Until(driver => communityWebElements.SearchResult.Count > 0);

        //    foreach (IWebElement locationAddress in communityWebElements.SearchResult)
        //    {
        //        if (locationAddress.Text.Equals(expectedAddress))
        //        {
        //            locationAddress.Click();
        //        }
        //    }

        //    string actualLocationAddress = communityWebElements.LocationInfoBox.FindElements(By.TagName("span"))
        //        .LastOrDefault().Text;

        //    Assert.That(actualLocationAddress, Is.EqualTo(expectedAddress), "Location Address not same");
        //}

        [Test]
        [TestCase("Marina Bay Skypark", "1 BAYFRONT AVENUE MARINA BAY SANDS SKYPARK SINGAPORE 018971")]
        public void NavigateToLocation(string destination, string destinationAddress)
        {
            string origin = searchText;
            string originAddress = expectedAddress;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            communityWebElements.RouteIcon.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("originInput")));

            SharedMethods.typeInSearch(communityWebElements.OriginLocation, origin);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("destinationInput")));

            SharedMethods.typeInSearch(communityWebElements.DestinationLocation, destination);

            Assert.Multiple(() =>
            {
                Assert.True(communityWebElements.RouteOptionTransit.Displayed,
                    $"{communityWebElements.RouteOptionTransit} is displayed");

                Assert.True(communityWebElements.RouteOptionBus.Displayed,
                    $"{communityWebElements.RouteOptionBus} is displayed");

                Assert.True(communityWebElements.RouteOptionCar.Displayed,
                    $"{communityWebElements.RouteOptionCar} is displayed");

                Assert.True(communityWebElements.RouteOptionCycle.Displayed,
                    $"{communityWebElements.RouteOptionCycle} is displayed");

                Assert.True(communityWebElements.RouteOptionWalk.Displayed,
                    $"{communityWebElements.RouteOptionWalk} is displayed");

                Assert.True(communityWebElements.RouteOptionTransit.GetAttribute("class").Contains("active"),
                    "Transit mode was not selected by default");
            });
        }
    }
}
