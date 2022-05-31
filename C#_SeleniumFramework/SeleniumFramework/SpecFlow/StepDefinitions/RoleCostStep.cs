using TechTalk.SpecFlow;
using SeleniumFramework.Utils;
using SeleniumFramework.PageRepository;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumFramework
{
    [Binding]
    public class RoleCostStep
    {
        //-------------------------------------------------------------------
        // Run before executing each scenario or scenario outline.
        //-------------------------------------------------------------------
        [BeforeScenario]
        public static void Setup()
        {
            DriverUtil.LaunchBrowser();
        }

        //-------------------------------------------------------------------
        // Run after executing each scenario or scenario outline.
        //-------------------------------------------------------------------
        [AfterScenario]
        public static void Teardown()
        {
            DriverUtil.Teardown();
        }

        //-------------------------------------------------------------------
        // Steps for loggin in the system like Administrator user and
        // Navigate to company Role Costs page.
        //-------------------------------------------------------------------
        [Given(@"Admin user is on '(.*)' Role Costs page")]
        public void GivenAdminUserIsLogged(String siteName)
        {
            DriverUtil.NavigateToURL(Config.baseUrl);
            NavigateTo.homePage.ClickLoginButton();

            NavigateTo.loginPage.EnterEmail("automation.pp@amdaris.com");
            NavigateTo.loginPage.ClickNextButton();

            NavigateTo.loginPage.EnterPassword("10704-observe-MODERN-products-STRAIGHT-69112");
            NavigateTo.loginPage.ClickNextButton();

            NavigateTo.loginPage.ClickDeclineButton();

            NavigateTo.deliverySitesPage.ClickDeliverySiteTab();
            NavigateTo.deliverySitesPage.SelectRoleCostSite(siteName);
            NavigateTo.deliverySitesPage.ClickRoleCostsLink();
        }

        //-------------------------------------------------------------------
        // 01.Add Role Cost using Valid data.
        //-------------------------------------------------------------------
        [When(@"Add Role Cost using valid data (.*), (.*), (.*) and (.*) fields")]
        public void WhenAddValidJobRoleCost(String jobRole, String startDate, String endDate, String grossCost)
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();

            NavigateTo.deliverySitesPage.ClickJobRoleDropDown();
            NavigateTo.deliverySitesPage.SelectJobRole(jobRole);

            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
            NavigateTo.deliverySitesPage.ClickChooseButton();
            NavigateTo.deliverySitesPage.SelectDate(startDate);

            NavigateTo.deliverySitesPage.ClickOnTheEndDateField();
            NavigateTo.deliverySitesPage.ClickChooseButton();
            NavigateTo.deliverySitesPage.SelectDate(endDate);


            NavigateTo.deliverySitesPage.EnterGrossCost(grossCost);
            NavigateTo.deliverySitesPage.ClickSaveButton();
        }

        [Then(@"Successful created message (.*) is shown")]
        public void ThenSuccessfulMessageIsShown(String message)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));
            Assert.AreEqual(message, actualResult);
        }

        //-------------------------------------------------------------------
        // 02.Succefully Edit Role Cost.
        //-------------------------------------------------------------------
        [When(@"Changed Gross Cost for '(.*)' Job Role")]
        public void WhenChangedGrossCostToGrossCost(String jobRole)
        {
            By editButton = By.XPath($"//span[text()='{jobRole}']/../..//i[@mattooltip='Edit']");
            NavigateTo.deliverySitesPage.ElementToBeClickable(editButton);

            NavigateTo.deliverySitesPage.ClearGrossCost();
            NavigateTo.deliverySitesPage.EnterGrossCost("8000");
            NavigateTo.deliverySitesPage.ClickSaveButton();
        }

        [Then(@"Successful updated green message '(.*)' is shown")]
        public void ThenSuccessfulUpdatedGreenMessageIsShown(string expectedResult)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsGreenTextColor());
        }

        //-------------------------------------------------------------------
        // 03.Succefully Delete Role Cost.
        //-------------------------------------------------------------------
        [When(@"Delete '(.*)' Job Role")]
        public void GivenDeleteJobRole(string jobRoleName)
        {
            By deleteButton = By.XPath($"//span[text()='{jobRoleName}']/../..//i[@mattooltip='Delete']");
            NavigateTo.deliverySitesPage.ElementToBeClickable(deleteButton);
            NavigateTo.deliverySitesPage.ConfirmDeleteRequest();
        }

        [Then(@"Successful deleted message '(.*)' is shown")]
        public void ThenSuccessfulDeletedMessageIsShown(string expectedResult)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsGreenTextColor());
        }

        //-------------------------------------------------------------------
        // Check if Save button id disabled when required fields for 
        // Add new role cost is not filled.
        //-------------------------------------------------------------------
        [When(@"Leave all field by default for Add new role cost")]
        public void WhenLeaveAllFieldByDefaultForAddNewRoleCost()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
        }

        [Then(@"Save button should be disabled")]
        public void ThenSaveButtonShouldBeDisabled()
        {
            Assert.IsFalse(NavigateTo.deliverySitesPage.IsSaveButtonEnabled());
        }

        //-------------------------------------------------------------------
        // Hover mouse pointer should be change from a pointer to hand.
        //-------------------------------------------------------------------
        [When(@"Hover mouse on the Job Role Dropdown")]
        public void WhenHoverMouseOnTheJobRoleDropdown()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickJobRoleDropDown();
        }

        [Then(@"Mouse hover mouse pointer changed from a pointer to hand")]
        public void ThenMouseHoverMousePointerChanged()
        {
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsCursorPointer());
        }

        //-------------------------------------------------------------------
        // Search box field for Job Role Dropdown should be clickable.
        //-------------------------------------------------------------------
        [When(@"Job Role dropdown is shown")]
        public void WhenJobRoleDropdownIsShown()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickJobRoleDropDown();
        }

        [Then(@"Search box field is clickable")]
        public void ThenSearchBoxFieldIsClickable()
        {
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsJobRobleSearshFieldClickable());
        }

        //-------------------------------------------------------------------
        // Selected Value from the search list should be the same with value 
        // for Job Role field.
        //-------------------------------------------------------------------
        [When(@"When Entered (.*) text in search box field and selected it")]
        public void WhenWhenEnteredJobRoleTextInSearchBoxFieldAndSelectedIt(String jobRoleName)
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickJobRoleDropDown();

            NavigateTo.deliverySitesPage.TypeJobRole(jobRoleName);

            By searchResul = By.XPath($"//mat-option[@aria-disabled='false']//span[text()='{jobRoleName}']");
            NavigateTo.deliverySitesPage.ElementToBeClickable(searchResul);
        }

        [Then(@"For Job Role field should be selected (.*)")]
        public void ThenForJobRoleFieldShouldBeSelected(String expectedJobRoleName)
        {
            By searchResul = By.XPath($"//mat-option[@aria-disabled='false']//span[text()='{expectedJobRoleName}']");
            string actualJobRoleName = DriverUtil.GetText(searchResul);

            Assert.AreEqual(expectedJobRoleName, actualJobRoleName);
        }

        //-------------------------------------------------------------------
        // Clicking the date field, a calendar widget should open
        //-------------------------------------------------------------------
        [When(@"Start date field is clicked")]
        public void WhenClickingOnTheStartDateField()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
        }

        [Then(@"Calendar widget is shown")]
        public void ThenIShouldSeeCalendarWidget()
        {
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsCalendarWidgetWindowOpened());
        }

        //-------------------------------------------------------------------
        // By default the current month and day calendar should be displayed
        //-------------------------------------------------------------------
        [When(@"Datepicker is opened")]
        public void WhenDatepickerIsOpened()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
        }

        [Then(@"Current month and day is shown by Default")]
        public void ThenCurrentMonthAndDayIsShown()
        {
            string expectedMonthResult = NavigateTo.deliverySitesPage.GetActualMonth();
            string expectedDayResult = NavigateTo.deliverySitesPage.GetActualDay();

            string actualMonthResult = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            string actualDayResult = NavigateTo.deliverySitesPage.GetCalendarWidgetDay();

            Assert.AreEqual(expectedMonthResult, actualMonthResult);
            Assert.AreEqual(expectedDayResult, actualDayResult);
        }

        //-------------------------------------------------------------------
        // User can move to previous and next month’s calendar by choosing
        // the left and right icon over the calendar.
        //-------------------------------------------------------------------
        [When(@"Start datepicker is opened")]
        public void WhenStartDatepicherOpened()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
        }

        [Then(@"Previous and next month calendar button it's work")]
        public void ThenPreviosAndNextMonthsCalendarItsWorked()
        {
            string defaultPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();

            //Previous button Test
            NavigateTo.deliverySitesPage.ClickPreviousMonthButton();
            string previousPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            Assert.AreNotEqual(previousPageWigetMonth, defaultPageWigetMonth);

            //Next button Test
            NavigateTo.deliverySitesPage.ClickNextMonthButtonTimes(2);
            string nextPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            Assert.AreNotEqual(nextPageWigetMonth, defaultPageWigetMonth);
        }

        //-------------------------------------------------------------------
        // User can move to previous and next month’s calendar by choosing
        // the left and right icon over the calendar.
        //-------------------------------------------------------------------
        [When(@"Open Start Datepicker")]
        public void WhenOpenStartDatepicker()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
            NavigateTo.deliverySitesPage.ClickChooseButton();
        }

        [Then(@"The last possible date is selected")]
        public void ThenTheLastPossibleDateIsSelected()
        {
            WebElement startDatefield = (WebElement)DriverUtil.driver.FindElement(By.XPath("//input[@placeholder='Start Date']"));
            string valueForMaxDate = startDatefield.GetAttribute("max");

            DateTime date = Convert.ToDateTime(valueForMaxDate);
            string maxMonth = date.ToString("MMM").ToUpper();

            By selectYar = By.XPath($"//div[text()=' {date.Year} ']");
            By selectmonth = By.XPath($"//div[text()=' {maxMonth} ']");
            By selectday = By.XPath($"//div[text()=' {date.Day} ']");

            // The last element from parrent class tbody
            By lastYearLocation = By.XPath("//tbody/descendant::*[last()]");
            bool elementIsNotFound = true;

            while (elementIsNotFound)
            {
                if (DriverUtil.GetText(lastYearLocation).Equals($"{date.Year}"))
                {
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectYar);
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectmonth);
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectday);
                    elementIsNotFound = false;
                }
                else
                {
                    NavigateTo.deliverySitesPage.ClickNextYearButton();
                }
            }
        }
    }
}
