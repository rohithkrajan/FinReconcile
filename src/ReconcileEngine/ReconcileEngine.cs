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
        SimpleRuleEngine _matchAllPropsEngine, _matchAllPropsAndDateWithDelta;
        IDictionary<string, TransactionSet> _alignedTransactions;
        public ReconcileEngine()
        {
            _matchAllPropsEngine = new SimpleRuleEngine(new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new PropertyRule("Date", "Equal", "Date")
                }));
            _matchAllPropsAndDateWithDelta = new SimpleRuleEngine(new RuleSet(new IRule[] {
                new PropertyRule("Id", "Equal", "Id") ,
                new PropertyRule("Amount", "Equal", "Amount"),
                new PropertyRule("ProfileName", "Equal", "ProfileName"),
                new PropertyRule("Description", "Equal", "Description"),
                new PropertyRule("Narrative", "Equal", "Narrative"),
                new PropertyRule("WalletReference", "Equal", "WalletReference"),
                new DateRule(120)
                }));
        }

        public IReconcileResult Reconcile(IEnumerable<Transaction> clientTransactions, IEnumerable<Transaction> tutukaTransactions)
        {
            IReconcileResult result = null;
            _alignedTransactions = new Dictionary<string, TransactionSet>();
            
            foreach (var clientTransaction in clientTransactions)
            {
                AlignTransaction(clientTransaction, null);
            }
            foreach (var tutkaTransaction in tutukaTransactions)
            {
                AlignTransaction(null, tutkaTransaction);
            }

            for (int i = 0; i < _alignedTransactions.Count; i++)
            {

            }
            return result;

        }
        protected  void ReconcileTransactionSet(TransactionSet transSet)
        {
            List<ReconciledItem> reconciledList = new List<ReconciledItem>();

            foreach (var cTrans in transSet.ClientSet)
            {
                ReconciledItem currentResult;
                foreach (var tTrans in transSet.TutukaSet)
                {
                    currentResult= _matchAllPropsEngine.Evaluate(cTrans, tTrans);
                    if (currentResult.MatchType==ReconciledMatchType.Matched)
                    {
                        break;
                    }

                }


                
            }
           
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
                _alignedTransactions[clientTranaction.Id].AddTutukaTransaction(tutukaTransaction);
            }
        }
    }
}