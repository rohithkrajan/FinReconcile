using FinReconcile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Models
{
    public class CompareResult
    {
        public CompareResult(string clientMarkOffFile,string tutukaMarkOffFile, IReconcileResult result)
        {
            this.ClientMarkOffFile = clientMarkOffFile;
            this.TutukaMarkOffFile = tutukaMarkOffFile;
            this.TotalRecords = (result.MatchedItems.Count * 2) + result.NotMatchedItems.Count;
            this.MatchingRecords = result.MatchedItems.Count;
            this.UnmatchedRecords = result.NotMatchedItems.Count;
        }
        public string ClientMarkOffFile { get; private set; }
        public string TutukaMarkOffFile { get; private set; }
        public int TotalRecords { get; private set; }
        public int MatchingRecords { get; private set; }
        public int UnmatchedRecords { get; private set; }
    }
}