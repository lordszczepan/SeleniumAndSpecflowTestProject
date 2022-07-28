using TechTalk.SpecFlow;
using System.IO;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using SeleniumAndSpecflowTests.Extensions;

namespace SeleniumAndSpecflowTests.Base
{
    [Binding]
    public class SpecFlowHooks : TestsBase
    {

        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentTest step;

        public SpecFlowHooks(TestsSettings settings) : base(settings)
        {
        }

        [BeforeTestRun]
        public static void SetUpReport()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("C:\\Reports\\SpecflowTests.html");

            var path = new FilePath();
            string configPath = path.ReturnCombinedFilePathFromCurrentDirectory("extent-config.xml");
            htmlReporter.LoadConfig(configPath);
            
            htmlReporter.Config.ReportName = "SpecflowTests";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterScenario]
        public static void AfterFeature()
        {
            extent.Flush();
        }


        [BeforeFeature]
        public static void SetUpReportFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void SetUpReportScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public static void SetUpReportStep()
        {
            TearDownRemoveAllScreenshots();
            step = scenario;
        }

        [AfterStep]
        public static void TearDownReportStep(ScenarioContext context)
        {
            var stepType = context.StepContext.StepInfo.StepDefinitionType.ToString();
            
            TakeScreenshot();

            ExtentTest node = null;

            if (context.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        node = scenario.CreateNode<Given>($"Given: {ScenarioStepContext.Current.StepInfo.Text}");
                        break;
                    case "When":
                        node = scenario.CreateNode<When>($"When: {ScenarioStepContext.Current.StepInfo.Text}");
                        break;
                    case "Then":
                        node = scenario.CreateNode<Then>($"Then: {ScenarioStepContext.Current.StepInfo.Text}");
                        break;
                    case "And":
                        node = scenario.CreateNode<And>($"And: {ScenarioStepContext.Current.StepInfo.Text}");
                        break;
                }
            }
            else if (context.TestError != null)
            {
                switch (stepType)
                {
                    case "Given":
                        node = scenario.CreateNode<Given>($"Given: {ScenarioStepContext.Current.StepInfo.Text}").Fail(context.TestError.InnerException);
                        break;
                    case "When":
                        node = scenario.CreateNode<When>($"When: {ScenarioStepContext.Current.StepInfo.Text}").Fail(context.TestError.InnerException);
                        break;
                    case "Then":
                        node = scenario.CreateNode<Then>($"Then: {ScenarioStepContext.Current.StepInfo.Text}").Fail(context.TestError.InnerException);
                        break;
                    case "And":
                        node = scenario.CreateNode<And>($"And: {ScenarioStepContext.Current.StepInfo.Text}").Fail(context.TestError.InnerException);
                        break;
                }
            }

            string screenshotPath = $@"C:\Screenshots\";

            if (Directory.Exists(screenshotPath))
            {
                var screenshots = new DirectoryInfo(screenshotPath).GetFiles();

                if (screenshots.Length != 0)
                {
                    foreach (FileInfo screenshot in screenshots)
                    {
                        node.Pass("Screenshot ", MediaEntityBuilder.CreateScreenCaptureFromPath($@"{screenshotPath}{screenshot.FullName}").Build());
                    }
                }
            }

            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }
    }
}
