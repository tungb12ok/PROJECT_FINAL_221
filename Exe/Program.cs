using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Exe;
using Newtonsoft.Json;
using ClosedXML.Excel;

class Program
{
    static void Main(string[] args)
    {
        runLogin();
        saveJson();
    }
    public static void saveJson()
    {
        string[] accountEnquiryFiles = Directory.GetFiles(@"D:\history", "*Account Enquiry*");
        var sortedFiles = accountEnquiryFiles.OrderBy(f => File.GetLastWriteTime(f)).ToArray();

        var filePath = @"D:\history\" + Path.GetFileName(sortedFiles[0]);
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
        string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Exe"));
        string jsonFilePath = Path.Combine(solutionDirectory, "dataTranssion.json");
        jsonFilePath = jsonFilePath.Replace("bin\\Debug\\Exe\\", "");

        
        var json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);
        foreach (var f in accountEnquiryFiles)
        {
            var path = @"D:\history\" + Path.GetFileName(f);
            File.Delete(path);
        }
    }
    public static void runLogin()
    {
        // Định nghĩa thư mục tải xuống
        string downloadDirectory = "C:\\Users\\tungl\\Downloads";
        // Cấu hình cho trình duyệt Chrome
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddUserProfilePreference("download.default_directory", downloadDirectory);

        // Đường dẫn đến ChromeDriver
        string driverPath = @"D:\myTools\chromedriver_win32"; // Thay đổi đường dẫn này theo môi trường của bạn
        IWebDriver driver = new ChromeDriver(driverPath, options);

        try
        {
            driver.Navigate().GoToUrl("https://ebank.tpb.vn/retail/vX/main/inquiry/account/transaction?id=84802082002");
            driver.FindElement(By.CssSelector("input[placeholder='Tên đăng nhập']")).SendKeys("0972074620");
            driver.FindElement(By.CssSelector("input[placeholder='Mật khẩu']")).SendKeys("Tungld123@123");
            driver.FindElement(By.CssSelector(".btn-login")).Click();

            Thread.Sleep(6000); 

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath("//span[contains(text(), 'Download file giao dịch Excel')]")).Click();

            Thread.Sleep(2000);     

            string[] accountEnquiryFiles = Directory.GetFiles(downloadDirectory, "*Account Enquiry*");
            if (accountEnquiryFiles.Length > 0)
            {
                var sortedFiles = accountEnquiryFiles.OrderBy(f => File.GetLastWriteTime(f)).ToArray();
                string destinationPath = @"D:\history\" + Path.GetFileName(sortedFiles[0]);
                File.Move(accountEnquiryFiles[0], destinationPath);
                File.Delete(accountEnquiryFiles[0]);
                Console.WriteLine("Tải xuống hoàn tất và tệp đã được di chuyển.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
        finally
        {
            driver.Quit();
        }

    }
}

