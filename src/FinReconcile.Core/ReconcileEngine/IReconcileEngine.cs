using FinReconcile.Core.Domain;
using FinReconcile.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.Core.Engines
{
    public interface IReconcileEngine
    {
        IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> bankTransactions);
        IList<IRuleEvaluator> RuleEvaluators { get; }
    }
}
