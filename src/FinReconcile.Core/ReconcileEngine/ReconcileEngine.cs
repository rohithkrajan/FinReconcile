using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections.Concurrent;

using FinReconcile.Core.Domain.Interfaces;
using FinReconcile.Core.Domain;

namespace FinReconcile.Core.Engines
{
    public class ReconcileEngine : IReconcileEngine
    {
        IList<IRuleEvaluator> _ruleSetEvaulators = new List<IRuleEvaluator>();
        IDictionary<string, TransactionSet> _alignedTransactions= new Dictionary<string, TransactionSet>();
        IReconcileResult _result = new ReconcileResult();

        public IList<IRuleEvaluator> RuleEvaluators { get { return _ruleSetEvaulators; } }

        public ReconcileEngine(IList<IRuleEvaluator> ruleSetEvaluators)
        {
            foreach (var evaluator in ruleSetEvaluators)
            {
                _ruleSetEvaulators.Add(evaluator);
            }
        }

            public IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> bankTransactions)
        {          

            AlignTransactions(clientTransactions, bankTransactions);

            foreach (var transId in _alignedTransactions.Keys)
            {
                ReconcileTransactionSet(_alignedTransactions[transId]);
            }
            return _result;

        }

        private void AlignTransactions(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> bankTransactions)
        {
            foreach (var clientTransaction in clientTransactions)
            {
                AlignTransaction(clientTransaction, null);
            }
            foreach (var tutkaTransaction in bankTransactions)
            {
                AlignTransaction(null, tutkaTransaction);
            }
        }

        private  void ReconcileTransactionSet(TransactionSet transSet)
        {
            List<ReconciledItem> reconciledItemList = new List<ReconciledItem>();

            foreach (var ruleEvaluator in _ruleSetEvaulators.Where(rule=>rule.RuleType==ReconciledMatchType.Matched))
            {
                foreach (var cTrans in transSet.ClientSet.ToList())
                {                     
                    foreach (var tTrans in transSet.BankSet.ToList())
                    {
                        ReconciledItem currentResult = ruleEvaluator.Evaluate(cTrans, tTrans);
                        if (currentResult.MatchType == ReconciledMatchType.Matched)
                        {
                            reconciledItemList.Add(currentResult);
                            transSet.RemoveTransactions(currentResult.ClientTransaction, currentResult.BankTransaction);
                        }                       
                    }
                }
            }

            if (!transSet.IsReconciled)
            {
                _result.Add(new ReconciledItem(transSet, ReconciledMatchType.NotMatched));
            }       

            _result.AddItems(reconciledItemList);
                    
                       
        }

      

        private void AlignTransaction(Transaction clientTranaction,Transaction bankTransaction)
        {
            if (clientTranaction!=null)
            {
                if (!_alignedTransactions.ContainsKey(clientTranaction.WalletReference))
                {
                    _alignedTransactions.Add(clientTranaction.WalletReference, new TransactionSet());                   
                }
                _alignedTransactions[clientTranaction.WalletReference].AddClientTransaction(clientTranaction);
            }
            if (bankTransaction != null)
            {
                if (!_alignedTransactions.ContainsKey(bankTransaction.WalletReference))
                {
                    _alignedTransactions.Add(bankTransaction.WalletReference, new TransactionSet());
                }
                _alignedTransactions[bankTransaction.WalletReference].AddBankTransaction(bankTransaction);
            }
        }
    }
}