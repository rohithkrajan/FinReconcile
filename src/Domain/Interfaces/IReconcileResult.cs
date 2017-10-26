using System.Collections.Generic;

namespace FinReconcile.Domain.Interfaces
{
    public interface IReconcileResult
    {
        
        IList<ReconciledItem> MatchedItems { get; }
        IList<ReconciledItem> NotMatchedItems { get;  }
        void AddItems(IEnumerable<ReconciledItem> items);
        void Add(ReconciledItem item);
        IList<Transaction> GetMatchedClientTransactions();
        IList<Transaction> GetMatchedTutukaTransactions();
        IList<Transaction> GetUnMatchedClientTransactions();
        IList<Transaction> GetUnMatchedTutukaTransactions();
    }
}