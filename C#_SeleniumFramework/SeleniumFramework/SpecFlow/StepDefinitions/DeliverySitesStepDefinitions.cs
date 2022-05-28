using TechTalk.SpecFlow;
using SeleniumFramework.Utils;
using SeleniumFramework.PageRepository;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumFramework
{
    [Binding]
    public class DeliverySitesStepDefinitions
    {
        [BeforeScenario]
        static public void Setup()
        {
            DriverUtil.LaunchBrowser();
        }

        [AfterScenario]
        static public void TearDown()
        {
            DriverUtil.Teardown();
        }

        [Given(@"I logged by Admin User")]
        public void GivenILoggedByAdminUser()
        {
            DriverUtil.NavigateToURL(Config.baseUrl);
            NavigateTo.homePage.ClickLoginButton();

            NavigateTo.loginPage.EnterEmail("automation.pp@amdaris.com");
            NavigateTo.loginPage.ClickNextButton();

            NavigateTo.loginPage.EnterPassword("10704-observe-MODERN-products-STRAIGHT-69112");
            NavigateTo.loginPage.ClickNextButton();

            NavigateTo.loginPage.ClickDeclineButton();
        }

        [When(@"I click on the Delivery Sites tab")]
        public void WhenIClickOnTheDeliverySitesTab()
        {
            NavigateTo.deliverySitesPage.ClickDeliverySiteTab();
        }

        [When(@"I click on the '([^']*)' site")]
        public void WhenIClickOnTheSite(string p0)
        {
            By deliverySiteSelect = By.XPath($"//span[contains(text(), '{p0}')]");

            NavigateTo.deliverySitesPage.ElementToBeClickable(deliverySiteSelect);
        }

        [When(@"I click on the Role Costs link")]
        public void WhenIClickOnTheRoleCostsLink()
        {
            NavigateTo.deliverySitesPage.ClickRoleCostsLink();
        }

        [When(@"I click on the Add Role Cost button")]
        public void WhenIClickOnTheButton()
        {
            NavigateTo.deliverySitesPage.ClickAddRoleCostButton();
        }

        [When(@"I click on the Start Date field")]
        public void WhenIClickOnTheStartDateField()
        {
            NavigateTo.deliverySitesPage.ClickOnTheStartDateField();
        }

        [When(@"I click on the End Date field")]
        public void WhenIClickOnTheEndDateField()
        {
            NavigateTo.deliverySitesPage.ClickOnTheEndDateField();
        }

        [When(@"I click on the Choose Date button")]
        public void WhenIClickOnTheChooseDateButton()
        {
            NavigateTo.deliverySitesPage.ClickChooseButton();
        }

        [When(@"I click on the Job Role field")]
        public void WhenIClickOnTheJobRoleField()
        {
            NavigateTo.deliverySitesPage.ClickJobRoleDropDown();
        }

        [When(@"I select <JobRole>")]
        public void WhenISelectJobRole(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            By selectRole = By.XPath($"//mat-option[@aria-disabled='true']/..//div[@entity_name='{data.JobRole}']");

            NavigateTo.deliverySitesPage.ElementToBeClickable(selectRole);
        }

        [When(@"I select <StartDate>")]
        public void WhenISelectStartDate(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            
            string startDate = data.StartDate;
            string day = startDate.Split("/")[0];
            string month = startDate.Split("/")[1];
            string yar = startDate.Split("/")[2];

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

            By selectYar = By.XPath($"//div[text()=' {yar} ']");
            By selectmonth = By.XPath($"//div[text()=' {month} ']");
            By selectday = By.XPath($"//div[text()=' {day} ']");

            NavigateTo.deliverySitesPage.ElementToBeClickable(selectYar);
            NavigateTo.deliverySitesPage.ElementToBeClickable(selectmonth);
            NavigateTo.deliverySitesPage.ElementToBeClickable(selectday);
        }
        
        [When(@"I search <JobRole> and select it")]
        public void WhenISearchJobRoleAndSelectIt(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            NavigateTo.deliverySitesPage.TypeJobRole($"{data.JobRole}");

            By searchResul = By.XPath($"//mat-option[@aria-disabled='false']//span[text()='{data.JobRole}']");
            NavigateTo.deliverySitesPage.ElementToBeClickable(searchResul);
        }

        [Then(@"I can click on the Search box field")]
        public void ThenInCanClickOnTheSearchBox()
        {
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsJobRobleSearshFieldClickable());
        }

        [Then(@"In Job Role field should be selected <JobRole>")]
        public void ThenInJobRoleFieldIsSelectedRole(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            By searchResul = By.XPath("//mat-select[@aria-disabled='false']//mat-select-trigger[1]");
            string actualJobRole = DriverUtil.GetText(searchResul);
            string expectedJobRole = $"{data.JobRole}";
            Assert.AreEqual(expectedJobRole, actualJobRole);
        }

        [Then(@"I can select the last possible date")]
        public void ThenISelectLastDate()
        {
            // METHOD IS NOT OPTIMIZATED!!!
            WebElement startDatefield = (WebElement)DriverUtil.driver.FindElement(By.XPath("//input[@placeholder='Start Date']"));

            //valueForMaxDate should be 2100-01-01T00:00:00+02:00
            string valueForMaxDate = startDatefield.GetAttribute("max");
            string maxYear = valueForMaxDate.Split("-")[0];
            string valueMonth = valueForMaxDate.Split("-")[1];
            string maxMonth = valueMonth.TrimStart('0');
            string maxDay = valueForMaxDate.Substring(1, 1);
            maxMonth = NavigateTo.deliverySitesPage.ConvertMonthNumberToMonthName(maxMonth);

            By selectYar = By.XPath($"//div[text()=' {maxYear} ']");
            By selectmonth = By.XPath($"//div[text()=' {maxMonth} ']");
            By selectday = By.XPath($"//div[text()=' {maxDay} ']");

            // Ultimul element a classei parinte tbody 
            By lastYearLocation = By.XPath("//tbody/descendant::*[last()]");
            bool elementIsNotFound = true;

            while (elementIsNotFound)
            {
                if (!DriverUtil.GetText(lastYearLocation).Equals(maxYear))
                {
                    NavigateTo.deliverySitesPage.ClickNextYearButton();
                }
                else
                {
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectYar);
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectmonth);
                    NavigateTo.deliverySitesPage.ElementToBeClickable(selectday);
                    elementIsNotFound = false;
                }
            }

        }

        [When(@"I select <EndDate>")]
        public void WhenISelectEndDate(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string endDate = data.EndDate;

            string day = endDate.Split("/")[0];
            string month = endDate.Split("/")[1];
            string yar = endDate.Split("/")[2];
            month = NavigateTo.deliverySitesPage.ConvertMonthNumberToMonthName(month);

            By selectYar = By.XPath($"//div[text()=' {yar} ']");
            By selectmonth = By.XPath($"//div[text()=' {month} ']");
            By selectday = By.XPath($"//div[text()=' {day} ']");

            NavigateTo.deliverySitesPage.ElementToBeClickable(selectYar);
            NavigateTo.deliverySitesPage.ElementToBeClickable(selectmonth);
            NavigateTo.deliverySitesPage.ElementToBeClickable(selectday);
        }

        [When(@"I type <GrossCost>")]
        public void WhenIGrossCost(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            NavigateTo.deliverySitesPage.EnterGrossCost($"{data.GrossCost}");
        }

        [When(@"I click edit button for <JobRole>")]
        public void WhenIClickEditJobRole(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            By editBtn = By.XPath($"//span[text()='{data.JobRole}']/../..//i[@mattooltip='Edit']");

            NavigateTo.deliverySitesPage.ElementToBeClickable(editBtn);
        }

        [When(@"I click delete button for <JobRole>")]
        public void WhenIClickDeleteJobRole(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            By deleteBtn = By.XPath($"//span[text()='{data.JobRole}']/../..//i[@mattooltip='Delete']");

            NavigateTo.deliverySitesPage.ElementToBeClickable(deleteBtn);
        }

        [When(@"I press Save button")]
        public void WhenIPressSaveButton()
        {
            NavigateTo.deliverySitesPage.ClickSaveButton();
        }

        [When(@"I edit following data for <GrossCost>")]
        public void WhenIEditDataForGrossCost(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            NavigateTo.deliverySitesPage.ClearGrossCost();
            NavigateTo.deliverySitesPage.EnterGrossCost($"{data.GrossCost}");
        }

        [When(@"I confirm delete request")]
        public void WhenIConfirmDeleteRequest()
        {
            NavigateTo.deliverySitesPage.ConfirmDeleteRequest();
        }

        [Then(@"I should see successful creaded message '([^']*)'")]
        public void ThenIShouldSeeMessage(string p0)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));
            Assert.AreEqual(p0, actualResult);
        }

        [Then(@"I should see successful updated green text message '([^']*)'")]
        public void ThenIShouldSeeGreenTextMessagea(string p0)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));

            Assert.AreEqual(p0, actualResult);
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsGreenTextColor());
        }

        [Then(@"I should see successful deleted message '([^']*)'")]
        public void ThenIShouldSeeSuccefulDeleteMessage(string p0)
        {
            string actualResult = DriverUtil.GetText(By.XPath("//snack-bar-container[@role='status']//span"));

            Assert.AreEqual(p0, actualResult);
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsGreenTextColor());
        }

        [Then(@"By default the current month’s and day calendar should be displayed")]
        public void ThenDefaultCurrentMonthAndDate()
        {
 
            string actualMonthResult = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            string actualDayResult = NavigateTo.deliverySitesPage.GetCalendarWidgetDay();

            Assert.AreEqual($"{NavigateTo.deliverySitesPage.GetActualMonth()}", actualMonthResult);
            Assert.AreEqual($"{NavigateTo.deliverySitesPage.GetActualDay()}", actualDayResult);
        }

        [Then(@"I can move to previous and next month’s calendar")]
        public void ThenICanMovePreviosAndNextMonthsCalendar()
        {
            string defaultPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();

            //Previous button Test
            NavigateTo.deliverySitesPage.ClickPreviousMonthButton();
            string PreviousPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            Assert.AreNotEqual(PreviousPageWigetMonth, defaultPageWigetMonth);

            //Next button Test
            NavigateTo.deliverySitesPage.ClickNextMonthButtonTimes(2);
            string NextPageWigetMonth = NavigateTo.deliverySitesPage.GetCalendarWidgetMonth();
            Assert.AreNotEqual(NextPageWigetMonth, defaultPageWigetMonth);
        }

        [Then(@"I should see calendar widget")]
        public void ThenIShouldSeeCalendarWidget()
        {            
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsCalendarWidgetWindowOpened());
        }

        [Then(@"Mouse hover mouse pointer change from a pointer to hand")]
        public void ThenIShouldSeeDropdownListOpen()
        {
            Assert.IsTrue(NavigateTo.deliverySitesPage.IsCursorPointer());
        }

        [Then(@"Save button should be disabled")]
        public void ThenSaveButtonShouldBeDisabled()
        {
            Assert.IsFalse(NavigateTo.deliverySitesPage.IsSaveButtonEnabled());
        }

    }
}
