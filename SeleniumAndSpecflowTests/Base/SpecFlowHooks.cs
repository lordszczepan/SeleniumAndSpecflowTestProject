using OpenQA.Selenium;
using SeleniumAndSpecflowTests.JsonSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            step = scenario;
        }

        [AfterStep]
        public static void TearDownReportStep(ScenarioContext context)
        {
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
