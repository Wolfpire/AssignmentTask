Feature: Petstore

Scenario: Order a pet
	Given the base url is "https://petstore.swagger.io/v2/"
	* the pets id is 0
	* the pets petId is 0
	* the pets shipDate is "2021-02-10T02:14:52.989Z"
	* the pets status is "placed"
	* the pets complete is "true"
	But the uri path is "store/orders"
	When the order is placed
	Then the response status code should be 404

	Scenario: Create a user
	Given the base url is "https://petstore.swagger.io/v2/"
	* the uri path is "user"
	* the users id is 0
	* the users username is "Steavy"
	* the users firstName is "Steven"
	* the users lastName is "Thomson"
	* the users email is "sthomson@localhost.com"
	* the users password is "thomson1990"
	* the users phone is "421123456"
	* the users userStatus is 0
	When user is created
	Then the response status code should be 200

	Scenario: Get a user
	Given the base url is "https://petstore.swagger.io/v2/"
	And the partial uri path is "user/"
	And username is "Steavy"
	When the request is made
	Then the response status code should be 200
	And the post and get response content matches

	Scenario: Delete user
	Given the base url is "https://petstore.swagger.io/v2/"
	And the partial uri path is "user/"
	And username is "Steavy"
	But request method is put
	When delete is requested
	Then the response status code should be 415

