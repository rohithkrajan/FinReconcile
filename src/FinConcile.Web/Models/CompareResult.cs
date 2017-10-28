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
        private int _matchedTutuka;
        private int _unMatchedClient;
        private int _unMatchedTutuka;

        public CompareResult(string clientMarkOffFile,string tutukaMarkOffFile, IReconcileResult result)
        {
            this.ClientMarkOffFile = clientMarkOffFile;
            this.TutukaMarkOffFile = tutukaMarkOffFile;           

            _matchedClient = result.GetMatchedClientTransactions().Count;
            _matchedTutuka = result.GetMatchedTutukaTransactions().Count;
            _unMatchedClient = result.GetUnMatchedClientTransactions().Count;
            _unMatchedTutuka = result.GetUnMatchedTutukaTransactions().Count;            
            
            Result = result;
        }
        public string ClientMarkOffFile { get; private set; }
        public string TutukaMarkOffFile { get; private set; }       

        public int TotalClientRecords { get { return _matchedClient + _unMatchedClient; } }
        public int TotalTutukaRecords { get { return _matchedTutuka + _unMatchedTutuka; } }
        public int MatchingClientRecords { get { return _matchedClient; } }
        public int MatchingTutukaRecords { get { return _matchedTutuka; } }

        public int UnmatchedClientRecords { get { return _unMatchedClient; } }
        public int UnmatchedTutkaRecords { get { return _unMatchedTutuka; } }

        public IReconcileResult Result { get; private set; }
    }
}