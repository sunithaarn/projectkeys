Feature: AddNewProperty
	

@mytag
Scenario: Owner add new property
	Given Owner logged into the application
	And Move to properties page
	When Click AddNewProperty to add details about new property
	Then Added property should be displayed under Myproperties

Scenario: Verify  on selecting owner occupied option doesn’t allow to add tenant details
	Given Owner logged into the application
	And under properties page
	When ownerclick Addnew property to add details
	Then properties should is saved with successfully and displayed under properties
 


 
Scenario: verify Next button on click moves to Finance details section
Given Owner logged into the application
And in the addnew property page
When click next to move to next section
Then Finance details section need to be displayed

Scenario: verify Next button on click moves to tenant details section
Given Owner logged in 
And Added property details moved to the finance section
When Add finance detais and click next 
Then Tenant details section should be displayed.
 
Scenario: verify the validation of the property details section fields
Given Owner logged in
And moved to Add new property page
When Enterinvalid values in the fields
Then validation messages is displayed

Scenario: verify choose file option accepts only five files
Given Owner logged in
And moved to Addnew property 
When Add 6files with totalsize more than 5 MB
Then validation message should be displayed

Scenario:verify file option accepts different file formats
Given Owner logged in
And Moved to Addnew property page
When upload files with different formats
Then validation message should be displayed


 Scenario: verify the validation of the finance details section fields
Given Owner logged in
And moved to Add new property - Add finance details section
When Enterinvalid values in the fields
Then validation messages is displayed 


Scenario: Verify on clicking previous displays the property details section
Given Owner logged in application
And moved to Add property finance details section
When click previous button
Then property details section is displayed with values

Scenario: Verify is it possible to add repayment details
Given Owner logged in
And moved to Add new property - Finance section details
When click Add repayment  and enter details
Then Repayment details should save successfully


Scenario: verify remove repayment
Given Owner logged in
And moved to add new property - property details-finance details - Add repayment
When click Remove repayment
Then Repayment details is deleted successfully

Scenario: Verify is it possible to add expenses details
Given Owner logged in
And moved to Add new property - Finance section details
When click Add expenses  and enter details
Then Expenses details should save successfully

Scenario: verify remove expenses
Given Owner logged in
And moved to add new property - property details-finance details - Add expenses
When click Remove expense
Then expenses details is deleted successfully



Scenario:  Verify fields are validated in Tenant details
Given Owner logged into the application
And moved to Add new property - Finance section details- Tenant details
When Enter invalid values in the fields
Then Appropriate validation messages should be displayed

Scenario: verify the previous button in Tenants details
Given Owner logged into the application
And  moved to Add new property - Finance section details- Tenant details
When click previous button
Then Finance details section is displayed with values


Scenario: verify add  liabilities 
Given Owner logged in
And moved to add new property - property details-finance details 
When click Add Liabilities
Then Liabilities details are added successfully


Scenario: Verify Remove liabilitites
Given owmer logged in
And moved to add new property - property details-finance details - Add liabilities
When Remove liablities
Then Liabilities is deleted successfully








