using Microsoft.VisualBasic.FileIO;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.Autofill;
using OpenQA.Selenium.DevTools.V121.FedCm;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiAutomation.Setup;
using UiAutomation.Setup.EssentialButtons;

namespace UiAutomation.Tests.EssentialButtonTests
{
    public class CommunityTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Community communityWebElements;

        private const string searchText = "Chinatown";
        private const string expectedAddress = "46 PAGODA STREET CHINATOWN HERITAGE CENTRE SINGAPORE 059205";

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
        public void Find_Community_Location()
        {
            communityWebElements.SearchLocation.SendKeys(searchText);

            Thread.Sleep(3000);

            wait.Until(driver => communityWebElements.SearchResult.Count > 0);

            foreach(IWebElement locationAddress in communityWebElements.SearchResult)
            {
                if(locationAddress.Text.Equals(expectedAddress))
                {
                    locationAddress.Click();
                }
            }

            string actualLocationAddress = communityWebElements.LocationInfoBox.FindElements(By.TagName("span"))
                .LastOrDefault().Text;

            Assert.That(actualLocationAddress, 
                Is.EqualTo(expectedAddress));
        }
    }
}
