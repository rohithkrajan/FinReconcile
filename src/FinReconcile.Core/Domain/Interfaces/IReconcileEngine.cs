using FinReconcile.Core.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.Core.Domain.Interfaces
{
    public interface IRuleEvaluator
    {
        ReconciledItem Evaluate(Transaction clientTransaction,Transaction bankTransaction);
        string RuleName { get; }
        ReconciledMatchType RuleType { get; }
        RuleSet RuleSet { get; }
    }
}
