using FinReconcile.Core.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.Core.Engines.Rules
{
    public abstract class MethodBaseRule : IRule
    {
        Func<Transaction, Transaction, bool> _factoryMethod;

        public MethodBaseRule(Func<Transaction, Transaction, bool> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public Expression BuildExpression(ParameterExpression source, ParameterExpression target)
        {
            return Expression.Call(_factoryMethod.Method, source, target);

        }
    }
    public abstract class MethodBaseRule<T>  : IRule
    {
        protected T constantArgument = default(T);

        Func<Transaction, Transaction, T, bool> _factoryMethod;

        public MethodBaseRule(Func<Transaction,Transaction,T,bool> factoryMethod)
        {
            _factoryMethod = factoryMethod;            
        }     

        public Expression BuildExpression(ParameterExpression source, ParameterExpression target)
        {
            return Expression.Call(_factoryMethod.Method, source, target, Expression.Constant(constantArgument));

        }
    }
}