using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Repository;
using DataAccess.Models;
namespace BussinessLogic
{
    public class TransactionDAO : ITransactionRepository
    {
        private QuickMarketContext context;
        private static TransactionDAO instance = null;
        private readonly static Object instanceLock = new Object();
        WalletRepository wRepo = new WalletRepository();
        public TransactionDAO(QuickMarketContext dbContext)
        {
            context = dbContext;
        }

        public TransactionDAO()
        {
        }

        public static TransactionDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TransactionDAO();
                    }
                    return instance;
                }
            }
        }

        public bool addTransaction(Transaction t)
        {
            try
            {
                context.Transactions.Add(t);
                context.SaveChanges();
                return true;   
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateTransaction(Transaction t)
        {
            Transaction tUpdate = context.Transactions.FirstOrDefault(x => x.TransactionId == t.TransactionId);
            if (tUpdate != null)
            {
                tUpdate.TransactionDate = t.TransactionDate;
                tUpdate.Status = t.Status;
            }
            try
            {
                context.Transactions.Add(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool trasaction(Transaction t, Wallet w)
        {
            bool flag = wRepo.topDownMoney((int)t.BuyerId, t.Amount);
            flag = wRepo.topDownMoney((int)t.SellerId, t.Amount);

            return flag;
        }
    }
}
