Feature: ReconcileEngine
	In order to reconcile transactions
	As a user
	I want to be told whether a list of client and tutuka tranascations are matched or notmatched

@reconcileengine
Scenario: Reconcile Matching Client and Tutuka Transactions
	Given A list of Client transactions
	| Id               | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511  | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 84012233581869   | Card Campaign | 1/12/2014  6:26:00 AM  | -20000 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | 1    |
	| 0584012395072004 | Card Campaign | 2014-01-12 14:58:27    | -10000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | 1    |
	| 0164012401925347 | Card Campaign | 2014-01-12 15:09:52    | 3880   | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | 1    |
	And a list of matching Tutuka Transactions
	| Id               | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511  | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 84012233581869   | Card Campaign | 1/12/2014  6:26:00 AM  | -20000 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | 1    |
	| 0584012395072004 | Card Campaign | 2014-01-12 14:58:27    | -10000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | 1    |
	| 0164012401925347 | Card Campaign | 2014-01-12 15:09:52    | 3880   | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | 1    |
	And a RuleSet With PropertyRules 	
	| SourceProperty  | TargetProperty  | Operator |
	| Date            | Date            | Equal    |
	| Amount          | Amount          | Equal    |
	| WalletReference | WalletReference | Equal    |
	| Id              | Id              | Equal    |
	| Narrative       | Narrative       | Equal    |
	| Description     | Description     | Equal    |
	When I call Reconcile
	Then the result should be 4 Matched ReconciledItem

@reconcileengine
Scenario: Reconcile Non Matching Client and Tutuka Transactions
	Given A list of Client transactions
	| Id               | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511  | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 84012233581869   | Card Campaign | 1/12/2014  6:26:00 AM  | -20000 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | 1    |
	| 0584012395072004 | Card Campaign | 2014-01-12 14:58:27    | -10000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | 1    |
	| 0164012401925347 | Card Campaign | 2014-01-12 15:09:52    | 3880   | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | 1    |
	And a list of Non matching Tutuka Transactions With Different Ids
	| Id               | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 5840118086495112  | Card Campaign | 1/11/2014  10:27:00 PM | -10000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 840122335818692   | Card Campaign | 1/13/2014  6:26:00 AM  | -20000 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | 1    |
	| 05840123950720042 | Card Campaign | 2014-01-12 14:58:27    | -40000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | 1    |
	| 01640124019253472 | Card Campaign | 2014-02-12 15:09:52    | 6880   | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | 1    |
	And a RuleSet With PropertyRules 	
	| SourceProperty  | TargetProperty  | Operator |
	| Date            | Date            | Equal    |
	| Amount          | Amount          | Equal    |
	| WalletReference | WalletReference | Equal    |
	When I call Reconcile
	Then the reconciled result should be 0 Matched Client Transactions 4 Unmatched Client transactions
	And 0 Matched Tutuka Transactions 4 Unmatched Tutuka transactions

@reconcileengine
Scenario: Reconcile mix of matching and non matching Client and Tutuka Transactions
	Given A list of Client transactions
	| Id               | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511  | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 84012233581869   | Card Campaign | 1/12/2014  6:26:00 AM  | -20000 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2 | 1    |
	| 0584012395072004 | Card Campaign | 2014-01-12 14:58:27    | -10000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2 | 1    |
	| 0164012401925347 | Card Campaign | 2014-01-12 15:09:52    | 3880   | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1 | 1    |
	And a list of Tutuka Transactions
	| Id                | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                      | Type |
	| 584011808649511   | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5   | 1    |
	| 84012233581869    | Card Campaign | 1/12/2014  6:26:00 AM  | -20005 | Molepolole Filli100558    Gaborone      BW | DEDUCT      | P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2   | 1    |
	| 0584012395072004  | Card Campaign | 2014-01-12 14:58:27    | -10000 | MAHALAPYE BRANCH          BOTSWANA      BW | DEDUCT      | P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2   | 1    |
	| 01640124019253472 | Card Campaign | 2014-01-12 15:09:52    | 38804  | 370592 ENGEN LOBATSE      BOTSWANA      BW | REVERSAL    | P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA133 | 1    |
	And a RuleSet With PropertyRules 	
	| SourceProperty  | TargetProperty  | Operator |
	| Date            | Date            | Equal    |
	| Amount          | Amount          | Equal    |
	| WalletReference | WalletReference | Equal    |
	| Id              | Id              | Equal    |
	| Narrative       | Narrative       | Equal    |
	| Description     | Description     | Equal    |
	When I call Reconcile
	Then the result should be 2 Matched ReconciledItems and 3 Non Matched ReconciledItems

@reconcileengine
Scenario: Reconcile Client and Tutuka Transactions With Duplicate TransactionIds
	Given A list of Client transactions
	| Id              | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | 20000  | *MOLEPS ATM25             MOLEPOLOLE    BW | REVERSAL    | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |	
	And a list of matching Tutuka Transactions
	| Id              | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | 20000  | *MOLEPS ATM25             MOLEPOLOLE    BW | REVERSAL    | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	And a RuleSet With PropertyRules 	
	| SourceProperty  | TargetProperty  | Operator |
	| Date            | Date            | Equal    |
	| Amount          | Amount          | Equal    |
	| WalletReference | WalletReference | Equal    |
	| Id              | Id              | Equal    |
	| Narrative       | Narrative       | Equal    |
	| Description     | Description     | Equal    |
	When I call Reconcile
	Then the result should 2 Matched ReconciledItem