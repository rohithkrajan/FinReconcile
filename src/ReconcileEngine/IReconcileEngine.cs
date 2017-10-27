using FinReconcile.Domain;
using FinReconcile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.ReconcileEngine
{
    public interface IReconcileEngine
    {
        IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> tutukaTransactions);
        IList<IRuleEvaluator> RuleEvaluators { get; }
    }
}
