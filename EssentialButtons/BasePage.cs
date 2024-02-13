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
    public class BasePage : DriverSetup
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver) : base(driver)
        {
            DriverSetup webDriverManager = new DriverSetup(driver);
            _driver = webDriverManager.GetDriver(); // Get the WebDriver instance
        }

        public IWebElement GovBanner => _driver.FindElement(By.XPath("//div[@id='view-banner-gov-sg']//descendant::span[2]"));
        public IWebElement SearchLocation => _driver.FindElement(By.Id("search_property"));
        public IWebElement CommunityButton => _driver.FindElement(By.Id("Community"));
        public IWebElement SchoolQueryButton => _driver.FindElement(By.Id("SchoolQueryInfo"));
        public IWebElement MedicalButton => _driver.FindElement(By.Id("Medical"));
        public IWebElement HawkersCenterButton => _driver.FindElement(By.Id("HawkerCentres"));
        public IWebElement NoResultFoundPopUp => _driver.FindElement(By.ClassName("popup-modal-content"));
        public IWebElement NoResultFoundTextArea => _driver.FindElement(By.ClassName("popup-modal-text"));
        public IWebElement KindergartenSchool => _driver.FindElement(By.Id("kindergarten"));
        public IWebElement PrimarySchool => _driver.FindElement(By.Id("priSchool"));
        public IWebElement SecondarySchool => _driver.FindElement(By.Id("secSchool"));
        public IWebElement PostSecondarySchool => _driver.FindElement(By.Id("postSecSchool"));
        public IWebElement SchoolBlock => _driver.FindElement(By.Id("schoolQuerySelectBlock"));
    }
}
