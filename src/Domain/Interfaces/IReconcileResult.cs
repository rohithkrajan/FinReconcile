using System.Collections.Generic;

namespace FinReconcile.Domain.Interfaces
{
    public interface IReconcileResult
    {
        IList<ReconciledItem> MatchedItems { get; }
        IList<ReconciledItem> NotMatchedItems { get;  }
    }
}