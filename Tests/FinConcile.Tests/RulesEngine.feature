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
Scenario: Match Dates of two transactions which are within 2 minutes
	Given two transacions with same id '584011808649511' and dates '1/11/2014  10:27:00 PM' and '1/11/2014  10:27:44 PM' respectively
	And A rule to match Ids and Dates with a delta of 120 seconds
	When I call Reconcile
	Then the result should be matched ReconciledItem

@rules
Scenario: Match Ids and Amount
	Given two transacions with same '584011808649511' and amount -20000
	And A rule to match Ids and amount
	When I call Reconcile
	Then the result should be matched ReconciledItem

@rules
Scenario: Match Ids and But Not Amount
	Given two transacions with same Id '584011808649511' and different amount -20000 and -20002
	And A rule to match Ids and amount
	When I call Reconcile
	Then the result should be not matched ReconciledItem

@rules
Scenario Outline: Match all the fields of transactions
	Given ClientTransacion with '<c_id>' '<c_profilename>' '<c_date>' '<c_amount>' '<c_narrative>' '<c_description>' '<c_walletreference>'
	And TutukaTransacion with '<t_id>' '<t_profilename>' '<t_date>' '<t_amount>' '<t_narrative>' '<t_description>' '<t_walletreference>'
	And A ruleset to match all fields of Transaction
	When I call Reconcile
	Then the result should be matched ReconciledItem

Examples:
| c_id             | t_id             | c_profilename | t_profilename | c_date                 | t_date                 | c_amount | t_amount | c_narrative                                | t_narrative                                | c_description | t_description | c_walletreference                  | t_walletreference                  |
| 584011808649511  | 584011808649511  | Card Campaign | Card Campaign | 1/11/2014  10:27:00 PM | 1/11/2014  10:27:00 PM | -20000   | -20000   | *MOLEPS ATM25             MOLEPOLOLE    BW | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT        | DEDUCT        | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 |
| 84012233581869   | 84012233581869   | Card Campaign | Card Campaign | 1/12/2014  6:26:00 AM  | 1/12/2014  6:26:00 AM  | -20000   | -20000   | Molepolole Filli100558    Gaborone      BW | Molepolole Filli100558    Gaborone      BW | DEDUCT        | DEDUCT        | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 |
| 0584012395072004 | 0584012395072004 | Card Campaign | Card Campaign | 2014-01-12 14:58:27    | 2014-01-12 14:58:27    | -10000   | -10000   | MAHALAPYE BRANCH          BOTSWANA      BW | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT        | DEDUCT        | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 |
| 0164012401925347 | 0164012401925347 | Card Campaign | Card Campaign | 2014-01-12 15:09:52    | 2014-01-12 15:09:52    | 3880     | 3880     | 370592 ENGEN LOBATSE      BOTSWANA      BW | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL      | REVERSAL      | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 |


#@rules
#Scenario Outline: Match all the fields exactly and dates with a delta of 120 seconds
#	Given ClientTransacion with '<c_id>' '<c_profilename>' '<c_date>' '<c_amount>' '<c_narrative>' '<c_description>' '<c_walletreference>'
#	And TutukaTransacion with '<t_id>' '<t_profilename>' '<t_date>' '<t_amount>' '<t_narrative>' '<t_description>' '<t_walletreference>'
#	And A ruleset to match all fields exactly and date field with a delta of 120 seconds
#	When I call Reconcile
#	Then the result should be matched ReconciledItem
#
#Examples:
#| c_id             | t_id             | c_profilename | t_profilename | c_date                 | t_date                 | c_amount | t_amount | c_narrative                                | t_narrative                                | c_description | t_description | c_walletreference                  | t_walletreference                  |
#| 584011808649511  | 584011808649511  | Card Campaign | Card Campaign | 1/11/2014  10:27:00 PM | 1/11/2014  10:27:44 PM | -20000   | -20000   | *MOLEPS ATM25             MOLEPOLOLE    BW | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT        | DEDUCT        | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 |
#| 84012233581869   | 84012233581869   | Card Campaign | Card Campaign | 1/12/2014  6:26:00 AM  | 1/12/2014  6:26:17 AM  | -20000   | -20000   | Molepolole Filli100558    Gaborone      BW | Molepolole Filli100558    Gaborone      BW | DEDUCT        | DEDUCT        | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 |
#| 0584012395072004 | 0584012395072004 | Card Campaign | Card Campaign | 2014-01-12 14:58:27    | 2014-01-12 14:58:27    | -10000   | -10000   | MAHALAPYE BRANCH          BOTSWANA      BW | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT        | DEDUCT        | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 |
#| 0164012401925347 | 0164012401925347 | Card Campaign | Card Campaign | 2014-01-12 15:09:52    | 2014-01-12 15:09:52    | 3880     | 3880     | 370592 ENGEN LOBATSE      BOTSWANA      BW | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL      | REVERSAL      | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 |




