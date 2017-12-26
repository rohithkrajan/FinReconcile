using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Core.Domain
{
    public class ReconciledItem
    {        
        public ReconciledItem(Transaction clientTrans,Transaction bankTrans,ReconciledMatchType matchedType)
        {
            _clientTransaction = clientTrans;
            _bankTransaction = bankTrans;
            MatchType = matchedType;
        }
        public ReconciledItem(TransactionSet transSet, ReconciledMatchType matchedType)
        {
            _resultSet = transSet;
            MatchType = matchedType;
        }
        public Transaction ClientTransaction
        {
            get
            {
                if (_clientTransaction != null)
                {
                    return _clientTransaction;
                }
                else
                {
                    if (_resultSet != null && _resultSet.ClientSet != null )
                    {
                        return _resultSet.ClientSet.FirstOrDefault();
                    }
                    return null;
                }
            }
        }
        public Transaction BankTransaction
        {
            get
            {
                if (_bankTransaction != null)
                {
                    return _bankTransaction;
                }
                else
                {
                    if (_resultSet != null && _resultSet.BankSet != null )
                    {
                        return _resultSet.BankSet.FirstOrDefault();
                    }
                    return null;
                }
            }
        }
        public IEnumerable<Transaction> GetAllClientTransactions()
        {
            if (_resultSet==null&& ClientTransaction!=null)
            {
                return new Transaction[] { ClientTransaction };
            }
            else
            {
                return _resultSet.ClientSet;
            }
        }
        public IEnumerable<Transaction> GetAllBankTransactions()
        {
            if (_resultSet == null&& BankTransaction!=null)
            {
                return new Transaction[] { BankTransaction };
            }
            else
            {
                return _resultSet.BankSet;
            }
        }

        private Transaction _clientTransaction;
        private Transaction _bankTransaction;
        private TransactionSet _resultSet;

        public ReconciledMatchType MatchType { get; private set; }
        public TransactionSet ResultSet { get { return _resultSet; }  }
    }
}