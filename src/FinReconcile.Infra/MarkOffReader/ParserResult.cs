using FinReconcile.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.Infra.Parsers
{
    public class ParserResult:List<Transaction>
    {
        public ParserResult(bool isValid)
        {
            InvalidEntries = new Dictionary<int, string>();
            Headers = new List<string>();
            IsValid = isValid;
            Errors = new Dictionary<int, string>();
        }
        public Dictionary<int,string> InvalidEntries { get; private set; }
        public List<string> Headers { get; private set; }
        public bool IsValid { get; private set; }
        public Dictionary<int,string> Errors { get; private set; }
    }
}