using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Core.Domain
{
    public class TransactionSet
    {
        private List<Transaction> _clientSet;
        private List<Transaction> _bankSet;
        private bool _initialized = false;
        public TransactionSet()
        {
            _clientSet = new List<Transaction>();
            _bankSet = new List<Transaction>();
        }
        public int Id { get; set; }
        public IEnumerable<Transaction> ClientSet { get { return _clientSet; }  }
        public IEnumerable<Transaction> BankSet { get { return _bankSet; }  }

        public bool IsReconciled
        {
            get
            {
                if (_initialized)
                {
                    return _clientSet.Count == 0 && _bankSet.Count == 0;
                }

                return false;
            }
        }
        
        public void AddClientTransaction(Transaction clientTransaction)
        {
            _clientSet.Add(clientTransaction);
            _initialized = true;
        }
        public void AddBankTransaction(Transaction bankTransaction)
        {
            _bankSet.Add(bankTransaction);
            _initialized = true;
        }
        public void RemoveTransactions(Transaction clientTransaction, Transaction bankTransaction)
        {
            _clientSet.Remove(clientTransaction);
            _bankSet.Remove(bankTransaction);         
        }
      
    }
}