using FinConcile.Tests.TestUtils;
using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using FinReconcile.ReconcileEngine;
using FinReconcile.RuleEngine;
using FinReconcile.RuleEngine.Rules;
using NUnit.Framework;
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
        private IList<ReconciledItem> _reconciledResult = new List<ReconciledItem>();

        [Given(@"a set of PropertyRules")]
        public void GivenASetOfPropertyRules(Table table)
        {
            _ruleSet = new RuleSet();
            foreach (var row in table.Rows)
            {
                rule = new PropertyRule(row["SourceProperty"], row["Operator"], row["TargetProperty"]);
                _ruleSet.Rules.Add(rule);
            }
        }

        [Given(@"a DateRule with Delta\tof (.*) seconds")]
        public void GivenADateRuleWithDeltaOfSeconds(int delta)
        {
            _ruleSet = new RuleSet();
            _ruleSet.Rules.Add(new DateRule(delta));
        }


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
                _reconciledResult.Add(_evaluator.Evaluate(_clientTransactions[i], _tutukaTransactions[i]));
            }
            
        }

        [Then(@"the result should be matched ReconciledItems as Follows")]
        public void ThenTheResultShouldBeMatchedReconciledItemsAsFollows(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                Assert.AreEqual(Enum.Parse(typeof(ReconciledMatchType), table.Rows[i]["MatchType"]), _reconciledResult[i].MatchType);
            }
        }

    }
}
