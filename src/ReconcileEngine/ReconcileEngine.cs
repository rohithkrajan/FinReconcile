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
        IDictionary<string, TransactionSet> _alignedTransactions;
        IReconcileResult _result;
        public ReconcileEngine()
        {
            _ruleSetEvaulators.Add(new RuleSetEvaluator("MatchAllFields",new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new PropertyRule("Date", "Equal", "Date")
                }), ReconciledMatchType.Matched));

            _ruleSetEvaulators.Add(new RuleSetEvaluator("MatchDateWithDeltaof120SecondsAndAllOtherFields", new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new DateRule(120)
                }), ReconciledMatchType.Matched));

            _result = new ReconcileResult();
        }

        public IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> tutukaTransactions)
        {
            
            _alignedTransactions = new Dictionary<string, TransactionSet>();
            
            foreach (var clientTransaction in clientTransactions)
            {
                AlignTransaction(clientTransaction, null);
            }
            foreach (var tutkaTransaction in tutukaTransactions)
            {
                AlignTransaction(null, tutkaTransaction);
            }

            foreach (var transId in _alignedTransactions.Keys)
            {
                ReconcileTransactionSet(_alignedTransactions[transId]);
            }
            return _result;

        }
        protected  void ReconcileTransactionSet(TransactionSet transSet)
        {
            List<ReconciledItem> reconciledItemList = new List<ReconciledItem>();

            foreach (var ruleEvaluator in _ruleSetEvaulators.Where(rule=>rule.RuleType==ReconciledMatchType.Matched))
            {
                foreach (var cTrans in transSet.ClientSet.ToList())
                {
                    ReconciledItem currentResult;
                    foreach (var tTrans in transSet.TutukaSet.ToList())
                    {
                        currentResult = ruleEvaluator.Evaluate(cTrans, tTrans);
                        if (currentResult.MatchType == ReconciledMatchType.Matched)
                        {
                            reconciledItemList.Add(currentResult);
                            transSet.RemoveTransactions(currentResult.ClientTransaction, currentResult.TutukaTransaction);
                        }
                    }
                }
            }

            _result.AddItems(reconciledItemList);
                    
                       
        }
        protected void AlignTransaction(Transaction clientTranaction,Transaction tutukaTransaction)
        {
            if (clientTranaction!=null)
            {
                if (!_alignedTransactions.ContainsKey(clientTranaction.Id))
                {
                    _alignedTransactions.Add(clientTranaction.Id, new TransactionSet());                   
                }
                _alignedTransactions[clientTranaction.Id].AddClientTransaction(clientTranaction);
            }
            if (tutukaTransaction != null)
            {
                if (!_alignedTransactions.ContainsKey(tutukaTransaction.Id))
                {
                    _alignedTransactions.Add(tutukaTransaction.Id, new TransactionSet());
                }
                _alignedTransactions[tutukaTransaction.Id].AddTutukaTransaction(tutukaTransaction);
            }
        }
    }
}