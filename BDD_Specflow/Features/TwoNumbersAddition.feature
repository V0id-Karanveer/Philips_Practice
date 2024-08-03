Feature: Two Numbers Addition
	As a user of calculator
	I want to add and see the results of the addition
	So want to make sure that the calculations are correct

Scenario: Given 2 numbers for addition
	Given number 1 as 10
	And number 2 as 20
	When user adds number 1 & number 2
	Then result is 30
