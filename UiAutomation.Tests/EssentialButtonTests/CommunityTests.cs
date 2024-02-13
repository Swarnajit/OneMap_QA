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
            driver = Tests.SetUp(driver);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            communityWebElements = new Community(driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Tests.CloseBrowser(driver);
        }

        [Test]
        public void Verify_Text()
        {
            communityWebElements.CommunityButton.Click();

            Assert.That(communityWebElements.CommunityButton.GetAttribute("class"), Is.EqualTo("essentialTopBtn esOption btnactive"));
        }

        [Test]
        public void Find_Location()
        {
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);

            type(communityWebElements.SearchLocation, searchText, expectedAddress);

            wait.Until(driver => communityWebElements.SearchResult.Count > 0);

            foreach (IWebElement locationAddress in communityWebElements.SearchResult)
            {
                if (locationAddress.Text.Equals(expectedAddress))
                {
                    locationAddress.Click();
                }
            }

            string actualLocationAddress = communityWebElements.LocationInfoBox.FindElements(By.TagName("span"))
                .LastOrDefault().Text;

            Assert.That(actualLocationAddress, Is.EqualTo(expectedAddress), "Location Address not same");
        }

        [Test]
        [TestCase("Marina Bay Skypark", "1 BAYFRONT AVENUE MARINA BAY SANDS SKYPARK SINGAPORE 018971")]
        public void NavigateToLocation(string destination, string destinationAddress)
        {
            string origin = searchText;
            string originAddress = expectedAddress;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            communityWebElements.RouteIcon.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(communityWebElements.OriginLocation));

            type(communityWebElements.OriginLocation, origin, originAddress);

            wait.Until(ExpectedConditions.ElementToBeClickable(communityWebElements.DestinationLocation));

            type(communityWebElements.DestinationLocation, destination, destinationAddress);

            Assert.True(communityWebElements.RouteOptionTransit.GetAttribute("class").Contains("active"),
                "Transit mode was not selected by default");
        }

        #region private methods
        private void type(IWebElement element, string textToType, string addressToFind)
        {
            element.Click();
            element.Clear();

            foreach (char letter in textToType)
            {
                element.SendKeys(letter.ToString());
                Thread.Sleep(5);
            }

            element.SendKeys(Keys.Enter);
        }
        #endregion
    }
}
