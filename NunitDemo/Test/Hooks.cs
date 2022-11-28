using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NunitDemo.Library;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NunitDemo.Test
{
    [SetUpFixture]
    public class Hooks
    {
        public static IConfiguration Config;
        static string configPath = "Configurations\\appsettings.json";

        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void MySetup()
        {
            TestContext.Progress.WriteLine("=================>Global OneTimeSetUp");
            Config = ConfigurationHelper.ReadConfiguration(configPath);
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var actualPath = dir.Substring(0, dir.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var reportPath = projectPath + ConfigurationHelper.GetConfigurationByKey(Config, "TestResult.FilePath");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Host Name", "Demo Test");
            Extent.AddSystemInfo("Environment", "Test Environment");
            Extent.AddSystemInfo("Test Suite", "Demo");
        }

        [OneTimeTearDown]
        public void MyTeardown()
        {
            TestContext.Progress.WriteLine("=================>Global OneTimeTearDown");
            Extent.Flush();
        }
    }
}