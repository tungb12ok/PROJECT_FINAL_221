using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace BussinessLogic.Repository
{
    public interface IFinancialTransactions
    {
        public bool toUpFinancialTransactions(FinancialTransaction financial);
        public bool updateFinancialTransactions(FinancialTransaction financial);
        public bool failedFinancialTransactions(FinancialTransaction financial);
        public bool pendingFinancialTransactions(FinancialTransaction financial);

    }
}
