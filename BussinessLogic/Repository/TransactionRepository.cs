using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public bool addFunds(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public bool addTransaction(Transaction t)
        {
            throw new NotImplementedException();
        }

        public bool minusFunds(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public bool updateFunds(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public bool updateTransaction(Transaction t)
        {
            throw new NotImplementedException();
        }
    }
}
