using ClosedXML.Excel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Text;

namespace Exe
{
    public class TimerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TimerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Gọi các phương thức bạn muốn thực hiện trong dịch vụ
                SaveJson();
                RunLogin();

                // Chờ 30 giây trước khi thực hiện lại
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }

        private void SaveJson()
        {
            string[] accountEnquiryFiles = Directory.GetFiles(@"D:\history", "*Account Enquiry*");
            if (accountEnquiryFiles.Length > 0)
            {
                var sortedFiles = accountEnquiryFiles.OrderBy(f => File.GetLastWriteTime(f)).ToArray();
                var filePath = sortedFiles[0];

                var transactions = new List<TransactionRecord>();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed(); // Skip header row

                    foreach (var row in rows)
                    {
                        transactions.Add(new TransactionRecord
                        {
                            TransactionDate = row.Cell("A").GetValue<string>(),
                            EffectiveDate = row.Cell("B").GetValue<string>(),
                            Description = row.Cell("C").GetValue<string>(),
                            Debit = row.Cell("D").GetValue<string>(),
                            Credit = row.Cell("E").GetValue<string>(),
                            Balance = row.Cell("F").GetValue<string>(),
                            CounterpartyAccount = row.Cell("G").GetValue<string>(),
                            AccountName = row.Cell("H").GetValue<string>(),
                            TransactionCode = row.Cell("I").GetValue<string>(),
                        });
                    }
                }

                string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\"));
                string jsonFilePath = Path.Combine(solutionDirectory, "dataTranssion.json");
                jsonFilePath = jsonFilePath.Replace("Exe\\bin\\Debug\\", "");
                File.WriteAllText(jsonFilePath, string.Empty);
                var json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);

                foreach (var f in accountEnquiryFiles)
                {
                    File.Delete(f);
                }
            }
        }

        private void RunLogin()
        {
            string downloadDirectory = "C:\\Users\\tungl\\Downloads";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", downloadDirectory);

            string driverPath = @"D:\myTools\chromedriver_win32";
            using (var driver = new ChromeDriver(driverPath, options))
            {
                try
                {
                    driver.Navigate().GoToUrl("https://ebank.tpb.vn/retail/vX/main/inquiry/account/transaction?id=84802082002");
                    driver.FindElement(By.CssSelector("input[placeholder='Tên đăng nhập']")).SendKeys("x");
                    driver.FindElement(By.CssSelector("input[placeholder='Mật khẩu']")).SendKeys("x@123");
                    driver.FindElement(By.CssSelector(".btn-login")).Click();

                    Thread.Sleep(1000);
                    IWebElement footerElement = driver.FindElement(By.XPath("//app-footer"));

                    IWebElement body = driver.FindElement(By.TagName("body"));
                    body.SendKeys(Keys.End);

                    Thread.Sleep(1000);

                    IWebElement element = driver.FindElement(By.XPath("//span[contains(text(), 'Download file giao dịch Excel')]"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();

                    Thread.Sleep(2000);

                    string[] accountEnquiryFiles = Directory.GetFiles(downloadDirectory, "*Account Enquiry*");
                    if (accountEnquiryFiles.Length > 0)
                    {
                        var sortedFiles = accountEnquiryFiles.OrderBy(f => File.GetLastWriteTime(f)).ToArray();
                        string destinationPath = @"D:\history\" + Path.GetFileName(sortedFiles[0]);
                        File.Move(accountEnquiryFiles[0], destinationPath);
                        Console.WriteLine("Tải xuống hoàn tất và tệp đã được di chuyển.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
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

                    var dataAccept = new
                    {
                        accountNo = "84802082002",
                        currency = "VND",
                        fromDate = "20231106",
                        keyword = "",
                        maxAcentrysrno = "",
                        pageNumber = 1,
                        pageSize = 400,
                        toDate = "20240206"
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
