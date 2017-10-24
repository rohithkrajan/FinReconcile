using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinReconcile.MarkOffReader
{
    public interface IMarkOffFileParser
    {
        ParserResult GetRecords(TextReader reader);
        ParserResult GetRecords(string markOffFileContent);
    }
}