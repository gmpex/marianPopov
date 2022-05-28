Feature: DeliverySites
....

@Succefully:AddRoleCost
Scenario: 01.Add Role Cost using Valid data
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
    And I click on the Job Role field
	And I select <JobRole>
	|		JobRole |
    | Administrator |
	And I click on the Start Date field
	And I click on the Choose Date button
	And I select <StartDate>
	| StartDate |
	| 22/5/2022 |
	And I click on the End Date field
	And I click on the Choose Date button
	And I select <EndDate>
	|  EndDate  |
    | 30/5/2022 |
	And I type <GrossCost>
	|  GrossCost |
    |		5200 |
	And I press Save button
	Then I should see successful creaded message 'Role cost was added successfully'

@Succefully:EditRoleCost
Scenario: 02.Succefully Edit Role Cost
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click edit button for <JobRole>
	|		JobRole |
    | Administrator |
	And I edit following data for <GrossCost>
	| GrossCost |
	|	   4200 |
	And I press Save button
	Then I should see successful updated green text message 'Role cost was updated successfully'

@Succefully:DeleteRoleCost
Scenario: 03.Succefully Delete Role Cost
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click delete button for <JobRole>
	|		JobRole |
    | Administrator |
	And I confirm delete request
	Then I should see successful deleted message 'Role cost deleted successfully'


Scenario: 04.Click on the Save button without filling required fields
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	Then Save button should be disabled


@JobRole:Dropdown
Scenario: 05.Verify on mouse hover mouse pointer change from a pointer to hand or not.
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Job Role field
	Then Mouse hover mouse pointer change from a pointer to hand

@Search
Scenario: 06.If Search is added in the Dropdown.
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Job Role field
	Then I can click on the Search box field

Scenario: 07.Verify that the value from the list should be selected if the user add a valid keyword
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Job Role field
	And I search <JobRole> and select it
	| JobRole |
	| Administrator |
	Then In Job Role field should be selected <JobRole>
	| JobRole |
	| Administrator |

@Calendar
Scenario: 08.Verify that on clicking the date field, a calendar widget should open
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Start Date field
	Then I should see calendar widget

Scenario: 09.Verify that by default the current month’s and day calendar should be displayed
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Start Date field
	Then By default the current month’s and day calendar should be displayed

Scenario: 10.Verify that the user can move to previous and next month’s calendar by choosing the left and right icon over the calendar
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Start Date field
	Then I can move to previous and next month’s calendar

Scenario: 11.Verify the last possible date that can be set on the calendar
	Given I logged by Admin User
	When I click on the Delivery Sites tab
	And I click on the 'Amdaris Bristol' site
	And I click on the Role Costs link
	And I click on the Add Role Cost button
	And I click on the Start Date field
	And I click on the Choose Date button
	Then I can select the last possible date
