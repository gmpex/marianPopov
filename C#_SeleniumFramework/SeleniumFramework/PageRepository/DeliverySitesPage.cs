using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public class DeliverySitesPage : BasePage
    {
        // Elements the 'Delivery Sites' page
        By deliverySiteTab = By.XPath("//a[@id='delivery sites-tab']");
        By roleCostsLink = By.XPath("//a[@href='/delivery-sites/1/roles-costs']");
        By successfulUpdatedMessage = By.CssSelector(".pp-light .snackBar-success");
        By confirmDeleteRequest = By.XPath("//*[@attr.ui-automation-id='confirmationPopUpYesButton']");
        // Elements the 'Delivery Sites' -> 'Role Costs' tab
        By addRoleCostButton = By.XPath("//span[text()='Add Role Cost']");

        // Elements on the 'Add Role Cost' modal page
        By calendarWidgetWindow = By.XPath("//mat-datepicker-content");
        By dropDownJobRole = By.XPath("//mat-select[@aria-label='Job Role']");
        By startDatePicker = By.XPath("//input[@placeholder='Start Date']");
        By endDatePicker = By.XPath("//input[@placeholder='End Date']");
        By fieldGrossCost = By.XPath("//input[@placeholder='Gross Cost']");
        By saveButton = By.XPath("//button[@type='submit']");
        // Elements on the Add Role Cost modal page -> Job Role field
        By jobRoleDropdownList = By.CssSelector("mat-option#mat-option-5.mat-option");
        By jobRoleSearchField = By.XPath("//input[@aria-label='dropdown search']");
        
        // Elements on the Add Role Costv modal page -> Calendar Widget
        By widgetChooseDate = By.XPath("//button[@aria-label='Choose month and year']");
        By widgetPreviousMonthButton = By.XPath("//button[@aria-label='Previous month']");
        By widgetNextMonthButton = By.XPath("//button[@aria-label='Next month']");
        By widgetNextYearButton = By.XPath("//button[@aria-label='Next 20 years']");
        By currentWidgetMonth = By.XPath("//tbody//tr[1]//td[1]");
        By currentWidgetDay = By.XPath("//td[@tabindex='0']");
        

        public void ConfirmDeleteRequest()
        {
            ElementToBeClickable(confirmDeleteRequest);
        }

        public void TypeJobRole(string search)
        {
            InputText(search, jobRoleSearchField);
        }

        public bool IsJobRobleSearshFieldClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            IWebElement esaveButton = wait.Until(ExpectedConditions.ElementToBeClickable(jobRoleSearchField));
            bool isJobRobleSearsh = esaveButton.Enabled;
            return isJobRobleSearsh;
        }

        public bool IsGreenTextColor()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            IWebElement esaveButton = wait.Until(ExpectedConditions.ElementIsVisible(successfulUpdatedMessage));

            bool isJobRobleSearsh = esaveButton.GetCssValue("color") == ("rgba(144, 238, 144, 1)");
            return isJobRobleSearsh;
        }

        public bool IsSaveButtonEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            IWebElement esaveButton = wait.Until(ExpectedConditions.ElementIsVisible(saveButton));

            bool valueForMaxDate = esaveButton.Enabled;

            return valueForMaxDate;
        }

        public bool IsCursorPointer()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.explicitWaitTime));
            IWebElement result = wait.Until(ExpectedConditions.ElementIsVisible(jobRoleDropdownList));

            bool isCurorPoint = result.GetCssValue("cursor") == "pointer";
            return isCurorPoint;
        }

        public void ClickPreviousMonthButton()
        {
            ElementToBeClickable(widgetPreviousMonthButton);
        }

        public void ClickNextMonthButtonTimes(int attempts)
        {
            int times = 0;
            while (attempts > times)
            {
                ElementToBeClickable(widgetNextMonthButton);
                times++;
            }
        }

        public void ClickNextYearButton()
        {
            ElementToBeClickable(widgetNextYearButton);
        }

        public string GetCalendarWidgetMonth()
        {
            return DriverUtil.GetText(currentWidgetMonth);
        }

        public string GetCalendarWidgetDay()
        {
            return DriverUtil.GetText(currentWidgetDay);
        }

        public string GetActualMonth()
        {
            string month = DateTime.Now.ToString("MMM").ToUpper();
            return month;
        }

        public string GetActualDay()
        {
            string day = DateTime.Now.ToString("dd").ToUpper();
            return day;
        }

        public DeliverySitesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsCalendarWidgetWindowOpened()
        {
            return IsElementVisible(calendarWidgetWindow);
        }

        public bool IsJobRoleDropdownOpen()
        {
            return IsElementVisible(calendarWidgetWindow);
        }

        public void ClickDeliverySiteTab()
        {
            ElementToBeClickable(deliverySiteTab);
        }

        public void ClickRoleCostsLink()
        {
            ElementToBeClickable(roleCostsLink);
        }

        public void ClickAddRoleCostButton()
        {
            ElementToBeClickable(addRoleCostButton);
        }

        public void ClickJobRoleDropDown()
        {
            ElementToBeClickable(dropDownJobRole);
        }

        public void ClickOnTheStartDateField()
        {
            ElementToBeClickable(startDatePicker);
        }

        public void ClickOnTheEndDateField()
        {
            ElementToBeClickable(endDatePicker);
        }

        public void ClickChooseButton()
        {
            
            ElementToBeClickable(widgetChooseDate);
        }

        public void ClearGrossCost()
        {
            ClearFieldTextBox(fieldGrossCost);
        }

        public void EnterGrossCost(string grossCost)
        {
            InputText(grossCost, fieldGrossCost);
        }

        public void ClickSaveButton()
        {
            ElementToBeClickable(saveButton);
        }

        public string ConvertMonthNumberToMonthName(string month)
        {
            switch (month)
            {
                case "1":
                    month = "JAN";
                    break;
                case "2":
                    month = "FEB";
                    break;
                case "3":
                    month = "MAR";
                    break;
                case "4":
                    month = "APR";
                    break;
                case "5":
                    month = "MAY";
                    break;
                case "6":
                    month = "JUN";
                    break;
                case "7":
                    month = "JUL";
                    break;
                case "8":
                    month = "AUG";
                    break;
                case "9":
                    month = "SEP";
                    break;
                case "10":
                    month = "OCT";
                    break;
                case "11":
                    month = "NOV";
                    break;
                case "12":
                    month = "DEC";
                    break;
            }

            return month;
        }
    }
}
