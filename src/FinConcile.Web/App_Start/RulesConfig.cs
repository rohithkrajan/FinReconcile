using FinReconcile.Core.Domain;
using FinReconcile.Core.Domain.Interfaces;
using FinReconcile.Core.Engines;
using FinReconcile.Core.Engines.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.App_Start
{
    public static class RulesConfig
    {
        public static IList<IRuleEvaluator> RegisteredRules()
        {
            IList<IRuleEvaluator> _ruleSetEvaulators = new List<IRuleEvaluator>();
            _ruleSetEvaulators.Add(new RuleSetEvaluator("MatchAllFields", new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new PropertyRule("Date", "Equal", "Date")
                }), ReconciledMatchType.Matched));

            _ruleSetEvaulators.Add(new RuleSetEvaluator("MatchDateWithDeltaof120SecondsAndAllOtherFields", new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new DateRule(120)
                }), ReconciledMatchType.Matched));

            _ruleSetEvaulators.Add(new RuleSetEvaluator("DefaultRule", new RuleSet(new IRule[] {
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new DateRule(120)
                }), ReconciledMatchType.Matched));

            return _ruleSetEvaulators;
        }
    }
}