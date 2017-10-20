using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using FinReconcile.RuleEngine;
using System;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class RulesEngineSteps
    {

        Transaction trans1, trans2;
        Rule rule;
        private RuleSet _ruleSet;
        IReconcileEngine _reconcileEngine;
        private IReconcileResult _reconciledResult;

        [Given(@"two transacions with same Ids")]
        public void GivenTwoTransacionsWithSameIds()
        {
            trans1 = new Transaction() { Id = "1" };
            trans2 = new Transaction() { Id = "1" };
        }

        [Given(@"A rule to match Ids")]
        public void GivenARuleToMatchIds()
        {
            rule = new Rule("Id", "Equal", "Id");
             _ruleSet = new RuleSet(new Rule[] { rule });
        }


        [When(@"I call Reconcile")]
        public void WhenICallReconcile()
        {
            _reconcileEngine = new ReconcileEngine(_ruleSet);
            _reconciledResult=_reconcileEngine.Reconcile();
        }
        
        [Then(@"the result should be matched ReconciledItem")]
        public void ThenTheResultShouldBeMatchedReconciledItem()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
