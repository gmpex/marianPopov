@RoleCosts
Feature: RoleCosts
....

Background: Loggin scenario
	Given Admin user is on 'Amdaris Bristol' Role Costs page 

@AddNewRoleCost
Scenario Outline: 01.Add Role Cost using Valid data
	When Add Role Cost using valid data <JobRole>, <StartDate>, <EndDate> and <GrossCost> fields
	Then Successful created message <Message> is shown

Examples:
| JobRole       | StartDate  | EndDate    | GrossCost | Message                          |
| Administrator | 06/07/2022 | 08/30/2022 | 5200      | Role cost was added successfully |

@EidtRoleCost
Scenario: 02.Succefully Edit Role Cost.
	When Changed Gross Cost for 'Administrator' Job Role
	Then Successful updated green message 'Role cost was updated successfully' is shown

@DeleteRoleCost
Scenario: 03.Succefully Delete Role Cost.
	When Delete 'Administrator' Job Role
	Then Successful deleted message 'Role cost deleted successfully' is shown

@AddNewRoleCost @SaveButton
Scenario: Save button should be disabled when required fields for Add new role cost is not filled.
	When Leave all field by default for Add new role cost
	Then Save button should be disabled

@AddNewRoleCost @JobRoleDropDown @HoverMouse
Scenario: Hover mouse pointer should be change from a pointer to hand.
	When Hover mouse on the Job Role Dropdown 
	Then Mouse hover mouse pointer changed from a pointer to hand

@AddNewRoleCost @JobRoleDropDown @Search
Scenario: Search box field for Job Role Dropdown should be clickable.
	When Job Role dropdown is shown
	Then Search box field is clickable

@AddNewRoleCost @JobRoleDropDown @Search
Scenario Outline: Selected Value from the search box list should be the same with value Job Role field.
	When When Entered <JobRole> text in search box field and selected it
	Then For Job Role field should be selected <JobRole>

Examples:
| JobRole       |
| Administrator |

@AddNewRoleCost @CalendarWidget
Scenario: Clicking the date field, a calendar widget should open.
	When Start date field is clicked
	Then Calendar widget is shown

@AddNewRoleCost @CalendarWidget @CurrentMonthAndDay
Scenario: By default the current month and day should be displayed in datepicker.
	When Datepicker is opened
	Then Current month and day is shown by Default

@AddNewRoleCost @CalendarWidget @PreviousAndNextButton
Scenario: User can move to previous and next month’s calendar by choosing the left and right icon over the calendar.
	When Start datepicker is opened
	Then Previous and next month calendar button it's work

@AddNewRoleCost @CalendarWidget @LastDate
Scenario: The last possible date that can be set on the calendar
	When Open Start Datepicker
	Then The last possible date is selected
