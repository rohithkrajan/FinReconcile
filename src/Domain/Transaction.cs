using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Domain
{
    public class Transaction
    {
        public string ProfileName { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public string Narative { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public TransactionType Type { get; set; }

        public string WalletReference { get; set; }

    }
}