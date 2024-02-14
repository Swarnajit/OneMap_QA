using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UiAutomation.Setup;
using UiAutomation.Setup.EssentialButtons;

namespace UiAutomation.Tests
{
    [TestFixture]
    [Parallelizable]
    public class BasePageTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private BasePage basePageWebElements;

        [SetUp]
        public void SetUp()
        {
            driver = Tests.SetUp();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            basePageWebElements = new BasePage(driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Tests.CloseBrowser();
        }

        [Test]
        public void Validate_WebsiteBanner()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AssertScreenshot.AreEqual("A Singapore Government Agency Website",
                basePageWebElements.GovBanner.Text);
        }

        [Test]
        [TestCase("Marina Bay")]
        public void Location_FindCommunity_InvalidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);

            basePageWebElements.CommunityButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(basePageWebElements.NoResultFoundPopUp));

            Assert.Multiple(() =>
            {
                AssertScreenshot.IsNotNull(basePageWebElements.NoResultFoundPopUp);

                AssertScreenshot.AreEqual("No results found. Please to another area.",
                    basePageWebElements.NoResultFoundTextArea.Text);
            });
            basePageWebElements.NoResultFoundPopUp.FindElement(By.TagName("button")).Click();
        }

        [Test]
        [TestCase("Chinatown")]
        public void Location_FindCommunity_ValidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.False(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);
            basePageWebElements.CommunityButton.Click();
            Assert.True(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
        }

        [Test]
        [TestCase("Marina Bay")]
        public void Location_FindHawkerCentre_InvalidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);

            basePageWebElements.CommunityButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(basePageWebElements.NoResultFoundPopUp));

            Assert.Multiple(() =>
            {
                AssertScreenshot.IsNotNull(basePageWebElements.NoResultFoundPopUp);

                AssertScreenshot.AreEqual("No results found. Please shift to another area.",
                    basePageWebElements.NoResultFoundTextArea.Text);
            });
            basePageWebElements.NoResultFoundPopUp.FindElement(By.TagName("button")).Click();
        }

        [Test]
        [TestCase("Chinatown")]
        public void Location_FindHawkerCentre_ValidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.False(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);
            basePageWebElements.CommunityButton.Click();
            Assert.True(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
        }

        [Test]
        [TestCase("Marina Bay")]
        public void Location_FindMedical_InvalidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);

            basePageWebElements.CommunityButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(basePageWebElements.NoResultFoundPopUp));

            Assert.Multiple(() =>
            {
                AssertScreenshot.IsNotNull(basePageWebElements.NoResultFoundPopUp);

                AssertScreenshot.AreEqual("No results found. Please shift to another area.",
                    basePageWebElements.NoResultFoundTextArea.Text);
            });
            basePageWebElements.NoResultFoundPopUp.FindElement(By.TagName("button")).Click();
        }

        [Test]
        [TestCase("Chinatown")]
        public void Location_FindMedical_ValidLocation(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.False(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);
            basePageWebElements.CommunityButton.Click();
            Assert.True(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
        }

        [Test]
        [TestCase("Chinatown")]
        public void Location_FindSchool(string searchText)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.False(basePageWebElements.CommunityButton.GetAttribute("class").Contains("btnactive"));
            SharedMethods.typeInSearch(basePageWebElements.SearchLocation, searchText);
            basePageWebElements.SchoolQueryButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(basePageWebElements.SchoolBlock));

            Assert.Multiple(() =>
            {
                Assert.True(basePageWebElements.SchoolBlock.Displayed,
                    $"{basePageWebElements.SchoolBlock} is displayed");

                Assert.True(basePageWebElements.KindergartenSchool.Displayed,
                    $"{basePageWebElements.KindergartenSchool} is displayed");

                Assert.True(basePageWebElements.PrimarySchool.Displayed,
                    $"{basePageWebElements.PrimarySchool} is displayed");

                Assert.True(basePageWebElements.SecondarySchool.Displayed,
                    $"{basePageWebElements.SecondarySchool} is displayed");

                Assert.True(basePageWebElements.PostSecondarySchool.Displayed,
                    $"{basePageWebElements.PostSecondarySchool} is displayed");

                Assert.True(basePageWebElements.SchoolQueryButton.GetAttribute("class").Contains("btnactive"));
            });


        }
    }
}