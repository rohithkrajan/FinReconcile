using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.MarkOffReader
{
    public class ParserResult:List<Transaction>
    {
        public ParserResult()
        {
            InvalidEntries = new List<string>();
            Headers = new List<string>();
        }
        public List<string> InvalidEntries { get; private set; }
        public List<string> Headers { get; private set; }
    }
}