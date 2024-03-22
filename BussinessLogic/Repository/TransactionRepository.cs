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
        public bool addTransaction(Transaction t)
        {
            throw new NotImplementedException();
        }
        public bool trasaction(Transaction t, Wallet w) => TransactionDAO.Instance.trasaction(t, w);
        public bool updateTransaction(Transaction t)
        {
            throw new NotImplementedException();
        }
    }
}
