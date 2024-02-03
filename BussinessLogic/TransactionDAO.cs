using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace BussinessLogic
{
    public class TransactionDAO
    {
        private QuickMarketContext context;
        private static TransactionDAO instance = null;
        private readonly static Object instanceLock = new Object();
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

    }
}
