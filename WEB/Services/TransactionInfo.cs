namespace WEB.Services
{
    public class TransactionInfo
    {
        public string id { get; set; }
        public string arrangementId { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string bookingDate { get; set; }
        public string valueDate { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string creditDebitIndicator { get; set; }
        public string runningBalance { get; set; }
    }
}
