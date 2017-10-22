using FinReconcile.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.Domain.Interfaces
{
    public interface IRuleEngine
    {
        ReconciledItem Evaluate(Transaction clientTransaction,Transaction tutukaTransaction);
    }
}
