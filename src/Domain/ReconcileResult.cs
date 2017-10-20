using FinReconcile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Domain
{
    public class ReconcileResult : IReconcileResult
    {
        private IList<ReconciledItem> _reconciledItems;
        private IList<ReconciledItem> _matchedItems;
        private IList<ReconciledItem> _notMatchedItems;

        public ReconcileResult(IList<ReconciledItem> items)
        {
            _reconciledItems = items;
            _matchedItems = new List<ReconciledItem>();
            _notMatchedItems = new List<ReconciledItem>();
            foreach (var item in _reconciledItems)
            {
                switch (item.MatchType)
                {
                    case ReconciledMatchType.Matched:
                        _matchedItems.Add(item);
                        break;                   
                    case ReconciledMatchType.NotMatched:
                        _notMatchedItems.Add(item);
                        break;                   
                }
            }
        }
        public IEnumerable<ReconciledItem> MatchedItems
        {
            get { return _matchedItems; }
            
        }
        public IEnumerable<ReconciledItem> NotMatchedItems
        {
            get { return _notMatchedItems; }
            
        }
    }
}