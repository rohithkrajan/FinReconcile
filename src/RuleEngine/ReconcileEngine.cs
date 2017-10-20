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
        ParameterExpression transParam = Expression.Parameter(typeof(Transaction), "transactionSource");

        RuleSet _ruleSet;

        public ReconcileEngine(RuleSet ruleSet)
        {
            _ruleSet = ruleSet;
        }
        Rule _command = new Rule("Id", "Equal", "Id");

        private Expression BuildExpression()
        {
            return Expression.Equal(Expression.Property(transParam, _command.SourceMember),
                Expression.Property(transParam, _command.TargetMember));

        }
        public Func<Transaction, Transaction, bool> CompileRule()
        {
            var finalExpression = BuildExpression();

            return Expression.Lambda<Func<Transaction, Transaction, bool>>(finalExpression,
                new ParameterExpression[] { transParam, transParam }).Compile();
        }

        public IReconcileResult Reconcile(Transaction clientTransaction,Transaction tutukaTransaction)
        {
            
        }
    }
}