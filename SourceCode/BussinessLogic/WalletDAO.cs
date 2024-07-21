using BussinessLogic.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class WalletDAO : IWallet
    {
        private QuickMarketContext context;
        private static WalletDAO instance = null;
        private readonly static Object instanceLock = new Object();


        public WalletDAO()
        {
            context = new QuickMarketContext();
        }

        public static WalletDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new WalletDAO();
                    }
                    return instance;
                }
            }
        }

        public bool topUpMoney(int userID, decimal amount)
        {
            Wallet updateWallet = context.Wallets.FirstOrDefault(x => x.UserId == userID);

            if (updateWallet != null)
            {
                try
                {
                    updateWallet.Balance += amount;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }

        public bool topDownMoney(int userID, decimal amount)
        {
            Wallet updateWallet = context.Wallets.FirstOrDefault(x => x.UserId == userID);

            if (updateWallet != null)
            {
                try
                {
                    if (updateWallet.Balance > amount)
                    {
                        updateWallet.Balance -= amount;
                        context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
        
        public Wallet AddWallet(User user)
        {
            Wallet wallet = new Wallet
            {
                UserId = user.UserId,
                Balance = 0,
                LastUpdate = DateTime.Now,
            };
            return wallet;
        }
    }
}
