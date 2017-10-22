using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using FinReconcile.RuleEngine;
using FinReconcile.RuleEngine.Rules;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class RulesEngineSteps
    {

        Transaction trans1, trans2;
        IRule rule;
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
            rule = new PropertyMatchRule("Id", "Equal", "Id");
             _ruleSet = new RuleSet(new IRule[] { rule });
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

        [Given(@"two transacions with same '(.*)' and amount (.*)")]
        public void GivenTwoTransacionsWithSameAndAmount(string id, int amount)
        {
            trans1 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = amount,
                Narrative = "*MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = id,
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };

            //Card Campaign		-20000	*MOLEPS ATM25             MOLEPOLOLE    BW	DEDUCT	584011808649511	1	P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5	-20000

            trans2 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = amount,
                Narrative = "MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = "584011808649511",
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
        }        

        [Given(@"A rule to match Ids and amount")]
        public void GivenARuleToMatchIdsAndAmount()
        {            
            _ruleSet = new RuleSet(new PropertyMatchRule[] {
                new PropertyMatchRule("Id", "Equal", "Id") ,
                new PropertyMatchRule("Amount", "Equal", "Amount")
            });
        }

        [Given(@"two transacions with same Id '(.*)' and different amount (.*) and (.*)")]
        public void GivenTwoTransacionsWithSameIdAndDifferentAmountAnd(string id, int amount1, int amount2)
        {
            trans1 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = amount1,
                Narrative = "*MOLEPS ATM25             MOLEPOLOLE    BW",
                Description = "DEDUCT",
                Type = TransactionType.ATM,
                Id = id,
                WalletReference = "P_NzI2ODY2ODlfMTM4MjcwMTU2NS45MzA5"
            };
            trans2 = new Transaction()
            {
                ProfileName = "Card Campaign",
                Date = DateTime.Parse("1/11/2014 22:27"),
                Amount = amount2,
                Narrative = "MOLEPS ATM25             MOLEPOLOLE    BW",
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
            Assert.IsTrue(_reconciledResult.NotMatchedItems[0].MatchType == ReconciledMatchType.NotMatched);
        }

      

      
        [Given(@"ClientTransacion with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenClientTransacionWith(string id, string profileName, string date, string amount, string narrative, string description, string walletReference)
        {
            trans1 = new Transaction()
            {
                ProfileName = profileName,
                Date = DateTime.Parse(date),
                Amount = Int64.Parse(amount),
                Narrative = narrative,
                Description = description,
                Type = TransactionType.ATM,
                Id = id,
                WalletReference = walletReference
            };
        }

        [Given(@"TutukaTransacion with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenTutukaTransacionWith(string id, string profileName, string date, string amount, string narrative, string description, string walletReference)
        {
            trans2 = new Transaction()
            {
                ProfileName = profileName,
                Date = DateTime.Parse(date),
                Amount = Int64.Parse(amount),
                Narrative = narrative,
                Description = description,
                Type = TransactionType.ATM,
                Id = id,
                WalletReference = walletReference
            };
        }
        [Given(@"A ruleset to match all fields of Transaction")]
        public void GivenARulesetToMatchAllFieldsOfTransaction()
        {
            _ruleSet = new RuleSet(new PropertyMatchRule[] {
                new PropertyMatchRule("Id", "Equal", "Id") ,
                new PropertyMatchRule("Amount", "Equal", "Amount"),
                new PropertyMatchRule("ProfileName", "Equal", "ProfileName"),
                new PropertyMatchRule("Description", "Equal", "Description"),
                new PropertyMatchRule("Narrative", "Equal", "Narrative"),
                new PropertyMatchRule("WalletReference", "Equal", "WalletReference"),
                new PropertyMatchRule("Date", "Equal", "Date")
            });
        }

        [Given(@"A ruleset to match all fields exactly and date field with a delta of (.*) seconds")]
        public void GivenARulesetToMatchAllFieldsExactlyAndDateFieldWithADeltaOfSeconds(int seconds)
        {
            _ruleSet = new RuleSet(new IRule[] {
                new PropertyMatchRule("Id", "Equal", "Id") ,
                new PropertyMatchRule("Amount", "Equal", "Amount"),
                new PropertyMatchRule("ProfileName", "Equal", "ProfileName"),
                new PropertyMatchRule("Description", "Equal", "Description"),
                new PropertyMatchRule("Narrative", "Equal", "Narrative"),
                new PropertyMatchRule("WalletReference", "Equal", "WalletReference"),
                new PropertyMatchRule("Date", "Equal", "Date")
            });
        }

        [Given(@"two transacions with same id '(.*)' and dates '(.*)' and '(.*)' respectively")]
        public void GivenTwoTransacionsWithSameIdAndDatesAndRespectively(string id, string clientDate, string tutukaDate)
        {
            trans1 = new Transaction()
            {                
                Date = DateTime.Parse(clientDate),              
                Id = id               
            };
            trans2 = new Transaction()
            {                
                Date = DateTime.Parse(tutukaDate),                
                Id = "584011808649511"                
            };
        }

        [Given(@"A rule to match Ids and Dates with a delta of (.*) seconds")]
        public void GivenARuleToMatchIdsAndDatesWithADeltaOfSeconds(int deltaSeconds)
        {
            _ruleSet = new RuleSet(new IRule[] {
                new PropertyMatchRule("Id", "Equal", "Id") ,               
                new DateMatchWithDeltaRule(deltaSeconds)
            });
        }

    }
}
