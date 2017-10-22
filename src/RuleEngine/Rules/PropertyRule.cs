using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine.Rules
{
    public class PropertyRule:IRule
    {
        public string SourceProperty
        {
            get;
            set;
        }

        public string Operator
        {
            get;
            set;
        }

        public string TargetProperty
        {
            get;
            set;
        }

        public PropertyRule(string SourceProperty, string Operator, string targetProperty)
        {
            this.SourceProperty = SourceProperty;
            this.Operator = Operator;
            this.TargetProperty = targetProperty;
        }

        public Expression BuildExpression(ParameterExpression source,ParameterExpression target)
        {
            return Expression.Equal(Expression.Property(source, this.SourceProperty),
                Expression.Property(target, this.TargetProperty));
        }
    }
}