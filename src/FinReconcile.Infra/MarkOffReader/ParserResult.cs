using FinReconcile.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Infra.Parsers
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