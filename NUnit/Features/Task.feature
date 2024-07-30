Feature: Login to Website, open item in new tab and preview mode and search item
	Login to Website, open item in new tab and preview mode and search item

@Browser:Chrome
Scenario: Login to website
	Given I have navigated to the website
	When I have entered my email address and click submit
	When I verify my email address
	Then I enter submit
	
@Browser:Chrome
Scenario: Open new Tab
	Given I have logged in
	Given I have clicked on action button
	Given I click on new tab button
	Then New Tab opens

@Browser:Chrome
Scenario: Open Preview
	Given I have logged in
	Given I have clicked on action button
	Given I click on preview button
	Then Preview tab opens

@Browser:Chrome
Scenario: Search files
	Given I have logged in
	When I click home button
	Given I search a product
	Then Product should show