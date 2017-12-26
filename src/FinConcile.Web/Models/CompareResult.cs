using FinReconcile.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Models
{
    public class CompareResult
    {
        private int _matchedClient;
        private int _matchedBank;
        private int _unMatchedClient;
        private int _unMatchedBank;

        public CompareResult(string clientMarkOffFile,string bankMarkOffFile, IReconcileResult result)
        {
            this.ClientMarkOffFile = clientMarkOffFile;
            this.BankMarkOffFile = bankMarkOffFile;           

            _matchedClient = result.GetMatchedClientTransactions().Count;
            _matchedBank = result.GetMatchedBankTransactions().Count;
            _unMatchedClient = result.GetUnMatchedClientTransactions().Count;
            _unMatchedBank = result.GetUnMatchedBankTransactions().Count;            
            
            Result = result;
        }
        public string ClientMarkOffFile { get; private set; }
        public string BankMarkOffFile { get; private set; }       

        public int TotalClientRecords { get { return _matchedClient + _unMatchedClient; } }
        public int TotalBankRecords { get { return _matchedBank + _unMatchedBank; } }
        public int MatchingClientRecords { get { return _matchedClient; } }
        public int MatchingBankRecords { get { return _matchedBank; } }

        public int UnmatchedClientRecords { get { return _unMatchedClient; } }
        public int UnmatchedTutkaRecords { get { return _unMatchedBank; } }

        public IReconcileResult Result { get; private set; }
    }
}