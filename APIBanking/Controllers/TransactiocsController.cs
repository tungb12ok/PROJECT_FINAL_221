using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIBanking.Controllers
{
    [ApiController]
    [Route("api/mbbank")]
    public class TransactionsController : ControllerBase
    {
        protected string username = "0972074620";
        protected string password = "Tungld123@123";
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("checkTransactions")]
        public async Task<IActionResult> CheckTransactions()
        {
            try
            {
                // The rest of your code remains unchanged
                var accessToken = await LoginAsync(username, password);

                var json = await GetDataAsync(accessToken);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error checking transactions: {ex.Message}");
            }
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
                    // Get the current date and format it as "yyyyMMdd"
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    var dataAccept = new
                    {
                        accountNo = "84802082002",
                        currency = "VND",
                        fromDate = "20231106",
                        keyword = "",
                        maxAcentrysrno = "",
                        pageNumber = 1,
                        pageSize = 400,
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
    }
}
public class TokenResponse
{
    public string access_token { get; set; }
}

