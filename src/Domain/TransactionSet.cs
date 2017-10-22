using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Domain
{
    public class TransactionSet
    {
        private List<Transaction> _clientSet;
        private List<Transaction> _tutukaSet;
        private bool _initialized = false;
        public TransactionSet()
        {
            _clientSet = new List<Transaction>();
            _tutukaSet = new List<Transaction>();
        }
        public int Id { get; set; }
        public IEnumerable<Transaction> ClientSet { get { return _clientSet; }  }
        public IEnumerable<Transaction> TutukaSet { get { return _tutukaSet; }  }

        public bool IsReconciled
        {
            get
            {
                if (_initialized)
                {
                    return _clientSet.Count == 0 && _tutukaSet.Count == 0;
                }

                return false;
            } }
        public void AddClientTransaction(Transaction clientTransaction)
        {
            _clientSet.Add(clientTransaction);
            _initialized = true;
        }
        public void AddTutukaTransaction(Transaction tutukaTransaction)
        {
            _tutukaSet.Remove(tutukaTransaction);
            _initialized = true;
        }
        public void RemoveTransactions(Transaction clientTransaction, Transaction tutukaTransaction)
        {
            _clientSet.Remove(clientTransaction);
            _tutukaSet.Remove(tutukaTransaction);         
        }
      
    }
}