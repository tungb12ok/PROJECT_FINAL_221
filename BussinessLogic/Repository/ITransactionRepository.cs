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
        public bool addFunds(Wallet wallet);
        public bool updateFunds(Wallet wallet);
        public bool minusFunds(Wallet wallet);
    }
}
