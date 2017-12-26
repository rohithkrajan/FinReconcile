using FinConcile.Tests.Properties;
using FinReconcile.Infra.Parsers;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class CSVParserSteps
    {
        IMarkOffFileParser _csvParser;
        string _content = string.Empty;
        ParserResult _parserResult;
        Table _contentTable;
        [BeforeScenario]
        public void InitScenario()
        {
            _csvParser = new CSVMarkOffFileParser();
        }

        [Given(@"a markofffile\twith content")]
        public void GivenAMarkofffileWithContent(Table table)
        {
            _contentTable = table;
            StringBuilder content = new StringBuilder();
            foreach (var row in table.Rows)
            {
                content.AppendLine(row[0]);
            }
            _content = content.ToString();
        }

        [When(@"I call GetRecords")]
        public void WhenICallGetRecords()
        {
            _parserResult= _csvParser.GetRecords(_content);
        }

        [Then(@"the result should be (.*) transactions")]
        public void ThenTheResultShouldBeTransactions(int parsedTransactionsCount)
        {
            Assert.AreEqual(parsedTransactionsCount, _parserResult.Count);
        }

        [Then(@"(.*) Invalid Entries")]
        public void ThenInvalidEntries(int invalidEntriesCount)
        {
            Assert.AreEqual(invalidEntriesCount, _parserResult.InvalidEntries.Count);
           
        }
        [Then(@"Invalid entries matches line numbers (.*) and (.*)")]
        public void ThenInvalidEntriesMatchesLineNumbersAnd(int p0, int p1)
        {
            Assert.AreEqual(_contentTable.Rows[2][0].Trim(), _parserResult.InvalidEntries[p0].Trim());
            Assert.AreEqual(_contentTable.Rows[3][0].Trim(), _parserResult.InvalidEntries[p1].Trim());
        }

        

        [Given(@"a large client markofffile with content")]
        public void GivenALargeMarkofffileWithContent()
        {
            _content = Resources.ClientMarkoffFile20140113;
        }

        [Given(@"a large bank markofffile with content")]
        public void GivenALargeBankMarkofffileWithContent()
        {
            _content = Resources.BankMarkoffFile20140113;
        }

        [When(@"I call Validate")]
        public void WhenICallValidate()
        {
            _parserResult = _csvParser.GetRecords(_content);
        }

        [Then(@"the result should be valid file")]
        public void ThenTheResultShouldBeValidFile()
        {
            Assert.IsTrue(_parserResult.IsValid);
        }

        [Then(@"the result should be invalid file")]
        public void ThenTheResultShouldBeInvalidFile()
        {
            Assert.IsFalse(_parserResult.IsValid);
            Assert.AreEqual(_parserResult.Errors.Count, 1);
            
        }

        
        [Then(@"Error Message should contain headername '(.*)' with LineNo (.*)")]
        public void ThenErrorMessageShouldContainHeadernameWithLineNo(string headerName, int lineno)
        {
            Assert.IsTrue(_parserResult.Errors[lineno].Contains(headerName));
        }

        [Then(@"Error Messages should contain headername '(.*)' and '(.*)' with LineNo (.*)")]
        public void ThenErrorMessagesShouldContainHeadernameAndWithLineNo(string header1, string header2, int linenum)
        {
            Assert.IsTrue(_parserResult.Errors[linenum].Contains(header1));
            Assert.IsTrue(_parserResult.Errors[linenum].Contains(header2));
        }

        [Then(@"with (.*) Transactions and No Errors")]
        public void ThenWithTransactionsAndNoErrors(int transCount)
        {
            Assert.AreEqual(transCount, _parserResult.Count);
            Assert.AreEqual(0, _parserResult.Errors.Count);
        }



    }
}
