using System.Linq.Expressions;

namespace FinReconcile.Core.Engines
{
    public interface IRule
    {        
        Expression BuildExpression(ParameterExpression source, ParameterExpression target);
    }
}