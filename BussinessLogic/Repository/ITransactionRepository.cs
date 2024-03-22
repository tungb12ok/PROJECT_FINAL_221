using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public interface ITransactionRepository
    {
        public bool addTransaction(Transaction t);
        public bool updateTransaction(Transaction t);

        public bool trasaction(Transaction t, Wallet w);
    }
}
