using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine.Rules
{
    public class PropertyMatchRule:IRule
    {
        public string SourceMember
        {
            get;
            set;
        }

        public string Operator
        {
            get;
            set;
        }

        public string TargetMember
        {
            get;
            set;
        }

        public PropertyMatchRule(string SourceMember, string Operator, string TargetMember)
        {
            this.SourceMember = SourceMember;
            this.Operator = Operator;
            this.TargetMember = TargetMember;
        }

        public Expression BuildExpression(ParameterExpression source,ParameterExpression target)
        {
            return Expression.Equal(Expression.Property(source, this.SourceMember),
                Expression.Property(target, this.TargetMember));
        }
    }
}