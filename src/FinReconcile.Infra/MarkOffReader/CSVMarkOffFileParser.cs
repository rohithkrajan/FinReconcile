using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Linq;
using System;
using FinReconcile.Core.Domain;
using System.Text.RegularExpressions;

namespace FinReconcile.Infra.Parsers
{
    public class CSVMarkOffFileParser : IMarkOffFileParser
    {        
        Dictionary<string, int> _headerToIndexMap;
        List<string> headersToMatch = new List<string>() { "ProfileName","TransactionDate","TransactionAmount"
            ,"TransactionNarrative","TransactionDescription","TransactionID","TransactionType","WalletReference" };
        string _headerError = string.Empty;

        public CSVMarkOffFileParser()
        {
            _headerToIndexMap = new Dictionary<string, int>();            
        }
        
        private ParserResult ValidateAndInitHeaders(CsvReader reader)
        {

            ParserResult result;
            reader.Read();//read the header
            string headerLine = reader.Context.RawRecord;

            
            if (FindAndLoadAllHeaderIndexes(headerLine))
            {
                result = new ParserResult(true);

                result.Headers.AddRange(_headerToIndexMap.Keys.ToList());
                return result;
            }
            else
            {
                result = new ParserResult(false);
                result.Errors.Add(1, _headerError);
            }

            return result;
        }
        /// <summary>
        /// This function load the headers and it's indexes even if the headers are in different order
        /// </summary>
        /// <param name="headerLine"></param>
        /// <returns></returns>
        private bool FindAndLoadAllHeaderIndexes(string headerLine)
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
                _headerError=string.Format("Invalid file, {0} header(s) are not found",headers);
                return false;
            }
            
            index = 0;
            foreach (var value in _indexToHeaderMap.Values)
            {
                _headerToIndexMap.Add(value, index);
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
                        trans.ProfileName = csv.GetField<string>(_headerToIndexMap["ProfileName"]);
                        trans.Id = csv.GetField<string>(_headerToIndexMap["TransactionID"]);
                        trans.Amount = csv.GetField<long>(_headerToIndexMap["TransactionAmount"]);
                        trans.Date = csv.GetField<DateTime>(_headerToIndexMap["TransactionDate"]);
                        trans.Description = csv.GetField<string>(_headerToIndexMap["TransactionDescription"]);
                        trans.Narrative = csv.GetField<string>(_headerToIndexMap["TransactionNarrative"]);
                        trans.Type = (TransactionType)Enum.Parse(typeof(TransactionType), csv.GetField<string>(_headerToIndexMap["TransactionType"]));
                        trans.WalletReference = csv.GetField<string>(_headerToIndexMap["WalletReference"]);
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
            return ValidateAndInitHeaders(new CsvReader(new StreamReader(stream)));
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