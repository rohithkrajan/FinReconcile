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
        [Then(@"Invalid entries matches last two rows")]
        public void ThenInvalidEntriesMatchesLastTwoRows()
        {
            Assert.AreEqual(_contentTable.Rows[2][0].Trim(), _parserResult.InvalidEntries[0].Trim());
            Assert.AreEqual(_contentTable.Rows[3][0].Trim(), _parserResult.InvalidEntries[1].Trim());
        }

        [Given(@"a large client markofffile with content")]
        public void GivenALargeMarkofffileWithContent()
        {
            _content = Resources.ClientMarkoffFile20140113;
        }

        [Given(@"a large tutuka markofffile with content")]
        public void GivenALargeTutukaMarkofffileWithContent()
        {
            _content = Resources.TutukaMarkoffFile20140113;
        }



    }
}
