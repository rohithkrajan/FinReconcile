using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FinConcile.Tests.TestUtils
{
    public static class SpecflowExtensions
    {
        public static IList<Transaction> GetTransactions(this Table table)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var row in table.Rows)
            {
                transactions.Add(new Transaction() {
                    ProfileName = row["ProfileName"],
                    Date = DateTime.Parse(row["Date"]),
                    Amount =Int64.Parse(row["Amount"]),
                    Narrative = row["Narrative"],
                    Description = row["Description"],
                    Type = (TransactionType)Enum.Parse(typeof(TransactionType),row["Type"]),
                    Id = row["Id"],
                    WalletReference = row["WalletReference"]
                });
            }
            return transactions;
        }
    }
}
