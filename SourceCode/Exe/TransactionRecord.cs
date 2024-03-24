using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe
{
    public class TransactionRecord
    {
        public string TransactionDate { get; set; }
        public string EffectiveDate { get; set; }
        public string Description { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
        public string CounterpartyAccount { get; set; }
        public string AccountName { get; set; }
        public string TransactionCode { get; set; }
    }
}
