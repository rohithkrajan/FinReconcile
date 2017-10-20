Feature: RulesEngine
	In order to reconcile transactions
	As a user
	I want to define rules

@ruleengine
Scenario: Match Ids of two transactions
	Given two transacions with same Ids	
	And A rule to match Ids
	When I call Reconcile
	Then the result should be matched ReconciledItem
