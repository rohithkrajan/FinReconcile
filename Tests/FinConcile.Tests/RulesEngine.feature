Feature: RulesEngine
	In order to reconcile transactions
	As a user
	I want to define rules

@rules
Scenario: Match Ids of two transactions
	Given two transacions with same Ids	
	And A rule to match Ids
	When I call Reconcile
	Then the result should be matched ReconciledItem

@rules
Scenario: Match Ids and Amount
	Given two transacions with same Ids	and amount
	And A rule to match Ids and amount
	When I call Reconcile
	Then the result should be matched ReconciledItem

@rules
Scenario: Match Ids and But Not Amount
	Given two transacions with same Ids	and different amount
	And A rule to match Ids and amount
	When I call Reconcile
	Then the result should be not matched ReconciledItem

