Feature: UpdateBoard
	As a User
	I want to a particular board
	So I want an API endpoint  

Scenario: Check Update Board
	Given name to be changed to 'testupdate'
	And request with auth
	And query params
	| name | value |
	| id | 60d84769c4ce7a09f9140220 |
	And JSON body
	| name | value |
	| name | testupdate |
	When request is sent to UpdateBoard Endpoint
	Then response status code is OK
	And received param 'name' is 'testupdate'
	And GetBoard endpoint returns 'testupdate' for param 'name' for identification 'id' with value '60d84769c4ce7a09f9140220'