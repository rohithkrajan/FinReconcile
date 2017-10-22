using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine.Rules
{
    public class DateMatchWithDeltaRule : IRule
    {
        private double _delta;

        public DateMatchWithDeltaRule(double delta)
        {
            _delta = delta;
        }
        private  string PropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body.Member.Name;
        }

        public Expression BuildExpression(ParameterExpression source, ParameterExpression target)
        {
            var tMethod = this.GetType().GetMethod("CompareDateWithDelta");
            
            return Expression.Call(tMethod, source, target,Expression.Constant(_delta));

        }
        public static bool CompareDateWithDelta(Transaction source,Transaction target,double delta)
        {
            if (source.Date==target.Date)
            {
                return true;
            }
            else
            {
                if (source.Date>target.Date)
                {
                    return TimeSpan.FromSeconds(delta) >= (source.Date - target.Date);
                }
                else
                {
                    return TimeSpan.FromSeconds(delta) >= (target.Date - source.Date);
                }
                
            }

        }


        //This method returns an expression as follows
        //(DateTime c, DateTime t) => { 
        // if(c==t) return true
        // else if(c>t)return (TimeSpan.FromSeconds(120) > (c - t)); 
        //else return (TimeSpan.FromSeconds(120) > (t - c)};
        //what this does is minus the date field of Transaction and 
        public Expression BuildExpression(ParameterExpression source, ParameterExpression target,int t)
        {

            ParameterExpression result = Expression.Parameter(typeof(bool), "result");

            LabelTarget label = Expression.Label(typeof(bool));


            string datePropertyName = PropertyName<Transaction>(x => x.Date);  

            // if(source==target) 
            Expression ifEqualExpression = Expression.Equal(Expression.Property(source, datePropertyName),Expression.Property(target, datePropertyName));
            //if(source>target)
            Expression IfGreaterExpr= Expression.GreaterThan(Expression.Property(source, datePropertyName),Expression.Property(target, datePropertyName));
            //if(target>source)
            Expression elseExpr = Expression.GreaterThan(Expression.Property(target, datePropertyName), Expression.Property(source, datePropertyName));

            Expression substractSourceMinusTargetExp = Expression.Subtract(Expression.Property(source, datePropertyName), Expression.Property(target, datePropertyName));

            Expression substractTargetMinusSourceExp = Expression.Subtract(Expression.Property(target, datePropertyName), Expression.Property(source, datePropertyName));

            Expression methodBody= Expression.IfThenElse(
                ifEqualExpression,//if(source==target)
                    Expression.Assign(result, Expression.Constant(true)), //result==true
                Expression.IfThenElse(IfGreaterExpr, //if(source>target)
                    Expression.Assign(result,Expression.LessThanOrEqual(Expression.Constant(TimeSpan.FromSeconds(_delta)), substractSourceMinusTargetExp)), //TimeSpan.FromSeconds(120) <= (source - target)
                    Expression.Assign(result,Expression.LessThanOrEqual(Expression.Constant(TimeSpan.FromSeconds(_delta)), substractTargetMinusSourceExp))//TimeSpan.FromSeconds(120) <= (target - source)
             ));
            // Creating a method body.  
            BlockExpression methodExpression = Expression.Block(typeof(bool),new ParameterExpression[] { source, target,result }, methodBody, Expression.Break(label, result));
            
            return methodExpression;
        }
    }
}