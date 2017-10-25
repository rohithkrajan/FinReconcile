using FinConcile.Tests.TestUtils;
using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using FinReconcile.ReconcileEngine;
using FinReconcile.RuleEngine;
using FinReconcile.RuleEngine.Rules;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class RulesSteps
    {
        private IList<Transaction> _clientTransactions;
        private IList<Transaction> _tutukaTransactions;
        private IReconcileEngine _reconcileEngine;
        private IReconcileResult _result;
        private IRule rule;
        private RuleSet _ruleSet;
        private RuleSetEvaluator _evaluator;
        private ReconciledItem _reconciledResult;

        [Given(@"I have a Rule")]
        public void GivenIHaveARule(Table table)
        {
            rule = new PropertyFuzzyMatchRule(table.Rows[0][0], table.Rows[0][1], Convert.ToInt32(table.Rows[0][2]));
            _ruleSet = new RuleSet(new IRule[] { rule });
        }

        [Given(@"A list of client transactions to match")]
        public void GivenAListOfClientTransactions(Table table)
        {
            _clientTransactions = table.GetTransactions();
        }
        [Given(@"a list of tutuka transactions slightly different descriptions")]
        public void GivenAListOfMatchingTutukaTransactions(Table table)
        {
            _tutukaTransactions = table.GetTransactions();
        }

        [When(@"I call evaluate for each transactions")]       
        public void WhenICallEvaulate()
        {
            _evaluator = new RuleSetEvaluator(_ruleSet);
            for (int i = 0; i < _clientTransactions.Count; i++)
            {
                _reconciledResult = _evaluator.Evaluate(_clientTransactions[i], _tutukaTransactions[i]);
            }
            
        }
    }
}
