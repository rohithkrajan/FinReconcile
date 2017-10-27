using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinReconcile.Domain;

using FinReconcile.RuleEngine;
using FinReconcile.RuleEngine.Rules;
using System.Collections.Concurrent;
using FinReconcile.Domain.Interfaces;

namespace FinReconcile.ReconcileEngine
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

            public IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> tutukaTransactions)
        {          

            AlignTransactions(clientTransactions, tutukaTransactions);

            foreach (var transId in _alignedTransactions.Keys)
            {
                ReconcileTransactionSet(_alignedTransactions[transId]);
            }
            return _result;

        }

        private void AlignTransactions(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> tutukaTransactions)
        {
            foreach (var clientTransaction in clientTransactions)
            {
                AlignTransaction(clientTransaction, null);
            }
            foreach (var tutkaTransaction in tutukaTransactions)
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
                    foreach (var tTrans in transSet.TutukaSet.ToList())
                    {
                        ReconciledItem currentResult = ruleEvaluator.Evaluate(cTrans, tTrans);
                        if (currentResult.MatchType == ReconciledMatchType.Matched)
                        {
                            reconciledItemList.Add(currentResult);
                            transSet.RemoveTransactions(currentResult.ClientTransaction, currentResult.TutukaTransaction);
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

      

        private void AlignTransaction(Transaction clientTranaction,Transaction tutukaTransaction)
        {
            if (clientTranaction!=null)
            {
                if (!_alignedTransactions.ContainsKey(clientTranaction.WalletReference))
                {
                    _alignedTransactions.Add(clientTranaction.WalletReference, new TransactionSet());                   
                }
                _alignedTransactions[clientTranaction.WalletReference].AddClientTransaction(clientTranaction);
            }
            if (tutukaTransaction != null)
            {
                if (!_alignedTransactions.ContainsKey(tutukaTransaction.WalletReference))
                {
                    _alignedTransactions.Add(tutukaTransaction.WalletReference, new TransactionSet());
                }
                _alignedTransactions[tutukaTransaction.WalletReference].AddTutukaTransaction(tutukaTransaction);
            }
        }
    }
}