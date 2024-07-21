using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public interface IWallet
    {
        public bool topUpMoney(int userID, decimal amount);
        public bool topDownMoney(int UserID, decimal amount);
        public Wallet AddWallet(User user);
    }
}
