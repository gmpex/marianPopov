using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Utils
{
    [Binding]
    public class Hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario,step;

        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReporte = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporte);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if(context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
