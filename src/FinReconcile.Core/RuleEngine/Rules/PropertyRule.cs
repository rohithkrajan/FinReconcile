using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.Core.Engines.Rules
{
   // this is a simple rule which compares two property values of transaction 
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
        //these values are purposely kept as string to build a Rulebuilder UI
        //We can also add an overload which will allow lambda expressions
        public PropertyRule(string SourceProperty, string Operator, string targetProperty)
        {
            this.SourceProperty = SourceProperty;
            this.Operator = Operator;
            this.TargetProperty = targetProperty;
        }

        public Expression BuildExpression(ParameterExpression source,ParameterExpression target)
        {
         //here it is quite trivail ato add support for other operator like Greaterthan,LessThan etc.
         //currently only Equal is implemented as it was matching the document provided.
            return Expression.Equal(Expression.Property(source, this.SourceProperty),
                Expression.Property(target, this.TargetProperty));
        }
    }
}
