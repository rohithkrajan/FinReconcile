Feature: Compare Transactions
	In order to reconcile transactions
	As a user
	I want to compare client and tutuka markoff files

@tranascationcompare
Scenario: Browse Compare Page	
	When the user goes to compare user screen
	Then the compare user view should be displayed

@transactioncompare
Scenario: On Successful upload of Transaction Files,user should be shown Comparison Result Page
	Given ClientMarkOffFile and TutukaMarkOffFile
	When the user clicks on the Compare button
	Then user should be redirected to compare result Page

@transactioncompare
Scenario: Details in Comparison Result Page
	Given ClientMarkOffFile and TutukaMarkOffFile
	When the user clicks on the Compare button
	Then Comparison Result should contain Both Names of the Files 'ClientMarkoffFile20140113' and 'TutukaMarkoffFile20140113'


