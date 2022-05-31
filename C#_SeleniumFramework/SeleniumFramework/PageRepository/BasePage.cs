using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public class BasePage : DriverUtil
    {
        private readonly By _confirmDeleteRequest = By.XPath("//button[@attr.ui-automation-id='confirmationPopUpYesButton']");
        private readonly By _successfulUpdatedMessage = By.CssSelector(".pp-light .snackBar-success");

        public void ElementToBeClickable(By locator)
        {
            try
            {
                mediumTimeout.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
            }
            catch (ElementNotSelectableException e) { }
            
        }

        public void ElementToBeClickable(By locator, int tries)
        {
            try
            {
                int attempt = 0;
                while (tries > attempt)
                {
                    shortTimeout.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
                    attempt++;
                }
            }
            catch (ElementNotSelectableException e) { }
            
        }

        public void ClearFieldTextBox(By locator)
        {
            try
            {
                shortTimeout.Until(ExpectedConditions.ElementToBeClickable(locator)).Clear();
            }
            catch (ElementNotSelectableException e) { }
            
        }

        public bool IsElementVisible(By locator)
        {
            try
            {
                bool element = DriverUtil.driver.FindElement(locator).Displayed;
                //shortTimeout.Until(ExpectedConditions.ElementIsVisible(locator));
                return element;
            }
            catch (ElementNotVisibleException e)
            {
                return false;
            }
        }

        public void InputText(String inputText, By locator)
        {
            try
            {
                shortTimeout.Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(inputText);
            }
            catch (ElementNotVisibleException e) { }
        }

        public void ConfirmDeleteRequest()
        {
            try
            {
                ElementToBeClickable(_confirmDeleteRequest);
            }
            catch (ElementNotSelectableException e) { }
            
        }

        public bool IsGreenTextColor()
        {
            try
            {
                IWebElement succefullMessageTable = mediumTimeout.Until(ExpectedConditions.ElementIsVisible(_successfulUpdatedMessage));

                bool isGreenTextColor = succefullMessageTable.GetCssValue("color") == ("rgba(144, 238, 144, 1)");
                return isGreenTextColor;
            }
            catch (NoSuchElementException e) 
            {
                return false;
            }
            
        }
    }
}
