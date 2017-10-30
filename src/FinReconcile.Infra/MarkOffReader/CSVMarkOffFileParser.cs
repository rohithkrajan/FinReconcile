using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Linq;
using System;
using FinReconcile.Core.Domain;
using System.Text.RegularExpressions;
using FinReconcile.Infra.MarkOffReader;

namespace FinReconcile.Infra.Parsers
{
    public class CSVMarkOffFileParser : IMarkOffFileParser
    {        
        
        List<string> headersToMatch = new List<string>() { "ProfileName","TransactionDate","TransactionAmount"
            ,"TransactionNarrative","TransactionDescription","TransactionID","TransactionType","WalletReference" };
        

        public CSVMarkOffFileParser()
        {
           
        }
        
        private ParserResult ValidateAndInitHeaders(CsvReader reader)
        {

            ParserResult result;
            reader.Read();//read the header
            string headerLine = reader.Context.RawRecord;

            ParserContext context = new ParserContext();
            
            if (FindAndLoadAllHeaderIndexes(context,headerLine))
            {
                result = new ParserResult(true);

                result.Headers.AddRange(context.HeaderToIndexMap.Keys.ToList());
                result.HeaderIndexes = context.HeaderToIndexMap;
                return result;
            }
            else
            {
                result = new ParserResult(false);
                result.Errors.Add(1, context.HeaderError);
            }
            
            return result;
        }
        /// <summary>
        /// This function load the headers and it's indexes even if the headers are in different order
        /// </summary>
        /// <param name="headerLine"></param>
        /// <returns></returns>
        private bool FindAndLoadAllHeaderIndexes(ParserContext context,string headerLine)
        {
            //create a map which stores the index of each header in a sorted dictionary in the order of index 
            SortedDictionary<int, string> _indexToHeaderMap = new SortedDictionary<int, string>();

            string headers = string.Empty;

            bool isValid = true;
            int index;
            //add index along with whether the header is avaialble or not.
            foreach (var header in headersToMatch)
            {
                index = headerLine.IndexOf(header, StringComparison.InvariantCultureIgnoreCase);
                if (index<0)
                {
                    isValid = false;
                    headers += header;
                }
                else
                {
                    _indexToHeaderMap.Add(index, header);
                }
                
            }
            if (isValid==false)
            {
                context.HeaderError=string.Format("Invalid file, {0} header(s) are not found",headers);
                return false;
            }
            
            index = 0;
            foreach (var value in _indexToHeaderMap.Values)
            {
                context.HeaderToIndexMap.Add(value, index);
                index++;
            }
           
            return true;
        }

        public ParserResult GetRecords(TextReader reader)
        {
            var csv = new CsvReader(reader);
            ParserResult result = ValidateAndInitHeaders(csv);
            int lineNo = 2;
            if (result.IsValid)
            {
                while (csv.Read())
                {
                    try
                    {
                        Transaction trans = new Transaction();
                        trans.ProfileName = csv.GetField<string>(result.HeaderIndexes["ProfileName"]);
                        trans.Id = csv.GetField<string>(result.HeaderIndexes["TransactionID"]);
                        trans.Amount = csv.GetField<long>(result.HeaderIndexes["TransactionAmount"]);
                        trans.Date = csv.GetField<DateTime>(result.HeaderIndexes["TransactionDate"]);
                        trans.Description = csv.GetField<string>(result.HeaderIndexes["TransactionDescription"]);
                        trans.Narrative = csv.GetField<string>(result.HeaderIndexes["TransactionNarrative"]);
                        trans.Type = (TransactionType)Enum.Parse(typeof(TransactionType), csv.GetField<string>(result.HeaderIndexes["TransactionType"]));
                        trans.WalletReference = csv.GetField<string>(result.HeaderIndexes["WalletReference"]);
                        result.Add(trans);

                    }
                    catch (System.Exception ex)
                    {
                        result.InvalidEntries.Add(lineNo, csv.Context.RawRecord);
                        result.Errors.Add(lineNo, string.Format("Line {0} :Error {1}", lineNo, ex.Message));
                    }
                    lineNo++;
                }
            }
           
            return result;
        }

        public ParserResult GetRecords(string markOffFileContent)
        {
            using (TextReader sr = new StringReader(markOffFileContent))
            {
                return GetRecords(sr);
            }
        }

        private ParserResult Validate(CsvReader reader)
        {
            return ValidateAndInitHeaders(reader);
        }

        public ParserResult Validate(Stream stream)
        {
            try
            {
                stream.Position = 0;
                var result = ValidateAndInitHeaders(new CsvReader(new StreamReader(stream)));
                stream.Position = 0;
                return result;
            }
            catch (Exception ex)
            {
                stream.Position = 0;
                stream.Close();
                throw;
            }
            
        }

        public ParserResult Validate(string markOffFileContent)
        {
            using (TextReader sr = new StringReader(markOffFileContent))
            {
                return Validate(new CsvReader(sr));
            }
        }
    }
}