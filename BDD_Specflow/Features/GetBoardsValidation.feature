Feature: GetBoardsValidation
	As a User
	I want to keep my boards protected
	So that I can be sure that only I can access them


Scenario Outline: Check Get Board with invalid ID
	Given request with authorization
	And query params:
	| name | value     |
	| id   | <id_value> |
	When a 'GET' request is sent to '/1/boards/{id}' endpoint
	Then status code is <status_code>
	And response has error message <error_message>
	Examples: 
	| id_value | status_code | error_message |
	| invalid | BadRequest | invalid id |
	| 60d847d9aad2437cb984f8e1 | BadRequest | invalid id |

Scenario Outline: Check Get Board with Invalid Auth
	Given a request without authorization
	And url segment:
	| name | value                    |
	| id   | 6288cc5d3ce8fc87542dff31 |
	And query params:
	| name  | value      |
	| key   | <key_value> |
	| token | <token_value> |
	When a 'GET' request is sent to '/1/boards/{id}' endpoint
	Then status code is Unauthorized
	And response has error message <error_message>
	Examples: 
	| key_value                              | token_value                                                            | error_message                     |
    |                                  |                                                                  | unauthorized permission requested                       |
    | fb04999a731923c2e3137153b1ad5de0 |                                                                  | unauthorized permission requested |
    |                                  | b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1 | invalid app key                       |
    | 8b32218e6887516d17c84253faf967b6 | 492343b8106e7df3ebb7f01e219cbf32827c852a5f9e2b8f9ca296b1cc604955 | invalid token                     |