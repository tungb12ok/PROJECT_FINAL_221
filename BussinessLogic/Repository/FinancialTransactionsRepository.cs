using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class FinancialTransactionRepository : IFinancialTransactions
    {
        public bool failedFinancialTransactions(FinancialTransaction financial)
        {
            throw new NotImplementedException();
        }

        public bool pendingFinancialTransactions(FinancialTransaction financial)
        {
            throw new NotImplementedException();
        }

        public bool toUpFinancialTransactions(FinancialTransaction financial) => FinancialTransactionsDAO.Instance.toUpFinancialTransactions(financial);

        public bool updateFinancialTransactions(FinancialTransaction financial)
        {
            throw new NotImplementedException();
        }
    }
}
