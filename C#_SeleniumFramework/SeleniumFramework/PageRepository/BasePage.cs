using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public class BasePage
    {
        public IWebDriver driver;

        public void ElementToBeClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        public void ElementToBeClickable(By locator, int attempt)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));

            int times = 0;
            while (attempt > times)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
                times++;
            }
        }

        public void ClearFieldTextBox(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Clear();
        }

        public bool IsElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));

            if(wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InputText(String inputText, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            wait.Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(inputText);
        }
    }
}
