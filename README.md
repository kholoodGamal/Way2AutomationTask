# Way2AutomationTask
In this task, I handeled 4 links +ve workflow using Selenium WebDriver C# with PageObject
Site URL : http://www.way2automation.com/protractor-angularjs-practice-website.html


Work Flows :
1.	Go to Homepage (Base URL “http://www.way2automation.com/protractor-angularjs-practice-website.html”)
2.	Go to Registration from Homepage (it’s actually login):
	a.	Enter username “angular”
	b.	Enter password “password”
	c.	Enter username description
	d.	Click Login
	e.	Check that the page contains text “You’re logged in!!”
	f.	Click on logout
	g.	Check that user is logged out successfully
3.	Go to Multi Form from Homepage
	a.	Enter Name and Email
	b.	Click Next
	c.	Select one of the radio buttons randomly and get its text to check it later
	d.	Click Next
	e.	Click on Submit
	f.	Check that an Alert is displayed and Close it 
	g.	Check that the entered data is displayed in the container below the fields
4.	Go to Web Tables from Homepage
	a.	Add a new user to the grid by entering all the fields in the form (fill one of the fields with something unique)
	b.	Check that the user is added successfully to the grid
	c.	Search for the user with the unique value using the search field at the top of the page
	d.	Check that only one row is displayed after search
	e.	Edit the added user and make it locked (checkbox in the popup)
	f.	Check that the locked checkbox in the grid is now checked
	g.	Delete the user
	h.	Check that the user is deleted from the grid
5.	Go to Calculator from Homepage
	a.	Add/Subtract 2 numbers
	b.	Check that the expression and result are correct in the grid
  
