using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public class HomePage : BasePage
    {
        // Elements on the Home Page
        By loginButton = By.XPath("//div[@class='button']//span");

        public HomePage(IWebDriver driver)
        {
            DriverUtil.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickLoginButton()
        {
            ElementToBeClickable(loginButton);
        }
    }
}
