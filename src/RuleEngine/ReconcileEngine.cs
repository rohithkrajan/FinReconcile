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

        List<Rule> _rules = new List<Rule>();

        public ReconcileEngine(params Rule[] rules)
        {
            _rules.AddRange(rules);
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

        public IReconcileResult Reconcile()
        {
            throw new NotImplementedException();
        }
    }
}