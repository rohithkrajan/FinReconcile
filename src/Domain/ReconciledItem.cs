using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Domain
{
    public class ReconciledItem
    {
        public Transaction ClientTransaction { get; set; }
        public Transaction TutukaTransaction { get; set; }
        public ReconciledMatchType MatchType { get; set; }
    }
}