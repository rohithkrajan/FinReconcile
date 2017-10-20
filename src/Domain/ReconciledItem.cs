using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Domain
{
    public class ReconciledItem
    {
        public ReconciledItem(Transaction clientTrans,Transaction tutukaTrans,ReconciledMatchType matchedType)
        {
            ClientTransaction = clientTrans;
            TutukaTransaction = tutukaTrans;
            MatchType = matchedType;
        }
        public Transaction ClientTransaction { get; private set; }
        public Transaction TutukaTransaction { get; private set; }
        public ReconciledMatchType MatchType { get; private set; }
    }
}