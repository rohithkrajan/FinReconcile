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
            _clientTransaction = clientTrans;
            _tutukaTransaction = tutukaTrans;
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
        public Transaction TutukaTransaction
        {
            get
            {
                if (_tutukaTransaction != null)
                {
                    return _tutukaTransaction;
                }
                else
                {
                    if (_resultSet != null && _resultSet.TutukaSet != null )
                    {
                        return _resultSet.TutukaSet.FirstOrDefault();
                    }
                    return null;
                }
            }
        }

        private Transaction _clientTransaction;
        private Transaction _tutukaTransaction;
        private TransactionSet _resultSet;

        public ReconciledMatchType MatchType { get; private set; }
        public TransactionSet ResultSet { get;  }
    }
}