using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class WalletRepository : IWallet
    {
        public bool topDownMoney(int userID, decimal amount) => WalletDAO.Instance.topDownMoney(userID, amount);

        public bool topUpMoney(int userID, decimal amount) => WalletDAO.Instance.topUpMoney(userID, amount);
        public Wallet AddWallet(User user) => WalletDAO.Instance.AddWallet(user);
    }
}
