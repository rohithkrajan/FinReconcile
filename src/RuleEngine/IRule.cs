using System.Linq.Expressions;

namespace FinReconcile.RuleEngine
{
    public interface IRule
    {        
        Expression BuildExpression(ParameterExpression source, ParameterExpression target);
    }
}