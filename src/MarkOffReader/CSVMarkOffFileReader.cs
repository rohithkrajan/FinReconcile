using System.Collections.Generic;
using FinReconcile.Domain;
using FinReconcile.Providers;
using CsvHelper;
using System.IO;
using System.Linq;
using System;

namespace FinReconcile.MarkOffReader
{
    public class CSVMarkOffFileReader : IMarkOffFileReader
    {       
        public IEnumerable<Transaction> GetRecords(TextReader reader)
        {
            var csv = new CsvReader(reader);
            csv.Read();//skips the heade
            IList<Transaction> transactions = new List<Transaction>();
            
            while (csv.Read())
            {
                try
                {
                    Transaction trans = new Transaction()
                    {
                        ProfileName=csv.GetField<string>(0),
                        Id= csv.GetField<string>(5),
                        Amount= csv.GetField<long>(2),
                        Date= csv.GetField<DateTime>(1),
                        Description= csv.GetField<string>(4),
                        Narrative= csv.GetField<string>(3),
                        Type= (TransactionType)Enum.Parse(typeof(TransactionType),csv.GetField<string>(6)),
                        WalletReference= csv.GetField<string>(7)

                    };
                    transactions.Add(trans);

                }
                catch (System.Exception ex)
                {
                    //ignore unreadable rows
                }
            }
            return transactions;
        }

        public IEnumerable<Transaction> GetRecords(string markOffFileContent)
        {
            using (TextReader sr = new StringReader(markOffFileContent))
            {
                return GetRecords(sr);
            }
        }
    }
}