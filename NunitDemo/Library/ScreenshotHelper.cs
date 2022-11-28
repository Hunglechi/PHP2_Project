using AventStack.ExtentReports;
using OpenQA.Selenium;
using NunitDemo.Test;

namespace NunitDemo.Library
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string className, string testName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "Screenshot.Folder"));
            testName = testName.Replace("\"", "");
            var fileName = string.Format(@"Screenshot_{0}_{1}", testName, DateTime.Now.ToString("yyyyMMdd_HHmmssff"));
            Directory.CreateDirectory(screenshotDirectory);
            var fileLocation = string.Format(@"{0}\{1}.png", screenshotDirectory, fileName);
            screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            return fileLocation;
        }

        public static MediaEntityModelProvider CaptureScreenShotAndAttachToExtendReport(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}




