using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class ReconcileEngine:IReconcileEngine
    {
        ParameterExpression transSource = Expression.Parameter(typeof(Transaction), "transactionSource");
        ParameterExpression transTarget= Expression.Parameter(typeof(Transaction), "transactionTarget");

        RuleSet _ruleSet;
        Func<Transaction, Transaction, bool> _compiledRule;

        public ReconcileEngine(RuleSet ruleSet)
        {
            _ruleSet = ruleSet;
            _compiledRule = CompileRule();

        }
         

        private Expression BuildExpression(Rule _rule)
        {
            return Expression.Equal(Expression.Property(transSource, _rule.SourceMember),
                Expression.Property(transSource, _rule.TargetMember));

        }
        public Func<Transaction, Transaction, bool> CompileRule()
        {
            
            Expression finalExpression = null;
            
            for (int i = 0; i < _ruleSet.Rules.Count; i++)
            {
                Expression currentExp = BuildExpression(_ruleSet.Rules[i]);
                
                if (finalExpression != null&&i<=_ruleSet.Rules.Count-1)
                {
                    finalExpression = Expression.AndAlso(finalExpression, currentExp);
                }
                else
                {
                    finalExpression = currentExp;
                }
            }                        

            return Expression.Lambda<Func<Transaction, Transaction, bool>>(finalExpression,
                new ParameterExpression[] { transSource, transTarget }).Compile();
        }

        public IReconcileResult Reconcile(Transaction clientTransaction,Transaction tutukaTransaction)
        {
            bool matched = _compiledRule(clientTransaction, tutukaTransaction);
            ReconciledItem resultItem = new ReconciledItem(clientTransaction, tutukaTransaction, matched ? ReconciledMatchType.Matched : ReconciledMatchType.NotMatched);

            return new ReconcileResult(new ReconciledItem[] { resultItem });
        }
    }
}