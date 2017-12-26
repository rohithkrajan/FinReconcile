Feature: CSVParser
	In order to read transactions from markoff csv file
	As a user
	I want to parse transactions from each line

@csvparser
Scenario: Parse header line before reading transactions
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |
	| Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, |
	| Card Campaign,2014-01-11 22:39:11,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5, |
	| Card Campaign,2014-01-11 23:28:11,-5000,CAPITAL BANK              MOGODITSHANE  BW,DEDUCT,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,  |
	When I call GetRecords 
	Then the result should be 3 transactions
@csvparser
Scenario: Parse empty file with only header line 
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |	
	When I call GetRecords 
	Then the result should be 0 transactions
@csvparser
Scenario: Ignore invalid lines while reading transactions
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |
	| Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, |
	| Card Campaign,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5, |
	| Card Campaign,2014-01-11 23:28:11,-5000,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,  |
	When I call GetRecords 
	Then the result should be 1 transactions
	And 2 Invalid Entries
	And Invalid entries matches line numbers 3 and 4
@csvparser
Scenario: Parse a large file Client Transactions File
	Given a large client markofffile with content	
	When I call GetRecords 
	Then the result should be 306 transactions
	And 0 Invalid Entries
@csvparser
Scenario: Parse a large file Bank Transactions File
	Given a large bank markofffile with content	
	When I call GetRecords 
	Then the result should be 305 transactions
	And 0 Invalid Entries
@csvparser
Scenario: Validate file for Headers
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |
	| Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, |
	| Card Campaign,2014-01-11 22:39:11,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5, |
	| Card Campaign,2014-01-11 23:28:11,-5000,CAPITAL BANK              MOGODITSHANE  BW,DEDUCT,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,  |
	When I call Validate 
	Then the result should be valid file
@csvparser
Scenario: Validate file with wrong Headers
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactioDate,TransactionAmoun,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |
	| Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, |
	| Card Campaign,2014-01-11 22:39:11,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5, |
	| Card Campaign,2014-01-11 23:28:11,-5000,CAPITAL BANK              MOGODITSHANE  BW,DEDUCT,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,  |
	When I call Validate 
	Then the result should be invalid file
	And Error Message should contain headername 'TransactionDate' with LineNo 1

Scenario: Validate file with multiple wrong Headers
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| ProfileName,TransactioDate,TransactionAmoun,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference           |
	| Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, |
	| Card Campaign,2014-01-11 22:39:11,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5, |
	| Card Campaign,2014-01-11 23:28:11,-5000,CAPITAL BANK              MOGODITSHANE  BW,DEDUCT,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,  |
	When I call Validate 
	Then the result should be invalid file
	And Error Messages should contain headername 'TransactionDate' and 'TransactionAmount' with LineNo 1
Scenario: Validate file for different headers order
	Given a markofffile	with content
	| Lines                                                                                                                                             |
	| WalletReference,ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType           |
	| P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1 |
	| P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1 |
	| P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5, Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1 |  
	When I call Validate 
	Then the result should be valid file
	And with 3 Transactions and No Errors