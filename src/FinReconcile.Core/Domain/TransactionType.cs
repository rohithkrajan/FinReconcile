using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Core.Domain
{
    public enum TransactionType
    {
        Store = 0,
        ATM =1,       
        Unknown=9
    }
}