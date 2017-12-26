using System;
using TechTalk.SpecFlow;
using FinConcile.Tests.TestUtils;
using System.Collections.Generic;
using NUnit.Framework;
using FinReconcile.Core.Domain;
using FinReconcile.Core.Engines;
using FinReconcile.Core.Domain.Interfaces;
using FinReconcile.Core.Engines.Rules;

namespace FinConcile.Tests
{
    [Binding]
    public class ReconcileEngineSteps
    {
        private IEnumerable<Transaction> _clientTransactions;
        private IEnumerable<Transaction> _bankTransactions;
        private IReconcileEngine _reconcileEngine;
        private IReconcileResult _result;
        IRule rule;
        private RuleSet _ruleSet;
        IList<IRuleEvaluator> _ruleEvaluators = new List<IRuleEvaluator>();

        [Given(@"A list of Client transactions")]
        public void GivenAListOfClientTransactions(Table table)
        {
             _clientTransactions = table.GetTransactions();
        }
        
        [Given(@"a list of matching Bank Transactions")]
        public void GivenAListOfMatchingBankTransactions(Table table)
        {
            _bankTransactions = table.GetTransactions();
        }

        [Given(@"a list of Bank Transactions")]
        public void GivenAListOfBankTransactions(Table table)
        {
            _bankTransactions = table.GetTransactions();
        }

        [Given(@"a RuleSet With PropertyRules")]
        public void GivenARuleSetWithPropertyRules(Table table)
        {
            _ruleSet = new RuleSet();
            foreach (var row in table.Rows)
            {
                rule = new PropertyRule(row["SourceProperty"], row["Operator"], row["TargetProperty"]);
                _ruleSet.Rules.Add(rule);
            }
            _ruleEvaluators.Add(new RuleSetEvaluator(_ruleSet));
        }


        [When(@"I call Reconcile")]
        public void WhenICallReconcile()
        {
            _reconcileEngine = new ReconcileEngine(_ruleEvaluators);
            _result= _reconcileEngine.Reconcile(_clientTransactions, _bankTransactions);
        }
        
        [Then(@"the result should be (.*) Matched ReconciledItem")]
        public void ThenTheResultShouldBeMatchedReconciledItem(int matchedCount)
        {
            Assert.AreEqual(matchedCount, _result.MatchedItems.Count);
            Assert.AreEqual(0, _result.NotMatchedItems.Count);
        }

        [Given(@"a list of Non matching Bank Transactions With Different Ids")]
        public void GivenAListOfNonMatchingBankTransactionsWithDifferentIds(Table table)
        {
            _bankTransactions = table.GetTransactions();
        }
   

        [Then(@"the reconciled result should be (.*) Matched Client Transactions (.*) Unmatched Client transactions")]
        public void ThenTheReconciledResultShouldBeMatchedClientTransactionsUnmatchedClientTransactions(int matchedCount, int nonMatchedCount)
        {
            Assert.AreEqual(matchedCount, _result.GetMatchedClientTransactions().Count);
            Assert.AreEqual(nonMatchedCount, _result.GetUnMatchedClientTransactions().Count);
        }

        [Then(@"(.*) Matched Bank Transactions (.*) Unmatched Bank transactions")]
        public void ThenMatchedBankTransactionsUnmatchedBankTransactions(int matchedCount, int nonMatchedCount)
        {
            Assert.AreEqual(matchedCount, _result.GetMatchedBankTransactions().Count);
            Assert.AreEqual(nonMatchedCount, _result.GetUnMatchedBankTransactions().Count);
        }


        [Then(@"the result should be (.*) Matched ReconciledItems and (.*) Non Matched ReconciledItems")]
        public void ThenTheResultShouldBeMatchedReconciledItemsAndNonMatchedReconciledItems(int matched, int notMatched)
        {
            Assert.AreEqual(matched, _result.MatchedItems.Count);
            Assert.AreEqual(notMatched, _result.NotMatchedItems.Count);
        }

        [Then(@"the result should (.*) Matched ReconciledItem")]
        public void ThenTheResultShouldMatchedReconciledItem(int matched)
        {
            Assert.AreEqual(matched, _result.MatchedItems.Count);
        }



    }
}
