using System.Collections.Generic;

namespace FinReconcile.Domain.Interfaces
{
    public interface IReconcileResult
    {
        IEnumerable<ReconciledItem> MatchedItems { get; }
        IEnumerable<ReconciledItem> NotMatchedItems { get;  }
    }
}