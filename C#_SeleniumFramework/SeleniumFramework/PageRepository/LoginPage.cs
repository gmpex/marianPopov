using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumFramework.PageRepository
{
    public class LoginPage : BasePage
    {
        // Elements on the Home Page
        By emailField = By.XPath("//input[@type='email']");
        By passwordField = By.XPath("//input[@type='password']");
        By nextButton = By.XPath("//input[@type='submit']");
        By declineButton = By.XPath("//input[@id='idBtn_Back']");

       
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterEmail(string email)
        {
            InputText(email, emailField);
        }

        public void EnterPassword(string password)
        {
            InputText(password, passwordField);
        }

        public void ClickNextButton()
        {
            ElementToBeClickable(nextButton);
        }

        public void ClickDeclineButton()
        {
            ElementToBeClickable(declineButton);
        }
    }
}
