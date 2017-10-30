using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.Infra.MarkOffReader
{
    internal class ParserContext
    {
        internal ParserContext()
        {
            HeaderToIndexMap = new Dictionary<string, int>();
            HeaderError = string.Empty;
        }

        internal Dictionary<string, int> HeaderToIndexMap { get;  private set; }
        internal string HeaderError  {get; set;}
    }
}
