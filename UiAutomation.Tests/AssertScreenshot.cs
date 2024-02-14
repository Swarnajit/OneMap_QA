using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;

namespace UiAutomation.Tests
{
    public class AssertScreenshot
    {
        private static string Screenshot()
        {
            // Take a screenshot
            Screenshot screenshot = ((ITakesScreenshot)Tests.driver).GetScreenshot();

            // Generate a timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Save the screenshot with timestamp in the filename
            string screenshotFilePath = $"screenshot_{timestamp}.png";
            screenshot.SaveAsFile(screenshotFilePath);

            Console.WriteLine("Screenshot saved to: " + screenshotFilePath);
            return screenshotFilePath;
        }

        public static void AreEqual(string expected, string actual)
        {
            try
            {
                if (!actual.Equals(expected))
                {
                    throw new AssertionException($"Expected result '{expected}' and actual result '{actual}' did not match");
                }
            }
            catch(AssertionException ae) 
            {
                Console.WriteLine(ae.Message + " " + Screenshot());
            }
        }

        public static void IsNotNull(IWebElement elementUnderTest)
        {
            try
            {
                if (elementUnderTest==null)
                {
                    throw new NoSuchElementException($"'{elementUnderTest}' was not found");
                }
            }
            catch (NoSuchElementException nse)
            {
                Console.WriteLine(nse.Message + " " + Screenshot());
            }
        }
    }
}