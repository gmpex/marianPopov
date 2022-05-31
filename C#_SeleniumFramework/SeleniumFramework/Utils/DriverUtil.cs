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
        public static IWebDriver driver;
        protected static string browser = Config.browser;
        protected WebDriverWait shortTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.ShortTimeout));
        protected WebDriverWait mediumTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.MediumTimeout));
        protected WebDriverWait longTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.LongTimeout));


        public static void LaunchBrowser()
        {
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
            }
            catch (NoSuchWindowException)
            {
            }
        }

        /* This method will be kill all background process chromedriver.exe
         * If at least 1 time will run test without driver.quit, chromedriver.exe will be stay in background process till restart PC or kill process manually.
         */
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

        public static void TakeScreenshot()
        {
            String fp = "Screenshot" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_tt") + ".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $@"C:\Screenshots";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Save screenshot name Screenshot_yyyy_MM_dd_hh_mm_ss_tt in png format.
                ss.SaveAsFile($@"C:\Screenshots\{fp}", ScreenshotImageFormat.Png);
            }
        }

        public static string GetText(By locator)
        {
            WebDriverWait mediumTimeout = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.MediumTimeout));
            IWebElement text = mediumTimeout.Until(ExpectedConditions.ElementIsVisible(locator));

            if (text.Displayed)
            {
                try
                {
                    string txtValue = driver.FindElement(locator).Text;
                    return txtValue;

                }
                catch (ElementNotVisibleException e)
                {
                    return e.ToString();
                }
            } 
            else
            {
                return null;
            }
                
        }
    }
}
