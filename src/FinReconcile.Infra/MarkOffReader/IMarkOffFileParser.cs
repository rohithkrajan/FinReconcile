using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinReconcile.Infra.Parsers
{
    public interface IMarkOffFileParser
    {
        ParserResult Validate(Stream stream);
        ParserResult Validate(string markOffFileContent);
        ParserResult GetRecords(TextReader reader);
        ParserResult GetRecords(string markOffFileContent);
    }
}