using BussinessLogic.Repository;
using DataAccess.Models;
using DataAccess.Enum;


namespace BussinessLogic
{
    public class FinancialTransactionsDAO : IFinancialTransactions
    {
        private QuickMarketContext context;
        private static FinancialTransactionsDAO instance = null;
        private readonly static Object instanceLock = new Object();


        public FinancialTransactionsDAO()
        {
            context = new QuickMarketContext();
        }

        public static FinancialTransactionsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FinancialTransactionsDAO();
                    }
                    return instance;
                }
            }
        }



        public bool updateFinancialTransactions(FinancialTransaction financial)
        {
            try
            {
                if (financial == null)
                {
                    Console.WriteLine("Error: Financial transaction is null.");
                    return false;
                }

                var existingFinancialTransaction = context.FinancialTransactions.FirstOrDefault(x => x.TransactionId == financial.TransactionId);

                if (existingFinancialTransaction != null)
                {
                    existingFinancialTransaction.Status = TransactionStatus.Successful.ToString();
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool failedFinancialTransactions(FinancialTransaction financial)
        {
            throw new NotImplementedException();
        }

        public bool pendingFinancialTransactions(FinancialTransaction financial)
        {
            throw new NotImplementedException();
        }

        public bool toUpFinancialTransactions(FinancialTransaction financial)
        {
            try
            {
                if (financial == null)
                {
                    Console.WriteLine("Error: Financial transaction is null.");
                    return false;
                }

                var existingFinancialTransaction = context.FinancialTransactions.FirstOrDefault(x => x.TransactionId == financial.TransactionId);

                if (existingFinancialTransaction == null)
                {
                    context.FinancialTransactions.Add(financial);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
