using FinReconcile.Core.Domain;
using FinReconcile.Core.Domain.Interfaces;
using FinReconcile.Core.Engines;
using FinReconcile.Core.Engines.Rules;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class RulesEvaluatorSteps
    {

        Transaction trans1, trans2;
        IRule rule;
        private RuleSet _ruleSet;
        IRuleEvaluator _reconcileEngine;
        private ReconciledItem _reconciledResult;

        [Given(@"two transacions with same Ids")]
        public void GivenTwoTransacionsWithSameIds()
        {
            trans1 = new Transaction() { Id = "1" };
            trans2 = new Transaction() { Id = "1" };
        }

        [Given(@"A rule to match Ids")]
        public void GivenARuleToMatchIds()
        {
            rule = new PropertyRule("Id", "Equal", "Id");
             _ruleSet = new RuleSet(new IRule[] { rule });
        }


        [When(@"I call Evaluate")]
        public void WhenICallReconcile()
        {
            _reconcileEngine = new RuleSetEvaluator(_ruleSet);
            _reconciledResult=_reconcileEngine.Evaluate(trans1,trans2);
        }
        
        [Then(@"the result should be matched ReconciledItem")]
        public void ThenTheResultShouldBeMatchedReconciledItem()
        {   
            Assert.IsTrue(_reconciledResult.MatchType == ReconciledMatchType.Matched);
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
            _ruleSet = new RuleSet(new PropertyRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount")
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
            Assert.IsTrue(_reconciledResult.MatchType == ReconciledMatchType.NotMatched);
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

        [Given(@"BankTransacion with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenBankTransacionWith(string id, string profileName, string date, string amount, string narrative, string description, string walletReference)
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
            _ruleSet = new RuleSet(new PropertyRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new PropertyRule("Date", "Equal", "Date")
            });
        }

        [Given(@"A ruleset to match all fields exactly and date field with a delta of (.*) seconds")]
        public void GivenARulesetToMatchAllFieldsExactlyAndDateFieldWithADeltaOfSeconds(int seconds)
        {
            _ruleSet = new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new DateRule(seconds)
            });
        }

        [Given(@"two transacions with same id '(.*)' and dates '(.*)' and '(.*)' respectively")]
        public void GivenTwoTransacionsWithSameIdAndDatesAndRespectively(string id, string clientDate, string bankDate)
        {
            trans1 = new Transaction()
            {                
                Date = DateTime.Parse(clientDate),              
                Id = id               
            };
            trans2 = new Transaction()
            {                
                Date = DateTime.Parse(bankDate),                
                Id = "584011808649511"                
            };
        }

        [Given(@"A rule to match Ids and Dates with a delta of (.*) seconds")]
        public void GivenARuleToMatchIdsAndDatesWithADeltaOfSeconds(int deltaSeconds)
        {
            _ruleSet = new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,               
                new DateRule(deltaSeconds)
            });
        }

    }
}
