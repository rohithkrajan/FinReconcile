jsonPWrapper ({
  "Features": [
    {
      "RelativeFolder": "TransactionCompare.feature",
      "Feature": {
        "Name": "Compare Transactions",
        "Description": "In order to reconcile transactions\r\nAs a user\r\nI want to compare client and tutuka markoff files",
        "FeatureElements": [
          {
            "Name": "Browse Compare Page",
            "Slug": "browse-compare-page",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "the user goes to compare user screen",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the compare user view should be displayed",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@tranascationcompare"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "On Successful upload of Transaction Files,user should be shown Comparison Result Page",
            "Slug": "on-successful-upload-of-transaction-filesuser-should-be-shown-comparison-result-page",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "ClientMarkOffFile and TutukaMarkOffFile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "the user clicks on the Compare button",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "user should be redirected to compare result Page",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@transactioncompare"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Details in Comparison Result Page",
            "Slug": "details-in-comparison-result-page",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "ClientMarkOffFile and TutukaMarkOffFile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "the user clicks on the Compare button",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "Comparison Result should contain Both Names of the Files 'ClientMarkoffFile20140113' and 'TutukaMarkoffFile20140113'",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@transactioncompare"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "CSVParser.feature",
      "Feature": {
        "Name": "CSVParser",
        "Description": "In order to read transactions from markoff csv file\r\nAs a user\r\nI want to parse transactions from each line",
        "FeatureElements": [
          {
            "Name": "Parse header line before reading transactions",
            "Slug": "parse-header-line-before-reading-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a markofffile\twith content",
                "TableArgument": {
                  "HeaderRow": [
                    "Lines"
                  ],
                  "DataRows": [
                    [
                      "ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference"
                    ],
                    [
                      "Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5,"
                    ],
                    [
                      "Card Campaign,2014-01-11 22:39:11,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5,"
                    ],
                    [
                      "Card Campaign,2014-01-11 23:28:11,-5000,CAPITAL BANK              MOGODITSHANE  BW,DEDUCT,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call GetRecords",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 3 transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@csvparser"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Parse empty file with only header line",
            "Slug": "parse-empty-file-with-only-header-line",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a markofffile\twith content",
                "TableArgument": {
                  "HeaderRow": [
                    "Lines"
                  ],
                  "DataRows": [
                    [
                      "ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call GetRecords",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 0 transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@csvparser"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Ignore invalid lines while reading transactions",
            "Slug": "ignore-invalid-lines-while-reading-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a markofffile\twith content",
                "TableArgument": {
                  "HeaderRow": [
                    "Lines"
                  ],
                  "DataRows": [
                    [
                      "ProfileName,TransactionDate,TransactionAmount,TransactionNarrative,TransactionDescription,TransactionID,TransactionType,WalletReference"
                    ],
                    [
                      "Card Campaign,2014-01-11 22:27:44,-20000,*MOLEPS ATM25             MOLEPOLOLE    BW,DEDUCT,0584011808649511,1,P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5,"
                    ],
                    [
                      "Card Campaign,-10000,*MOGODITSHANE2            MOGODITHSANE  BW,DEDUCT,0584011815513406,1,P_NzI1MjA1NjZfMTM3ODczODI3Mi4wNzY5,"
                    ],
                    [
                      "Card Campaign,2014-01-11 23:28:11,-5000,0464011844938429,1,P_NzI0NjE1NzhfMTM4NzE4ODExOC43NTYy,"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call GetRecords",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 1 transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "2 Invalid Entries",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Invalid entries matches last two rows",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@csvparser"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Parse a large file Client Transactions File",
            "Slug": "parse-a-large-file-client-transactions-file",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a large client markofffile with content",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call GetRecords",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 306 transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "0 Invalid Entries",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@csvparser"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Parse a large file Tutuka Transactions File",
            "Slug": "parse-a-large-file-tutuka-transactions-file",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a large tutuka markofffile with content",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call GetRecords",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 305 transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "0 Invalid Entries",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@csvparser"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "ReconcileEngine.feature",
      "Feature": {
        "Name": "ReconcileEngine",
        "Description": "In order to reconcile transactions\r\nAs a user\r\nI want to be told whether a list of client and tutuka tranascations are matched or notmatched",
        "FeatureElements": [
          {
            "Name": "Reconcile Matching Client and Tutuka Transactions",
            "Slug": "reconcile-matching-client-and-tutuka-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "A list of Client transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "84012233581869",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "0584012395072004",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "0164012401925347",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of matching Tutuka Transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "84012233581869",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "0584012395072004",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "0164012401925347",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a RuleSet With PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ],
                    [
                      "Id",
                      "Id",
                      "Equal"
                    ],
                    [
                      "Narrative",
                      "Narrative",
                      "Equal"
                    ],
                    [
                      "Description",
                      "Description",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Reconcile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 4 Matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@reconcileengine"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Reconcile Non Matching Client and Tutuka Transactions",
            "Slug": "reconcile-non-matching-client-and-tutuka-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "A list of Client transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "84012233581869",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "0584012395072004",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "0164012401925347",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of Non matching Tutuka Transactions With Different Ids",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "5840118086495112",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-10000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "840122335818692",
                      "Card Campaign",
                      "1/13/2014  6:26:00 AM",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "05840123950720042",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-40000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "01640124019253472",
                      "Card Campaign",
                      "2014-02-12 15:09:52",
                      "6880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a RuleSet With PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Reconcile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the reconciled result should be 0 Matched Client Transactions 4 Unmatched Client transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "0 Matched Tutuka Transactions 4 Unmatched Tutuka transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@reconcileengine"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Reconcile mix of matching and non matching Client and Tutuka Transactions",
            "Slug": "reconcile-mix-of-matching-and-non-matching-client-and-tutuka-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "A list of Client transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "84012233581869",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "0584012395072004",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "0164012401925347",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of Tutuka Transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "84012233581869",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "-20005",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "1"
                    ],
                    [
                      "0584012395072004",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "1"
                    ],
                    [
                      "01640124019253472",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "38804",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA133",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a RuleSet With PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ],
                    [
                      "Id",
                      "Id",
                      "Equal"
                    ],
                    [
                      "Narrative",
                      "Narrative",
                      "Equal"
                    ],
                    [
                      "Description",
                      "Description",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Reconcile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be 2 Matched ReconciledItems and 3 Non Matched ReconciledItems",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@reconcileengine"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Reconcile Client and Tutuka Transactions With Duplicate TransactionIds",
            "Slug": "reconcile-client-and-tutuka-transactions-with-duplicate-transactionids",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "A list of Client transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of matching Tutuka Transactions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a RuleSet With PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ],
                    [
                      "Id",
                      "Id",
                      "Equal"
                    ],
                    [
                      "Narrative",
                      "Narrative",
                      "Equal"
                    ],
                    [
                      "Description",
                      "Description",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Reconcile",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should 2 Matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@reconcileengine"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "Rules.feature",
      "Feature": {
        "Name": "Rules",
        "Description": "In order to match transactions\r\nAs a user\r\nI want to define custom rules",
        "FeatureElements": [
          {
            "Name": "Define A simple PropertyRule to Equal two fields",
            "Slug": "define-a-simple-propertyrule-to-equal-two-fields",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a set of PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A list of client transactions to match",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of tutuka transactions slightly different descriptions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call evaluate for each transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItems as Follows",
                "TableArgument": {
                  "HeaderRow": [
                    "MatchType"
                  ],
                  "DataRows": [
                    [
                      "Matched"
                    ],
                    [
                      "Matched"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Define A simple DateRule to Equal two dates within a delta of 600 seconds",
            "Slug": "define-a-simple-daterule-to-equal-two-dates-within-a-delta-of-600-seconds",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a DateRule with Delta\tof 3600 seconds",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A list of client transactions to match",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of tutuka transactions slightly different descriptions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:59:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  11:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call evaluate for each transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItems as Follows",
                "TableArgument": {
                  "HeaderRow": [
                    "MatchType"
                  ],
                  "DataRows": [
                    [
                      "Matched"
                    ],
                    [
                      "Matched"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Define PropertyRules to Equal two fields",
            "Slug": "define-propertyrules-to-equal-two-fields",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a set of PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ],
                    [
                      "Id",
                      "Id",
                      "Equal"
                    ],
                    [
                      "Narrative",
                      "Narrative",
                      "Equal"
                    ],
                    [
                      "Description",
                      "Description",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A list of client transactions to match",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of tutuka transactions slightly different descriptions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call evaluate for each transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItems as Follows",
                "TableArgument": {
                  "HeaderRow": [
                    "MatchType"
                  ],
                  "DataRows": [
                    [
                      "Matched"
                    ],
                    [
                      "Matched"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Define PropertyRules Which Unmatch if any two fields do not match",
            "Slug": "define-propertyrules-which-unmatch-if-any-two-fields-do-not-match",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "a set of PropertyRules",
                "TableArgument": {
                  "HeaderRow": [
                    "SourceProperty",
                    "TargetProperty",
                    "Operator"
                  ],
                  "DataRows": [
                    [
                      "Date",
                      "Date",
                      "Equal"
                    ],
                    [
                      "Amount",
                      "Amount",
                      "Equal"
                    ],
                    [
                      "WalletReference",
                      "WalletReference",
                      "Equal"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A list of client transactions to match",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of tutuka transactions slightly different descriptions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-30000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/12/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call evaluate for each transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItems as Follows",
                "TableArgument": {
                  "HeaderRow": [
                    "MatchType"
                  ],
                  "DataRows": [
                    [
                      "NotMatched"
                    ],
                    [
                      "NotMatched"
                    ],
                    [
                      "NotMatched"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Define PropertyFuzzyMatchRule to fuzzy string match two string fields",
            "Slug": "define-propertyfuzzymatchrule-to-fuzzy-string-match-two-string-fields",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I have a Rule",
                "TableArgument": {
                  "HeaderRow": [
                    "sourceproperty",
                    "targetproperty",
                    "levenshteidistance"
                  ],
                  "DataRows": [
                    [
                      "Narrative",
                      "Narrative",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A list of client transactions to match",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "a list of tutuka transactions slightly different descriptions",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "ProfileName",
                    "Date",
                    "Amount",
                    "Narrative",
                    "Description",
                    "WalletReference",
                    "Type"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "*MLPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ],
                    [
                      "584011808649511",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "REVERSAL",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "1"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call evaluate for each transactions",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItems as Follows",
                "TableArgument": {
                  "HeaderRow": [
                    "MatchType"
                  ],
                  "DataRows": [
                    [
                      "Matched"
                    ],
                    [
                      "Matched"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "RulesEvaluator.feature",
      "Feature": {
        "Name": "RulesEvaluator",
        "Description": "In order to reconcile transactions\r\nAs a user\r\nI want to define rules",
        "FeatureElements": [
          {
            "Name": "Match Ids of two transactions",
            "Slug": "match-ids-of-two-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "two transacions with same Ids",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A rule to match Ids",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Match Dates of two transactions which are within 2 minutes",
            "Slug": "match-dates-of-two-transactions-which-are-within-2-minutes",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "two transacions with same id '584011808649511' and dates '1/11/2014  10:27:00 PM' and '1/11/2014  10:27:44 PM' respectively",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A rule to match Ids and Dates with a delta of 120 seconds",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Match Ids and Amount",
            "Slug": "match-ids-and-amount",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "two transacions with same '584011808649511' and amount -20000",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A rule to match Ids and amount",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Match Ids and But Not Amount",
            "Slug": "match-ids-and-but-not-amount",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "two transacions with same Id '584011808649511' and different amount -20000 and -20002",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A rule to match Ids and amount",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be not matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Examples": [
              {
                "Name": "",
                "TableArgument": {
                  "HeaderRow": [
                    "c_id",
                    "t_id",
                    "c_profilename",
                    "t_profilename",
                    "c_date",
                    "t_date",
                    "c_amount",
                    "t_amount",
                    "c_narrative",
                    "t_narrative",
                    "c_description",
                    "t_description",
                    "c_walletreference",
                    "t_walletreference"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "584011808649511",
                      "Card Campaign",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "1/11/2014  10:27:00 PM",
                      "-20000",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                    ],
                    [
                      "84012233581869",
                      "84012233581869",
                      "Card Campaign",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "1/12/2014  6:26:00 AM",
                      "-20000",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2"
                    ],
                    [
                      "0584012395072004",
                      "0584012395072004",
                      "Card Campaign",
                      "Card Campaign",
                      "2014-01-12 14:58:27",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2"
                    ],
                    [
                      "0164012401925347",
                      "0164012401925347",
                      "Card Campaign",
                      "Card Campaign",
                      "2014-01-12 15:09:52",
                      "2014-01-12 15:09:52",
                      "3880",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1"
                    ]
                  ]
                },
                "Tags": [],
                "NativeKeyword": "Examples"
              }
            ],
            "Name": "Match all the fields of transactions",
            "Slug": "match-all-the-fields-of-transactions",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "ClientTransacion with '<c_id>' '<c_profilename>' '<c_date>' '<c_amount>' '<c_narrative>' '<c_description>' '<c_walletreference>'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "TutukaTransacion with '<t_id>' '<t_profilename>' '<t_date>' '<t_amount>' '<t_narrative>' '<t_description>' '<t_walletreference>'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A ruleset to match all fields of Transaction",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Examples": [
              {
                "Name": "",
                "TableArgument": {
                  "HeaderRow": [
                    "c_id",
                    "t_id",
                    "c_profilename",
                    "t_profilename",
                    "c_date",
                    "t_date",
                    "c_amount",
                    "t_amount",
                    "c_narrative",
                    "t_narrative",
                    "c_description",
                    "t_description",
                    "c_walletreference",
                    "t_walletreference"
                  ],
                  "DataRows": [
                    [
                      "584011808649511",
                      "584011808649511",
                      "Card Campaign",
                      "Card Campaign",
                      "1/11/2014  10:27:00 PM",
                      "1/11/2014  10:27:44 PM",
                      "-20000",
                      "-20000",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "*MOLEPS ATM25             MOLEPOLOLE    BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5",
                      "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
                    ],
                    [
                      "84012233581869",
                      "84012233581869",
                      "Card Campaign",
                      "Card Campaign",
                      "1/12/2014  6:26:00 AM",
                      "1/12/2014  6:26:17 AM",
                      "-20000",
                      "-20000",
                      "Molepolole Filli100558    Gaborone      BW",
                      "Molepolole Filli100558    Gaborone      BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2",
                      "P_NzI5OTE3NjZfMTM4MTkzNjk5Mi45NTc2"
                    ],
                    [
                      "0584012395072004",
                      "0584012395072004",
                      "Card Campaign",
                      "Card Campaign",
                      "2014-01-12 14:58:40",
                      "2014-01-12 14:58:27",
                      "-10000",
                      "-10000",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "MAHALAPYE BRANCH          BOTSWANA      BW",
                      "DEDUCT",
                      "DEDUCT",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2",
                      "P_NzUzMDAzODVfMTM4NzI4MTQ5NC4zNzI2"
                    ],
                    [
                      "0164012401925347",
                      "0164012401925347",
                      "Card Campaign",
                      "Card Campaign",
                      "2014-01-12 15:09:00",
                      "2014-01-12 15:10:20",
                      "3880",
                      "3880",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "370592 ENGEN LOBATSE      BOTSWANA      BW",
                      "REVERSAL",
                      "REVERSAL",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1",
                      "P_NzUzNDA5MjRfMTM4MDg4NDc0OC4yNjA1"
                    ]
                  ]
                },
                "Tags": [],
                "NativeKeyword": "Examples"
              }
            ],
            "Name": "Match all the fields exactly and dates with a delta of 120 seconds",
            "Slug": "match-all-the-fields-exactly-and-dates-with-a-delta-of-120-seconds",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "ClientTransacion with '<c_id>' '<c_profilename>' '<c_date>' '<c_amount>' '<c_narrative>' '<c_description>' '<c_walletreference>'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "TutukaTransacion with '<t_id>' '<t_profilename>' '<t_date>' '<t_amount>' '<t_narrative>' '<t_description>' '<t_walletreference>'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "A ruleset to match all fields exactly and date field with a delta of 120 seconds",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I call Evaluate",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the result should be matched ReconciledItem",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@rules"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    }
  ],
  "Summary": {
    "Tags": [
      {
        "Tag": "@tranascationcompare",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "@transactioncompare",
        "Total": 2,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 2
      },
      {
        "Tag": "@csvparser",
        "Total": 5,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 5
      },
      {
        "Tag": "@reconcileengine",
        "Total": 4,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 4
      },
      {
        "Tag": "@rules",
        "Total": 11,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 11
      }
    ],
    "Folders": [
      {
        "Folder": "TransactionCompare.feature",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      },
      {
        "Folder": "CSVParser.feature",
        "Total": 5,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 5
      },
      {
        "Folder": "ReconcileEngine.feature",
        "Total": 4,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 4
      },
      {
        "Folder": "Rules.feature",
        "Total": 5,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 5
      },
      {
        "Folder": "RulesEvaluator.feature",
        "Total": 6,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 6
      }
    ],
    "NotTestedFolders": [
      {
        "Folder": "TransactionCompare.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "CSVParser.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "ReconcileEngine.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "Rules.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "RulesEvaluator.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      }
    ],
    "Scenarios": {
      "Total": 23,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 23
    },
    "Features": {
      "Total": 5,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 5
    }
  },
  "Configuration": {
    "SutName": "Reconcile",
    "SutVersion": "beta",
    "GeneratedOn": "27 October 2017 11:02:05"
  }
});