using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using FinReconcile.RuleEngine;
using NUnit.Framework;
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
            _reconciledResult=_reconcileEngine.Reconcile(trans1,trans2);
        }
        
        [Then(@"the result should be matched ReconciledItem")]
        public void ThenTheResultShouldBeMatchedReconciledItem()
        {            
            Assert.AreEqual(1, _reconciledResult.MatchedItems.Count);
            Assert.AreEqual(0, _reconciledResult.NotMatchedItems.Count);
            

            Assert.IsTrue(_reconciledResult.MatchedItems[0].MatchType == ReconciledMatchType.Matched);
        }

        [Given(@"two transacions with same Ids\tand amount")]
        public void GivenTwoTransacionsWithSameIdsAndAmount()
        {
            //	-20000	*MOLEPS ATM25             MOLEPOLOLE    BW	DEDUCT	584011808649511	-20000	1	P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5

            trans1 = new Transaction()
            {
                ProfileName= "Card Campaign",
                Date=DateTime.Parse("1/11/2014 22:27"),
                Amount=-20000,
                Narative= "*MOLEPS ATM25             MOLEPOLOLE    BW",
                Description="DEDUCT",
                Type=TransactionType.ATM,
                Id= "584011808649511",
                WalletReference= "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
            
            //Card Campaign		-20000	*MOLEPS ATM25             MOLEPOLOLE    BW	DEDUCT	584011808649511	1	P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5	-20000

            trans2 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = -20000,
                Narative = "MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = "584011808649511",
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
        }

        [Given(@"A rule to match Ids and amount")]
        public void GivenARuleToMatchIdsAndAmount()
        {            
            _ruleSet = new RuleSet(new Rule[] {
                new Rule("Id", "Equal", "Id") ,
                new Rule("Amount", "Equal", "Amount")
            });
        }

        [Given(@"two transacions with same Ids\tand different amount")]
        public void GivenTwoTransacionsWithSameIdsAndDifferentAmount()
        {
            trans1 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = -20000,
                Narative = "*MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = "584011808649511",
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
            trans2 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = -20002,
                Narative = "MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = "584011808649511",
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
        }

        [Then(@"the result should be not matched ReconciledItem")]
        public void ThenTheResultShouldBeNotMatchedReconciledItem()
        {
            Assert.AreEqual(1, _reconciledResult.NotMatchedItems.Count);
            Assert.IsTrue(_reconciledResult.MatchedItems[0].MatchType == ReconciledMatchType.NotMatched);
        }


    }
}
