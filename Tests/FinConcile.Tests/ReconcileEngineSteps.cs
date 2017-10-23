using System;
using TechTalk.SpecFlow;
using FinConcile.Tests.TestUtils;
using FinReconcile.Domain;
using System.Collections.Generic;
using FinReconcile.ReconcileEngine;
using FinReconcile.Domain.Interfaces;
using NUnit.Framework;

namespace FinConcile.Tests
{
    [Binding]
    public class ReconcileEngineSteps
    {
        private IEnumerable<Transaction> _clientTransactions;
        private IEnumerable<Transaction> _tutukaTransactions;
        private IReconcileEngine _reconcileEngine;
        private IReconcileResult _result;

        [Given(@"A list of Client transactions")]
        public void GivenAListOfClientTransactions(Table table)
        {
             _clientTransactions = table.GetTransactions();
        }
        
        [Given(@"a list of matching Tutuka Transactions")]
        public void GivenAListOfMatchingTutukaTransactions(Table table)
        {
            _tutukaTransactions = table.GetTransactions();
        }
        
        [When(@"I call Reconcile")]
        public void WhenICallReconcile()
        {
            _reconcileEngine = new ReconcileEngine();
            _result= _reconcileEngine.Reconcile(_clientTransactions, _tutukaTransactions);
        }
        
        [Then(@"the result should be (.*) Matched ReconciledItem")]
        public void ThenTheResultShouldBeMatchedReconciledItem(int matchedCount)
        {
            Assert.AreEqual(matchedCount, _result.MatchedItems.Count);
            Assert.AreEqual(0, _result.NotMatchedItems.Count);
        }
    }
}
