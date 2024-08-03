Feature: GetBoards
	As a user 
	I want to access all my boards
	So I want 1 API Endpoint that returns all the boards

Background: a request with auth
	Given a request with authorisation
	And the request has query params

Scenario: Check Get Boards 
	And the request has 'member' path param with value 'learnpostman'
	When request is sent
	Then receieve html status OK
	And receive valid json file with 'get_boards.json' schema

Scenario: Check Get Board
	And the request has 'id' path param with value '6288cc5d3ce8fc87542dff31'
	When the request is sent to the GetBoard API
	Then receieve html status OK
	And receive valid json file with 'get_board.json' schema
	And check if the response 'name' is equal to 'New Board'
