using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinReconcile.MarkOffReader
{
    public interface IMarkOffFileReader
    {
        IEnumerable<Transaction> GetRecords(TextReader reader);
        IEnumerable<Transaction> GetRecords(string markOffFileContent);
    }
}