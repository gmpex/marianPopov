using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public class DeliverySitesPage : BasePage
    {
        // Delivery Sites page
        private readonly By _deliverySiteNavButton = By.Id("delivery sites-tab");
        private readonly By _roleCostsLink = By.LinkText("Role Costs");

        // Role Costs tab
        private readonly By _addRoleCostButton = By.ClassName("icon-btn-label");

        // Add Role Cost Modal Overlay 
        private readonly By _calendarWidget = By.TagName("mat-datepicker-content");
        private readonly By _jobRoleDropdown = By.XPath("//*[@aria-label='Job Role']");
        private readonly By _startDateField = By.XPath("//*[@placeholder='Start Date']");
        private readonly By _endDateField = By.XPath("//input[@placeholder='End Date']");
        private readonly By _grossCostField = By.XPath("//input[@placeholder='Gross Cost']");
        private readonly By _saveButton = By.XPath("//*[@type='submit']");

        // Job Role Dropdown
        private readonly By _jobRoleSearchField = By.XPath("//input[@aria-label='dropdown search']");
        private readonly By _jobRoleDropdownList = By.CssSelector("mat-option#mat-option-5.mat-option");
        
        // Calendar Widget
        private readonly By _calendarChoosePeriod = By.XPath("//button[@aria-label='Choose month and year']");
        private readonly By _calendarPreviousMonthButton = By.XPath("//button[@aria-label='Previous month']");
        private readonly By _calendarNextMonthButton = By.XPath("//button[@aria-label='Next month']");
        private readonly By _calendarNextYearButton = By.XPath("//button[@aria-label='Next 20 years']");
        private readonly By _calendarPreviousYearButton = By.XPath("//button[@aria-label='Previous 20 years']");
        private readonly By _currentCalendarMonth = By.XPath("//tbody//tr[1]//td[1]");
        private readonly By _currentCalendarDay = By.XPath("//td[@tabindex='0']");

        public DeliverySitesPage(IWebDriver driver)
        {
            DriverUtil.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Delivery Sites
        public void SelectRoleCostSite(String siteName)
        {
            By deliverySiteSelect = By.XPath($"//span[contains(text(), '{siteName}')]");
            ElementToBeClickable(deliverySiteSelect);
        }

        public void ClickDeliverySiteTab()
        {
            ElementToBeClickable(_deliverySiteNavButton);
        }

        public void ClickRoleCostsLink()
        {
            ElementToBeClickable(_roleCostsLink);
        }

        public void ClickAddRoleCostButton()
        {
            ElementToBeClickable(_addRoleCostButton);
        }

        // Add Role Costs
        public void ClickJobRoleDropDown()
        {
            ElementToBeClickable(_jobRoleDropdown);
        }

        public void ClearGrossCost()
        {
            ClearFieldTextBox(_grossCostField);
        }

        public void EnterGrossCost(string grossCost)
        {
            InputText(grossCost, _grossCostField);
        }

        public void ClickSaveButton()
        {
            ElementToBeClickable(_saveButton);
        }

        public bool IsSaveButtonEnabled()
        {
            IWebElement esaveButton = mediumTimeout.Until(ExpectedConditions.ElementIsVisible(_saveButton));

            bool valueForMaxDate = esaveButton.Enabled;

            return valueForMaxDate;
        }

        // Job Role Dropdown
        public void SelectJobRole(String jobRole)
        {
            By selectRole = By.XPath($"//mat-option[@aria-disabled='true']/..//div[@entity_name='{jobRole}']");
            ElementToBeClickable(selectRole);
        }

        public void TypeJobRole(string search)
        {
            InputText(search, _jobRoleSearchField);
        }

        public bool IsJobRobleSearshFieldClickable()
        {
            IWebElement esaveButton = mediumTimeout.Until(ExpectedConditions.ElementToBeClickable(_jobRoleSearchField));
            bool isJobRobleSearsh = esaveButton.Enabled;
            return isJobRobleSearsh;
        }

        public bool IsCursorPointer()
        {
            IWebElement result = mediumTimeout.Until(ExpectedConditions.ElementIsVisible(_jobRoleDropdownList));

            bool isCurorPoint = result.GetCssValue("cursor") == "pointer";
            return isCurorPoint;
        }

        // Calendar Widget
        public void ClickOnTheStartDateField()
        {
            ElementToBeClickable(_startDateField);
        }

        public void ClickOnTheEndDateField()
        {
            ElementToBeClickable(_endDateField);
        }

        public void ClickChooseButton()
        {
            
            ElementToBeClickable(_calendarChoosePeriod);
        }

        public void ClickPreviousMonthButton()
        {
            ElementToBeClickable(_calendarPreviousMonthButton);
        }

        public void ClickNextMonthButtonTimes(int attempts)
        {
            int times = 0;
            while (attempts > times)
            {
                ElementToBeClickable(_calendarNextMonthButton);
                times++;
            }
        }

        public void ClickNextYearButton()
        {
            ElementToBeClickable(_calendarNextYearButton);
        }

        public void ClickPreviousYearButton()
        {
            ElementToBeClickable(_calendarPreviousYearButton);
        }

        public void SelectDate(String ourDate)
        {
            DateTime date = Convert.ToDateTime(ourDate);
            string month = date.ToString("MMM").ToUpper();

            By selectYear = By.XPath($"//div[text()=' {date.Year} ']");
            By selectmonth = By.XPath($"//div[text()=' {month} ']");
            By selectday = By.XPath($"//div[text()=' {date.Day} ']");

            ElementToBeClickable(selectYear);
            ElementToBeClickable(selectmonth);
            ElementToBeClickable(selectday);
        }

        public string GetActualDay()
        {
            string day = DateTime.Now.ToString("dd").ToUpper();
            return day;
        }

        public string GetCalendarWidgetMonth()
        {
            return DriverUtil.GetText(_currentCalendarMonth);
        }

        public string GetCalendarWidgetDay()
        {
            return DriverUtil.GetText(_currentCalendarDay);
        }

        public string GetActualMonth()
        {
            string month = DateTime.Now.ToString("MMM").ToUpper();
            return month;
        }

        public bool IsCalendarWidgetWindowOpened()
        {
            return IsElementVisible(_calendarWidget);
        }
    }
}
