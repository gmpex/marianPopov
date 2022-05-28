using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFramework.Utils
{
    public class DriverUtil
    {
        public static string browser = Config.browser;

        public static IWebDriver driver;
        
        public static void LaunchBrowser()
        {
            //Get browser name from the Config.cs
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    ImplicitWait();

                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    ImplicitWait();

                    break;
            }
        }

        static public void Teardown()
        {

            try
            {
                driver.Quit();
                //KillChromeSessions();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
            }
        }

        //This method will be kill all background process chromedriver.exe
        //If at least 1 time will run test without driver.quit, chromedriver.exe will be stay forever in background process 
        public static void KillBackgroundProcessChromeDriver()
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "cmd.exe";
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;
                process.StartInfo = info;
                process.Start();
                // We start StreamWriter to add CMD lines instead of user input.
                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        // Kill all chromedriver background process
                        sw.WriteLine(@"taskkill /im chromedriver.exe /f");
                    }
                }
            }
            catch (IOException) { }
        }
        static public void KillChromeSessions()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(Config.browser))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not kill all chrome process\r\n" + ex);
            }
        }

        static public void NavigateToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.implicitWaitTime);
        }

        public static string GetText(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            IWebElement text = wait.Until(ExpectedConditions.ElementIsVisible(locator));

            if (text.Displayed)
            {
                string txtValue = driver.FindElement(locator).Text;
                return txtValue;
            }

            return "TEXT NOT FOUND";
        }

        static public void TakeScreenshot()
        {
            String fp = "Screenshot" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_tt") + ".png";

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($@"C:\screen\{fp}", ScreenshotImageFormat.Png);
        }
    }
}
