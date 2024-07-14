using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WEB.Extenstions;
using BussinessLogic;
using BussinessLogic.Repository;
namespace WEB.Services
{
    public class CheckingPayment
    {
        private static string username = "0972074620";
        private static string password = "Tungld123@123";
        private static string AccessToken { get; set; } = string.Empty;
        public static async void SystemCheckingBanking()
        {
            QuickMarketContext context = new QuickMarketContext();
            WalletRepository wp = new WalletRepository();
            FinancialTransactionRepository f = new FinancialTransactionRepository();

            List<FinancialTransaction> ftList = context.FinancialTransactions
                                                           .Where(x => x.Status == "Pending")
                                                           .Take(50)
                                                           .ToList();

            foreach (FinancialTransaction ft in ftList)
        {
                if (await CheckingPayment.CheckingBanking(ft))
                {
                    wp.topUpMoney(ft.UserId, ft.Amount);
                    f.updateFinancialTransactions(ft);
                }
            }
        }
        public static async Task<bool> CheckingBanking(FinancialTransaction ft)
        {
            var jsonData = await CheckingPayment.ExeServiceAsync();
            Banking jsonDataObj = JsonConvert.DeserializeObject<Banking>(jsonData);
            
            if (jsonDataObj != null)
            {
                foreach (TransactionInfo info in jsonDataObj.transactionInfos)
                {
                    if (info.description.Contains(ft.Description) && ft.Amount == info.amount)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static public async Task<string> ExeServiceAsync()
            {
            int count = 5;

                while (true)
                {
                var json = string.Empty;
                if (count == 0)
                {
                    return "";
                }
                if (AccessToken != null)
                {
                    json = await GetDataAsync(AccessToken);
                }
                if(json == null || String.IsNullOrEmpty(json)){
                    AccessToken = await LoginAsync(username, password);
                    count--;
                }
                else
                {
                    return json;
                }
            }

            // Sau đó, sử dụng AccessToken để thực hiện các yêu cầu khác
            return await GetDataAsync(AccessToken);
        }
        static async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string loginEndpoint = "https://ebank.tpb.vn/gateway/api/auth/login";

                    var loginData = new
                    {
                        username = username,
                        password = password,
                        step_2FA = "VERIFY"
                    };

                    string jsonLoginData = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);

                    StringContent content = new StringContent(jsonLoginData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(loginEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        // Extract the access token from the response
                        var tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(responseData);
                        var accessToken = tokenResponse?.access_token;

                        return accessToken;
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Status Code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during login: " + ex.Message);
            }
            return null;
        }

        static async Task<string> GetDataAsync(string accessToken)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string dataEndpoint = "https://ebank.tpb.vn/gateway/api/smart-search-presentation-service/v2/account-transactions/find";
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    var dataAccept = new
                    {
                        accountNo = "84802082002",
                        currency = "VND",
                        fromDate = "20231106",
                        keyword = "",
                        maxAcentrysrno = "",
                        pageNumber = 1,
                        pageSize = 50,
                        toDate = currentDate
                    };

                    // Set authorization header
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    // Serialize request data to JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataAccept);

                    // Create StringContent with JSON data
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Send a POST request to the data endpoint
                    HttpResponseMessage response = await client.PostAsync(dataEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                    else
                    {
                        Console.WriteLine("Data retrieval failed. Status Code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during data retrieval: " + ex.Message);
            }
            return null;
        }
        static public async Task<bool> checkAuthentication(string accessToken)
        {
            try
            {
                await GetDataAsync(accessToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

}
