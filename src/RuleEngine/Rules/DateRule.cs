using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine.Rules
{
    /// <summary>
    /// This Rule can match dates if if they are different within the allowed delta value
    /// </summary>
    public class DateRule : MethodBaseRule<double>
    {        

        public DateRule(double delta):base(CompareDateWithDelta)
        {
            constantArgument = delta;
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

        
    }
}