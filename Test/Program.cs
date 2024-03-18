using Newtonsoft.Json;
using WEB.Services;
using DataAccess.Models;
using BussinessLogic.Repository;


var jsonData = await CheckingPayment.ExeServiceAsync();
Banking jsonDataObj = JsonConvert.DeserializeObject<Banking>(jsonData);
Console.WriteLine("Json convert: " + jsonDataObj.transactionInfos.Count);

//FinancialTransaction ft = new FinancialTransaction
//{
//    TransactionId = 1,
//    UserId = 7,
//    TransactionType = "VND",
//    Amount = 2000,
//    TransactionDate = DateTime.Now,
//    Status = "Pending",
//    Description = "CODE055904"
//};

QuickMarketContext context = new QuickMarketContext();
WalletRepository wp = new WalletRepository();

List<FinancialTransaction> ftList = context.FinancialTransactions
                                            .Where(x => x.Status == "Pending")
                                            .ToList();
foreach (FinancialTransaction ft in ftList)
{
    Console.WriteLine(ft.ToString());
    Console.WriteLine(await CheckingPayment.CheckingBanking(ft));
    if (await CheckingPayment.CheckingBanking(ft))
    {
        wp.topUpMoney(ft.UserId, ft.Amount);
    }
}