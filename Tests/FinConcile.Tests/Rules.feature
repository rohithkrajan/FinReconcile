Feature: Rules
	In order to match transactions
	As a user
	I want to define custom rules

@rules
Scenario: Define PropertyFuzzyMatchRule to fuzzy string match two string fields
	Given I have a Rule
	| sourceproperty | targetproperty | levenshteidistance |
	| Narrative    | Narrative    | 1                   |
	And A list of client transactions to match 
	| Id              | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MOLEPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | 20000  | *MOLEPS ATM25             MOLEPOLOLE    BW | REVERSAL    | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |	
	And a list of tutuka transactions slightly different descriptions
	| Id              | ProfileName   | Date                   | Amount | Narrative                                  | Description | WalletReference                    | Type |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | -20000 | *MLPS ATM25             MOLEPOLOLE    BW | DEDUCT      | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	| 584011808649511 | Card Campaign | 1/11/2014  10:27:00 PM | 20000  | *MOLEPS ATM25             MOLEPOLOLE    BW | REVERSAL    | P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5 | 1    |
	When I call evaluate for each transactions
	Then the result should be matched ReconciledItem
