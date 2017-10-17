using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Models
{
    public class CompareResult
    {
        public CompareResult(string clientMarkOffFile,string tutukaMarkOffFile)
        {
            this.ClientMarkOffFile = clientMarkOffFile;
            this.TutukaMarkOffFile = tutukaMarkOffFile;
        }
        public string ClientMarkOffFile { get; private set; }
        public string TutukaMarkOffFile { get; private set; }
        public int TotalRecords { get; private set; }
        public int MatchingRecords { get; private set; }
        public int UnmatchedRecords { get; private set; }
    }
}