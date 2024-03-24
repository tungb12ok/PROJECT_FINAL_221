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
        public bool failedFinancialTransactions(FinancialTransaction financial) => FinancialTransactionsDAO.Instance.failedFinancialTransactions(financial);
        public bool pendingFinancialTransactions(FinancialTransaction financial) => FinancialTransactionsDAO.Instance.pendingFinancialTransactions(financial);
        public bool toUpFinancialTransactions(FinancialTransaction financial) => FinancialTransactionsDAO.Instance.toUpFinancialTransactions(financial);
        public bool updateFinancialTransactions(FinancialTransaction financial) => FinancialTransactionsDAO.Instance.updateFinancialTransactions(financial);
    }
}
